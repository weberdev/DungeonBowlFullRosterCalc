using System;
using System.Numerics;
BigInteger invalidRosterCount = 0;
Console.WriteLine("Greetings, sports fans!");
//testing information for College of Metal Team
defineTestTeam();

static void defineTestTeam()
{

    Console.WriteLine("Filling college of metal team roster.");
    Player orcLino = new Player("Orc Lineman", 50000);
    Player humanLino = new Player("Human Lineman", 50000);
    Player goblinBruiserLino = new Player("Goblin Bruiser Lineman", 45000);
    Position linos = new Position("Linemen", 16, 3);
    linos.players.Add(orcLino);
    linos.players.Add(humanLino);
    linos.players.Add(goblinBruiserLino);

    Player orcBlitz = new Player("Orc Blitzer", 80000);
    Player humanBlitz = new Player("Human Blitzer", 85000);
    Position blitzers = new Position("Blitzers", 4, 2);
    blitzers.players.Add(orcBlitz);
    blitzers.players.Add(humanBlitz);

    Player orcThrow = new Player("Orc Thrower", 65000);
    Position throwers = new Position("Throwers", 2, 1);
    throwers.players.Add(orcThrow);

    Player blackOrc = new Player("Black Orc", 90000);
    Player bigUn = new Player("Big Un Blocker", 90000);
    Player bodyguard = new Player("Bodyguard", 90000);
    Player bloodseeker = new Player("Bloodseeker", 110000);
    Position blockers = new Position("Blockers", 6, 4);
    blockers.players.Add(bodyguard);
    blockers.players.Add(bigUn);
    blockers.players.Add(bloodseeker);
    blockers.players.Add(blackOrc);
    Team metal = new Team("College of Metal", 50000);
    metal.positions.Add(linos);
    metal.positions.Add(blockers);
    metal.positions.Add(blitzers);
    metal.positions.Add(throwers);
    List<List<List<Player>>> allCombinations = FullCombinations(metal);
    EveryCombination(allCombinations);
    
}

