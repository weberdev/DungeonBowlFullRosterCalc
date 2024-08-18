using System.Numerics;
using TeamDefinitions;
int startingValue = 1000000;
int sevensStartingValue;

Team activeTeam = new Team("defaultTeam", 50000, false);
Console.WriteLine("Greetings, sports fans!\n");
TeamDefiners holder = new TeamDefiners();
List<Team> bloodBowlTeams = holder.defineBloodBowlTeams();
List<Team> dungeonBowlTeams = holder.defineDungeonBowlTeams();
List<Team> allTeams = dungeonBowlTeams.Concat(bloodBowlTeams).ToList();
bloodBowlTeams = bloodBowlTeams.OrderBy(team => team.name).ToList();
dungeonBowlTeams = dungeonBowlTeams.OrderBy(team => team.name).ToList();
List<List<Team>> fullTeamLists = new List<List<Team>>();
fullTeamLists.Add(bloodBowlTeams);
fullTeamLists.Add(dungeonBowlTeams);
fullTeamLists.Add(allTeams);

//Console.WriteLine("Listing all teams.");
//handleTeam(chooseTeam(allTeams));

//this is currently set for Blood Bowl
//Options will be set up for Sevens at a later date
processTeamList(bloodBowlTeams);
//DO NOT UNCOMMENT EITHER OF THE LINES BELOW UNLESS YOU ARE EXTREMELY SURE YOU WANT TO GENERATE EVERY DUNGEON BOWL ROSTER: IT WILL TAKE HOURS
//processTeamList(dungeonBowlTeams);
//processTeamList(allTeams);
char choice;
Console.ReadKey();


Team chooseTeam(List<Team> teamList)
{
    int i = 1;
    foreach (Team t in teamList)
    {
        Console.Write(i);
        Console.Write(". ");
        Console.WriteLine(t.name);
        i++;
    }
    int chosenTeam = 0;
    while (chosenTeam < 1)
    {
        Console.WriteLine("Enter a number corresponding to a team.");
        string input = Console.ReadLine();
        int number;
        if (Int32.TryParse(input, out number))
        {
            chosenTeam = number;
        }
    }
    return teamList[chosenTeam - 1];
}



void processTeamList(List<Team> teams)
{
    foreach(Team t in teams)
    {
        handleTeam(t);
        Console.WriteLine("END OF TEAM\n");
    }
    foreach(TeamAndRate team in TeamHolder.teamSuccessRates)
    {
        Console.WriteLine($"{team.TeamName} had a {team.SuccessRate}% rate of allowable rosters: {team.numSuccesses} out of {team.totalRosters}. ");
    }
    Console.WriteLine("END OF FILE");
   
}

static BigInteger getCombinationsFromTestTeam(Team testTeam)
{
    BigInteger combinations = 1;
    foreach (Position p in testTeam.positions)
    {
        BigInteger thisMany = TestFunctions.MultiChooseSum(p.maximumPlayers, p.players.Count);
        combinations *= thisMany;
    }

    //Console.WriteLine($"Total Player Combinations: {combinations.ToString()}");
    return combinations;
}


void handleTeam(Team currentTeam)
{
    activeTeam = currentTeam;
    TeamHolder.TeamName = currentTeam.name;
    TeamHolder.acceptableRosters = 0;
    BigInteger potentialRosterCount = getCombinationsFromTestTeam(currentTeam);
    TeamHolder.totalRosters = potentialRosterCount;
    Console.WriteLine($"Considering all rosters for {currentTeam.name}. There are {potentialRosterCount} potential rosters.\n");
    List<List<List<Player>>> bigList = FullCombinations(currentTeam);
    int rosterCount = (int)potentialRosterCount;
    mapIterateCombinations(bigList, rosterCount);
    DateTime currentTime = DateTime.Now;
    Console.WriteLine($"Current Time: {currentTime}");
    Console.WriteLine($"Acceptable Rosters: {TeamHolder.acceptableRosters}. Total Rosters Considered: {TeamHolder.totalRosters}");
    decimal ratio = (decimal)TeamHolder.acceptableRosters / (decimal)TeamHolder.totalRosters;
    ratio *= 100;
    ratio = Math.Round(ratio, 2);
    Console.WriteLine($"{ratio}% of potential rosters are acceptable.");
    TeamAndRate tandr = new TeamAndRate();
    tandr.TeamName = currentTeam.name;
    tandr.SuccessRate = ratio;
    tandr.numSuccesses = TeamHolder.acceptableRosters;
    tandr.totalRosters = TeamHolder.totalRosters;
    TeamHolder.teamSuccessRates.Add(tandr);
}