static List<List<List<Player>>> FullCombinations(Team testTeam)
{
    List<List<List<Player>>> comblist = new List<List<List<Player>>>();
    foreach (Position pos in testTeam.positions)
    {
        Console.WriteLine($"Adding Position: {pos.name} to the list.");
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

static void EveryCombination(List<List<List<Player>>> combinations)
{
    List<List<Player>> currentCombination = new List<List<Player>>();
    IterateCombinations(combinations, 0, currentCombination);
}

static void IterateCombinations(List<List<List<Player>>> combinations, int positionIndex, List<List<Player>> currentCombination)
{
    if (positionIndex == combinations.Count)
    {
        // We have reached the end of the positions, so call ConsiderRoster
        ConsiderRoster(currentCombination);
        return;
    }

    List<List<Player>> positionOptions = combinations[positionIndex];

    foreach (List<Player> option in positionOptions)
    {
        // Add the current position option to the current combination
        currentCombination.Add(option);

        // Recursively call the function for the next position
        IterateCombinations(combinations, positionIndex + 1, currentCombination);

        // Remove the current position option to backtrack
        currentCombination.RemoveAt(currentCombination.Count - 1);
    }
}


static void ConsiderRoster(List<List<Player>> singularPositionCombination)
{
    Roster TestRost = new Roster();
    foreach (List<Player> posList in singularPositionCombination) {
        foreach (Player player in posList)
        {
            TestRost.AddPlayer(player);
        }
    }
    TestRost.ShowVerifiedRoster();
    //Console.WriteLine(TestRost.GetRoster());
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


//A Blood/Dungeon Bowl team is comprised of players. For the sake of this program, players consist of two values: name and price.
public class Player { 
    public string name;
    public int cost;
    public Player(string playerName, int playerCost)
    {
        name = playerName;
        cost = playerCost;
    }

    public string Summary()
    {
        string summ = $"{name}: {cost}";
        return summ;
    }
}
//Each position contains a list of players, a maximum number of players in that position, and, for the sake of avoiding int to BigInteger conversion, a count of the number of options.
//This is not as expandable as I'd like, but I think it's a better option right now.
public class Position
{
    public string name;
    public Position(string positionName, int maxPlayers, int numTypes)
    {
        name=positionName;
        maximumPlayers=maxPlayers;
        numberOfPlayerTypes=numTypes;
        players = new List<Player>();
    }
    public int maximumPlayers;
    public int numberOfPlayerTypes;
    public List<Player> players;

}
//Each team has a name, a cost for rerolls, and a list of positions.
public class Team
{ string name;
    public int rerollValue;
  public List<Position> positions;
    public Team (string collegeName, int rerollCost)
    {
        name=collegeName;
        rerollValue= rerollCost;
        positions = new List<Position>();
    }
}

//A blood bowl league begins with every player filling out their starting roster.
//Constraints: 11-16 players, 1 million gold starting budget.
public class Roster
{
    //Teams in Blood/Dungeon Bowl are chosen from race or wizard college lists, depending on the game.
    //For the purposes of this program, we list it at the top of the roster for clarity's sake.
    //All other calculations with it have already been made.
    Team raceOrCollege;
    //player count must be within 11-16, inclusive
    public int playerCount;
    //BigInteger was chosen possibly incorrectly, but it can possibly be pared down to int later. This must not exceed one million.
    public int value;
    //zero to eight rerolls. Each has a value between 50000 and 70000.
    public int rerolls;
    public Roster()
    {
        players = new List<Player>();
        playerCount = 0;
        value = 0;
        raceOrCollege = new Team("Whichever", 50000);
    }
    //A roster is a list of players. At this point, we're looking at fresh, completely unremarkable nameless unnumbered rookies.
    public List<Player> players;
    public void AddPlayer(Player p)
    {
        players.Add(p);
        value += p.cost;
        playerCount++;
    }
    //checkIfValid determines if a roster is acceptable under the above constraints.
    //To reiterate: 11-16 players, value <= 1 million gold pieces.
    public Roster(Team raceOrCollege) {
        players = new List<Player>();
    }

    public Roster(Roster clonedRoster)
    {
        players = new List<Player>();
        Roster clone = clonedRoster;
    }
    public bool checkIfValid()
    {
        //commented out value prevents team value scumming, albeit imperfectly
        if (this.playerCount > 16 || this.playerCount < 11 || this.value > 1000000 /*|| this.value <= 950000*/)
        {
            return false;
        }
        return true;
    }

    public void ShowVerifiedRoster()
    {
        if (checkIfValid()){
            Console.WriteLine("Acceptable Roster:");
            Console.Write(GetRoster());
            Console.WriteLine(value.ToString());
            int potentialRerolls = 1000000 - value;
            double potrer = potentialRerolls / raceOrCollege.rerollValue;
            potentialRerolls = (int)Math.Floor(potrer);
            Console.WriteLine($"Up to {potentialRerolls} rerolls. \n \n");
        }
        else
        {
           Console.WriteLine($"Unacceptable Roster: Value: {value}. Players: {playerCount}\n");
        }
    }

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
    public void MergeRosters(Roster addedRoster) {
        foreach (Player plyr in addedRoster.players)
        {
            this.AddPlayer(plyr);
        }
    }
}

public static class TestFunctions
{
    //This sums up MultiChoose calls, with the same number of options, but starting from zero draws and ending at maxValue.
    public static BigInteger MultiChooseSum (BigInteger maxValue, BigInteger options)
    {
        BigInteger result = 0;
        for (BigInteger i = 0; i <= maxValue; i++)
        {
            result+=MultiChoose(i, options);
        }
        return result;
    }
    //I rolled my own factorial function, expect this to be replaced with something faster.
    public static BigInteger LazyFactorial(BigInteger target)
    {
        BigInteger result = 1;
        for(BigInteger i = 1; i <= target; i++)
        {
            result *=  i;
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