void handleTeamSevens(Team currentTeam)
{
    activeTeam = currentTeam;
    TeamHolder.TeamName = currentTeam.name;
    TeamHolder.acceptableRosters = 0;
    BigInteger potentialRosterCount = getCombinationsFromTestTeam(currentTeam);
    TeamHolder.totalRosters = potentialRosterCount;
    Console.WriteLine($"Considering all rosters for {currentTeam.name}. There are {potentialRosterCount} potential rosters.\n");
    List<List<List<Player>>> bigList = FullCombinations(currentTeam);
    int rosterCount = (int)potentialRosterCount;
    mapIterateSevensCombinations(bigList, rosterCount);
    DateTime currentTime = DateTime.Now;
    Console.WriteLine($"Current Time: {currentTime}");
    Console.WriteLine($"Acceptable Rosters: {TeamHolder.acceptableRosters}. Total Rosters Considered: {TeamHolder.totalRosters}");
    decimal ratio = (decimal)TeamHolder.acceptableRosters / (decimal)TeamHolder.totalRosters;
    ratio *= 100;
    ratio = Math.Round(ratio, 2);
    Console.WriteLine($"{ratio}% of potential rosters are acceptable.");
    TeamAndRate tandr = new TeamAndRate();
    tandr.TeamName = currentTeam.name;
    tandr.SuccessRate = ratio;
    tandr.numSuccesses = TeamHolder.acceptableRosters;
    tandr.totalRosters = TeamHolder.totalRosters;
    TeamHolder.teamSuccessRates.Add(tandr);
}



static List<List<List<Player>>> FullCombinations(Team testTeam)
{
    List<List<List<Player>>> comblist = new List<List<List<Player>>>();
    foreach (Position pos in testTeam.positions)
    {
        List<List<Player>> posCombList = new List<List<Player>>();
        for (int i = 0; i <= pos.maximumPlayers; i++)
        {
            List<List<Player>> combinations = GenerateMultichooseCombinations(pos.players, i);
            posCombList.AddRange(combinations);
        }
        comblist.Add(posCombList);
    }
    return comblist;
}


void mapIterateCombinations(List<List<List<Player>>> combinations, int combinationCount)
{
    int combLen = combinations.Count;
    int totalCombinations = 1;

    // Calculate the total number of combinations
    foreach (List<List<Player>> position in combinations)
    {
        totalCombinations *= position.Count;
    }

    for (int i = 0; i < combinationCount; i++)
    {
        int iteratorHolder = i;
        List<List<Player>> thisCombination = new List<List<Player>>();

        foreach (List<List<Player>> position in combinations)
        {
            int posLen = position.Count;
            int index = iteratorHolder % posLen;
            thisCombination.Add(position[index]);

            // Update iteratorHolder for the next position list
            iteratorHolder /= posLen;
        }

        ConsiderRoster(thisCombination);
    }
}

void mapIterateSevensCombinations(List<List<List<Player>>> combinations, int combinationCount)
{
    int combLen = combinations.Count;
    int totalCombinations = 1;

    // Calculate the total number of combinations
    foreach (List<List<Player>> position in combinations)
    {
        totalCombinations *= position.Count;
    }

    for (int i = 0; i < combinationCount; i++)
    {
        int iteratorHolder = i;
        List<List<Player>> thisCombination = new List<List<Player>>();

        foreach (List<List<Player>> position in combinations)
        {
            int posLen = position.Count;
            int index = iteratorHolder % posLen;
            thisCombination.Add(position[index]);

            // Update iteratorHolder for the next position list
            iteratorHolder /= posLen;
        }

        ConsiderSevensRoster(thisCombination);
    }
}

void ConsiderRoster(List<List<Player>> singularPositionCombination)
{
    Roster TestRost = new Roster(startingValue);
    TestRost.raceOrCollege = activeTeam;
    foreach (List<Player> posList in singularPositionCombination)
    {
        foreach (Player player in posList)
        {
            TestRost.AddPlayer(player);
        }
    }

    //Uncomment this and comment the line below it to skip to the success stats
    //TestRost.quietlyCheckRoster();
    TestRost.ShowVerifiedRoster();
}

void ConsiderSevensRoster(List<List<Player>> singularPositionCombination)
{
    Roster TestRost = new Roster(startingValue);
    TestRost.raceOrCollege = activeTeam;
    foreach (List<Player> posList in singularPositionCombination)
    {
        foreach (Player player in posList)
        {
            TestRost.AddPlayer(player);
        }
    }

    //Uncomment this and comment the line below it to skip to the success stats
    //TestRost.quietlyCheckRoster();
    TestRost.ShowVerifiedSevensRoster();
}


static List<List<Player>> GenerateMultichooseCombinations(List<Player> players, int r)
{
    List<List<Player>> combinations = new List<List<Player>>();
    List<Player> currentCombination = new List<Player>();

    GenerateCombinationsHelper(players, r, 0, currentCombination, combinations);

    return combinations;
}

static void GenerateCombinationsHelper(List<Player> players, int r, int startIndex, List<Player> currentCombination, List<List<Player>> combinations)
{
    if (r == 0)
    {
        combinations.Add(new List<Player>(currentCombination));
        return;
    }

    for (int i = startIndex; i < players.Count; i++)
    {
        currentCombination.Add(players[i]);
        GenerateCombinationsHelper(players, r - 1, i, currentCombination, combinations);
        currentCombination.RemoveAt(currentCombination.Count - 1); // Backtrack
    }
}

public class TeamAndRate
{
    public string TeamName;
    public BigInteger numSuccesses;
    public BigInteger totalRosters;
    public decimal SuccessRate;
}
//A Blood/Dungeon Bowl team is comprised of players. For the sake of this program, players consist of two values: name and price.
public class Player
{
    public string name;
    public int cost;
    public int realCost;
    public Player(string playerName, int playerCost)
    {
        name = playerName;
        cost = playerCost;
        realCost = playerCost;

    }
    public Player(string playerName, int playerCost, int actCost)
    {
        name = playerName;
        cost = playerCost;
        realCost = actCost;
    }
    public string Summary()
    {
        string summ = $"{name}: {cost}";
        return summ;
    }

    bool isLino()
    {
        if (this.name.EndsWith("Lineman") || this.name.EndsWith("Linewoman"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
//Each position contains a list of players, a maximum number of players in that position, and, for the sake of avoiding int to BigInteger conversion, a count of the number of options.
//This is not as expandable as I'd like, but I think it's a better option right now.
public class Position
{
    public string name;
    public Position(string positionName, int maxPlayers)
    {
        name = positionName;
        maximumPlayers = maxPlayers;
        players = new List<Player>();
    }
    public int maximumPlayers;
    public List<Player> players;

}
//Each team has a name, a cost for rerolls, and a list of positions.
public class Team
{
    public string name;
    public int rerollValue;
    public List<Position> positions;
    public bool apothecary = false;
    public Team(string collegeName, int rerollCost)
    {
        name = collegeName;
        rerollValue = rerollCost;
        positions = new List<Position>();
    }
    //this constructor is for Blood Bowl Teams, that may include an apothecary.
    public Team(string raceName, int rerollCost, bool apo)
    {
        name = raceName;
        rerollValue = rerollCost;
        positions = new List<Position>();
        apothecary = apo;
    }
}

//A blood bowl league begins with every player filling out their starting roster.
//Constraints: 11-16 players, 1 million gold starting budget.
public class Roster
{
    int startingBudget;
    //Teams in Blood/Dungeon Bowl are chosen from race or wizard college lists, depending on the game.
    //For the purposes of this program, we list it at the top of the roster for clarity's sake.
    //All other calculations with it have already been made.
    public Team raceOrCollege;
    //player count must be within 11-16, inclusive
    public int playerCount;
    //BigInteger was chosen possibly incorrectly, but it can possibly be pared down to int later. This must not exceed one million.
    public int value;
    public int cost;
    //zero to eight rerolls. Each has a value between 50000 and 70000.
    public int rerolls;

    public Roster()
    {
        players = new List<Player>();
        playerCount = 0;
        value = 0;
        cost = 0;

        raceOrCollege = new Team("Whichever", 50000);
    }
    public Roster(int budget)
    {
        startingBudget = budget;
        players = new List<Player>();
        playerCount = 0;
        value = 0;
        cost = 0;

        raceOrCollege = new Team("Whichever", 50000);
    }
    //A roster is a list of players. At this point, we're looking at fresh, completely unremarkable nameless unnumbered rookies.
    public List<Player> players;
    public void AddPlayer(Player p)
    {
        players.Add(p);

        value += p.realCost;
        cost += p.cost;
        playerCount++;
    }
    //checkIfValid determines if a roster is acceptable under the above constraints.
    //To reiterate: 11-16 players, value <= 1 million gold pieces.
    public Roster(Team race)
    {
        raceOrCollege = race;
        players = new List<Player>();
    }
    //This function is a duct tape solution. 
    //Chaos Renegades are the only team out of about 35 that have a restriction of 0-1 on a specific player, and a further restriction on the number of players in that category in a position;
    //We check if the team is Chaos Renegades. If it is, we iterate through the list of players, and count the number of Renegade {Big Guys}.
    //If it is four, the roster is unacceptable.
    bool tooManyBigGuys()
    {
        int bigGuySum = 0;
        if (this.raceOrCollege.name != "Chaos Renegades")
        {
            return false;
        }
        foreach (Player p in this.players)
        {
            if (p.name == "Renegade Troll" || p.name == "Renegade Ogre" || p.name == "Renegade Minotaur" || p.name == "Renegade Rat Ogre")
            {
                bigGuySum++;
            }
        }
        if (bigGuySum == 4)
        {
            return true;
        }
        return false;
    }
    bool sevensTooManyPositionals()
    {
        int count = 0;
        foreach (Player p in this.players)
        {
            if (p.IsLino == false)
            {
                count++;
            }
        }
        if (count > 5)
        {
            return true;
        }
        return false;
    }
    //A roster is valid if the following conditions are true:
    //It has more than ten players.
    //It has fewer than 17 players.
    //Its cost does not exceed the starting budget (typically 1 million).
    //It does not contain all of the following: Renegade Troll, Renegade Ogre, Renegade Minotaur, and Renegade Rat Ogre.
    //The last condition does not come up often.
    public bool checkIfValid()
    {


        if (this.playerCount > 16 || this.playerCount < 11 || this.value > startingBudget || this.tooManyBigGuys())
        {
            return false;
        }
        return true;
    }
    public bool checkIfSevensValid()
    {

        if (this.playerCount > 11 || this.playerCount < 7 || this.value > sevensStartingValue || this.tooManyBigGuys() || this.sevensPositionalCheck())
        {
            return false;
        }
        return true;
    }
    //This function has a call commented out elsewhere, solely to hasten generating team stats.
    public void quietlyCheckRoster()
    {
        if (checkIfValid())
        {
            TeamHolder.acceptableRosters++;
        }
    }
    //This is almost a toString for rosters, if they're acceptable.
    //I'm writing things to a file via stdout right now.
    public void ShowVerifiedRoster()
    {
        if (checkIfValid())
        {
            TeamHolder.acceptableRosters++;
            Console.WriteLine("Acceptable Roster:");
            Console.Write(GetRoster());
            Console.WriteLine($"Pre-reroll team cost: {cost.ToString()}");
            if(cost != value)
            {
                Console.WriteLine($"Adjusted Team Value: {value}");
            }
            int potentialRerolls = startingBudget - cost;
            double potrer = potentialRerolls / raceOrCollege.rerollValue;
            potentialRerolls = (int)Math.Floor(potrer);
            int leftoverCash = startingBudget - cost;
            if (leftoverCash >= 50000 && raceOrCollege.apothecary == true)
            {
                int apoLeftCash = leftoverCash -= 50000;
                double apoPotRer = apoLeftCash / raceOrCollege.rerollValue;
                int apoPotRerolls = (int)Math.Floor(apoPotRer);
                if (apoPotRerolls > 8)
                {
                    Console.WriteLine("You may only take 8 rerolls.");
                    apoPotRerolls = 8;
                }
                Console.WriteLine($"You may take an apothecary. If so, you may take up to {apoPotRerolls} rerolls.");
                apoLeftCash -= apoPotRerolls * raceOrCollege.rerollValue;
                if (apoLeftCash >= 10000)
                {
                    Console.WriteLine($"If you take the maximum number of rerolls, you can hire up to {apoLeftCash / 10000} dedicated fans, assistant coaches and cheerleaders.");
                }
            }
            if (potentialRerolls > 8)
            {
                Console.WriteLine("Budget exceeds 8 rerolls, maximum eight allowed.");
                potentialRerolls = 8;
            }
            Console.WriteLine($"Up to {potentialRerolls} rerolls.");
            int maxRerolls = potentialRerolls * raceOrCollege.rerollValue;
            if (leftoverCash - maxRerolls >= 10000)
            {
                Console.WriteLine($"Assuming no apothecary, if you take the maximum number of rerolls, you may hire up to {(leftoverCash - maxRerolls) / 10000} dedicated fans, assistant coaches, or cheerleaders.");
            }
            Console.WriteLine("\n");
        }
        else
        {
            //Console.WriteLine($"Unacceptable Roster: Value: {value}. Players: {playerCount}\n");
        }
    }
    public void ShowVerifiedSevensRoster()
    {
        if (checkIfSevensValid())
        {
            TeamHolder.acceptableRosters++;
            Console.WriteLine("Acceptable Roster:");
            Console.Write(GetRoster());
            Console.WriteLine($"Pre-reroll team cost: {cost.ToString()}");
            if (cost != value)
            {
                Console.WriteLine($"Adjusted Team Value: {value}");
            }
            int potentialRerolls = (startingBudget - cost)/2;
            double potrer = potentialRerolls / raceOrCollege.rerollValue;
            potentialRerolls = (int)Math.Floor(potrer);
            int leftoverCash = startingBudget - cost;
            if (leftoverCash >= 50000 && raceOrCollege.apothecary == true)
            {
                int apoLeftCash = leftoverCash -= 50000;
                double apoPotRer = apoLeftCash / raceOrCollege.rerollValue;
                int apoPotRerolls = (int)Math.Floor(apoPotRer);
                if (apoPotRerolls > 8)
                {
                    Console.WriteLine("You may only take 8 rerolls.");
                    apoPotRerolls = 8;
                }
                Console.WriteLine($"You may take an apothecary. If so, you may take up to {apoPotRerolls} rerolls.");
                apoLeftCash -= apoPotRerolls * raceOrCollege.rerollValue;
                if (apoLeftCash >= 10000)
                {
                    Console.WriteLine($"If you take the maximum number of rerolls, you can hire up to {apoLeftCash / 10000} dedicated fans, assistant coaches and cheerleaders.");
                }
            }
            if (potentialRerolls > 8)
            {
                Console.WriteLine("Budget exceeds 8 rerolls, maximum eight allowed.");
                potentialRerolls = 8;
            }
            Console.WriteLine($"Up to {potentialRerolls} rerolls.");
            int maxRerolls = potentialRerolls * raceOrCollege.rerollValue;
            if (leftoverCash - maxRerolls >= 10000)
            {
                Console.WriteLine($"Assuming no apothecary, if you take the maximum number of rerolls, you may hire up to {(leftoverCash - maxRerolls) / 10000} dedicated fans, assistant coaches, or cheerleaders.");
            }
            Console.WriteLine("\n");
        }
        else
        {
            //Console.WriteLine($"Unacceptable Roster: Value: {value}. Players: {playerCount}\n");
        }
    }

    public void ShowVerifiedGutterRoster()
    {
        if (checkIfSevensValid())
        {
            TeamHolder.acceptableRosters++;
            Console.WriteLine("Acceptable Roster:");
            Console.Write(GetRoster());
            Console.WriteLine($"Pre-reroll team cost: {cost.ToString()}");
            if (cost != value)
            {
                Console.WriteLine($"Adjusted Team Value: {value}");
            }
            int potentialRerolls = (startingBudget - cost) / 2;
            double potrer = potentialRerolls / 100000;
            potentialRerolls = (int)Math.Floor(potrer);
            int leftoverCash = startingBudget - cost;
            if (leftoverCash >= 50000 && raceOrCollege.apothecary == true)
            {
                int apoLeftCash = leftoverCash -= 50000;
                double apoPotRer = apoLeftCash / raceOrCollege.rerollValue;
                int apoPotRerolls = (int)Math.Floor(apoPotRer);
                if (apoPotRerolls > 8)
                {
                    Console.WriteLine("You may only take 8 rerolls.");
                    apoPotRerolls = 8;
                }
                Console.WriteLine($"You may take an apothecary. If so, you may take up to {apoPotRerolls} rerolls.");
                apoLeftCash -= apoPotRerolls * raceOrCollege.rerollValue;
                if (apoLeftCash >= 10000)
                {
                    Console.WriteLine($"If you take the maximum number of rerolls, you can hire up to {apoLeftCash / 10000} dedicated fans, assistant coaches and cheerleaders.");
                }
            }
            if (potentialRerolls > 8)
            {
                Console.WriteLine("Budget exceeds 8 rerolls, maximum eight allowed.");
                potentialRerolls = 8;
            }
            Console.WriteLine($"Up to {potentialRerolls} rerolls.");
            int maxRerolls = potentialRerolls * raceOrCollege.rerollValue;
            if (leftoverCash - maxRerolls >= 10000)
            {
                Console.WriteLine($"Assuming no apothecary, if you take the maximum number of rerolls, you may hire up to {(leftoverCash - maxRerolls) / 10000} dedicated fans, assistant coaches, or cheerleaders.");
            }
            Console.WriteLine("\n");
        }
        else
        {
            //Console.WriteLine($"Unacceptable Roster: Value: {value}. Players: {playerCount}\n");
        }
    }
    //This might as well be a toString for rosters.
    public string GetRoster()
    {
        string outputstr = "";
        foreach (Player p in players)
        {
            outputstr += p.Summary();
            outputstr += "\n";
        }
        return outputstr;
    }

}

public static class TestFunctions
{
    //This sums up MultiChoose calls, with the same number of options, but starting from zero draws and ending at maxValue.
    public static BigInteger MultiChooseSum(BigInteger maxValue, BigInteger options)
    {
        BigInteger result = 0;
        for (BigInteger i = 0; i <= maxValue; i++)
        {
            result += MultiChoose(i, options);
        }
        return result;
    }
    //I rolled my own factorial function, expect this to be replaced with something faster.
    public static BigInteger LazyFactorial(BigInteger target)
    {
        BigInteger result = 1;
        for (BigInteger i = 1; i <= target; i++)
        {
            result *= i;
        }
        return result;
    }
    //Implementation of this: https://www.calculatorsoup.com/calculators/discretemathematics/combinationsreplacement.php
    //We choose $sample discrete items from $objects potential options, replacing after each draw.
    //CRITICALLY IMPORTANT: order does not matter. 
    public static BigInteger MultiChoose(BigInteger sample, BigInteger objects)
    {
        BigInteger numerator = LazyFactorial(sample + objects - 1);
        BigInteger denominator = LazyFactorial(sample) * LazyFactorial(objects - 1);
        return numerator / denominator;
    }
}
public static class TeamHolder
{
    public static string TeamName;
    public static BigInteger acceptableRosters;
    public static BigInteger totalRosters;
    public static List<TeamAndRate> teamSuccessRates = new List<TeamAndRate>();
}