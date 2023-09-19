using System;
using System.Numerics;

Console.WriteLine("Greetings, sports fans!");
//testing information for College of Metal Team
defineAllTeams();

static void defineAllTeams()
{
    List<Team> Teams = new List<Team>();

    Player dwarfLino = new Player("Dwarf Lineman", 70000);
    Player gnoblarLino = new Player("Gnoblar Lineman", 15000);
    Player bloodbornLino = new Player("Bloodborn Marauder", 50000);
    Position firelinos = new Position("Linemen", 16, 3);
    firelinos.players.Add(dwarfLino);
    firelinos.players.Add(gnoblarLino);
    firelinos.players.Add(bloodbornLino);
    Player dwarfRunner = new Player("Dwarf Runner", 85000);
    Position fireRunners = new Position("Runners", 2, 1);
    fireRunners.players.Add(dwarfRunner);
    Player trollSlayer = new Player("Trollslayer", 95000);
    Position fireblitzers = new Position("Blitzers", 2, 1);
    fireblitzers.players.Add(trollSlayer);
    Player ogreBlocker = new Player("Ogre Blocker", 140000);
    Player ogreRuntPunter = new Player("Ogre Runt Punter", 145000);
    Position fireBigGuys = new Position("Big Guys", 3, 2);
    fireBigGuys.players.Add(ogreBlocker);
    fireBigGuys.players.Add(ogreRuntPunter);
    Team fire = new Team("College of Fire", 50000);
    fire.positions.Add(fireBigGuys);
    fire.positions.Add(fireblitzers);
    fire.positions.Add(firelinos);
    fire.positions.Add(fireRunners);
    Teams.Add(fire);

    Position shadowLinos = new Position("Linemen", 16, 3);
    //not that kind
    Position shadowRunners = new Position("Runners", 4, 2);
    Position shadowBlitzers = new Position("Blitzers", 2, 2);
    Position shadowThrowers = new Position("Throwers", 2, 1);
    Position shadowSpecial = new Position("Special", 2, 2);
    Player darkElfLino = new Player("Dark Elf Lineman", 70000);
    Player skavenLino = new Player("Skaven Lineman", 50000);
    Player goblinLino = new Player("Goblin Lineman", 40000);
    shadowLinos.players.Add(darkElfLino);
    shadowLinos.players.Add(skavenLino);
    shadowLinos.players.Add(goblinLino);
    Player gutterRunner = new Player("Gutter Runner", 85000);
    Player darkElfRunner = new Player("Dark Elf Runner", 80000);
    shadowRunners.players.Add(gutterRunner);
    shadowRunners.players.Add(darkElfRunner);
    Player darkElfBlitzer = new Player("Dark Elf Blitzer", 100000);
    Player skavenBlitzer = new Player("Skaven Blitzer", 90000);
    shadowBlitzers.players.Add(darkElfBlitzer);
    shadowBlitzers.players.Add(skavenBlitzer);
    Player skavenThrower = new Player("Skaven Thrower", 85000);
    shadowThrowers.players.Add(skavenThrower);
    Player witchElf = new Player("Witch Elf", 110000);
    Player assassin = new Player("Assassin", 85000);
    shadowSpecial.players.Add(assassin);
    shadowSpecial.players.Add(witchElf);
    Team shadow = new Team("College of Shadow", 50000);
    shadow.positions.Add(shadowLinos);
    shadow.positions.Add(shadowRunners);
    shadow.positions.Add(shadowThrowers);
    shadow.positions.Add(shadowBlitzers);
    shadow.positions.Add(shadowSpecial);
    Teams.Add(shadow);

    Position lightLinos = new Position("Linemen", 16, 2);
    Position lightRunners = new Position("Runners", 4, 2);
    Position lightBlitzers = new Position("Blitzers", 2, 1);
    Position lightThrowers = new Position("Throwers", 2, 2);
    Player unionLineman = new Player("Union Lineman", 60000);
    Player imperialLineman = new Player("Imperial Lineman", 45000);
    lightLinos.players.Add(unionLineman);
    lightLinos.players.Add(imperialLineman);
    Player unionCatcher = new Player("Union Catcher", 10000);
    Player humanCatcher = new Player("Human Catcher", 60000);
    lightRunners.players.Add(unionCatcher);
    lightRunners.players.Add(humanCatcher);
    Player unionBlitzer = new Player("Union Blitzer", 115000);
    lightBlitzers.players.Add(unionBlitzer);
    Player unionThrower = new Player("Union Thrower", 75000);
    Player imperialThrower = new Player("Imperial Thrower", 75000);
    lightThrowers.players.Add(unionThrower);
    lightThrowers.players.Add(imperialThrower);
    Team light = new Team("College of Light", 50000);
    light.positions.Add(lightBlitzers);
    light.positions.Add(lightThrowers);
    light.positions.Add(lightLinos);
    light.positions.Add(lightBlitzers);
    Teams.Add(light);
    
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
    Teams.Add(metal);

    Team death = new Team("College of Death", 50000);
    Position deathLinos = new Position("Linemen", 16, 2);
    Player zombieLineman = new Player("Zombie Lineman", 40000);
    Player skeletonLineman = new Player("Skeleton Lineman", 40000);
    deathLinos.players.Add(skeletonLineman);
    deathLinos.players.Add(zombieLineman);
    death.positions.Add(deathLinos);
    Position deathRunners = new Position("Runners", 2, 1);
    Player ghoulRunner = new Player("Ghoul Runner", 75000);
    deathRunners.players.Add(ghoulRunner);
    Position deathBlitzers = new Position("Blitzers", 4, 2);
    Position deathBlockers = new Position("Blockers", 4, 1);
    Position deathBigGuys = new Position("Big Guys", 2, 1);
    Player wightBlitzer = new Player("Wight Blitzer", 90000);
    Player wraith = new Player("Wraith", 95000);
    Player fleshGolem = new Player("Flesh Golem", 115000);
    Player mummy = new Player("Mummy", 125000);
    deathBlitzers.players.Add(wraith);
    deathBlitzers.players.Add(wightBlitzer);
    deathBigGuys.players.Add(mummy);
    deathBlockers.players.Add(fleshGolem);
    death.positions.Add(deathBlitzers);
    death.positions.Add(deathRunners);
    death.positions.Add(deathBlockers);
    death.positions.Add(deathBigGuys);
    Teams.Add(death);

    Team life = new Team("College of Life", 50000);
    Position lifeLinemen = new Position("Linemen", 16, 4);
    Position lifeRunners = new Position("Runners", 4, 3);
    Position lifeBlitzers = new Position("Blitzers", 2, 1);
    Position lifeThrowers = new Position("Throwers", 2, 1);
    Position lifeBlockers = new Position("Blockers", 4, 2);
    Position lifeSpecial = new Position("Special", 4, 2);
    Position lifeBigGuys = new Position("Big Guys", 2, 3);
    Player halflingLineman = new Player("Halfling Hopeful Lineman", 30000);
    Player rotterLineman = new Player("Rotter Lineman", 35000);
    Player snotlingLineman = new Player("Snotling Lineman", 15000);
    Player woodElfLineman = new Player("Wood Elf Lineman", 70000);
    lifeLinemen.players.Add(halflingLineman);
    lifeLinemen.players.Add(rotterLineman);
    lifeLinemen.players.Add(snotlingLineman);
    lifeLinemen.players.Add(woodElfLineman);
    life.positions.Add(lifeLinemen);
    Player stiltyRunna = new Player("Stilty Runna", 20000);
    Player halflingCatcher = new Player("Halfling Catcher", 55000);
    Player woodElfCatcher = new Player("Wood Elf Catcher", 90000);
    lifeRunners.players.Add(stiltyRunna);
    lifeRunners.players.Add(halflingCatcher);
    lifeRunners.players.Add(woodElfCatcher);
    life.positions.Add(lifeRunners);
    //take two
    Player wardancer = new Player("Wardancer", 125000);
    lifeBlitzers.players.Add(wardancer);
    life.positions.Add(lifeBlitzers);
    Player woodElfThrower = new Player("Wood Elf Thrower", 95000);
    lifeThrowers.players.Add(woodElfThrower);
    life.positions.Add(lifeThrowers);
    Player halflingHefty = new Player("Halfling Hefty", 50000);
    Player bloater = new Player("Bloater", 115000);
    lifeBlockers.players.Add(halflingHefty);
    lifeBlockers.players.Add(bloater);
    life.positions.Add(lifeBlockers);
    Player fungusFlinga = new Player("Fungus Flinga", 30000);
    Player funHoppa = new Player("Fun-hoppa", 20000);
    lifeSpecial.players.Add(fungusFlinga);
    lifeSpecial.players.Add(funHoppa);
    Player alternForestTreeman = new Player("Altern Forest Treeman", 120000);
    Player trainedTroll = new Player("Trained Troll", 115000);
    Player rotspawn = new Player("Rotspawn", 140000);
    lifeBigGuys.players.Add(trainedTroll);
    lifeBigGuys.players.Add(alternForestTreeman);
    lifeBigGuys.players.Add(rotspawn);
    life.positions.Add(lifeBigGuys);
    Teams.Add(life);

    Team beasts = new Team("College of Beasts", 50000);
    Position beastsLinos = new Position("Linemen", 16, 1);
    Position beastsRunners = new Position("Runners", 2, 1);
    Position beastsBlitzers = new Position("Blitzers", 4, 2);
    Position beastsBlockers = new Position("Blockers", 4, 2);
    Position beastsBigGuys = new Position("Big Guys", 3, 5);
    Position beastsSpecial = new Position("Special", 2, 1);
    Player beastmanLineman = new Player("Beastman Lineman", 60000);
    beastsLinos.players.Add(beastmanLineman);
    beasts.positions.Add(beastsLinos);
    Player werewolf = new Player("Werewolf", 125000);
    beastsRunners.players.Add(werewolf);
    beasts.positions.Add(beastsRunners);
    Player pestigor = new Player("Pestigor", 75000);
    Player khorngor = new Player("Khorngor", 60000);
    beastsBlitzers.players.Add(pestigor);
    beastsBlitzers.players.Add(khorngor);
    beasts.positions.Add(beastsBlitzers);
    Player chosenBlocker = new Player("Chosen Blocker", 100000);
    Player ulfwerener = new Player("Ulfwerener", 105000);
    beastsBlockers.players.Add(chosenBlocker);
    beastsBlockers.players.Add(ulfwerener);
    beasts.positions.Add(beastsBlockers);
    Player minotaur = new Player("Minotaur", 150000);
    beastsBigGuys.players.Add(minotaur);
    Player Kroxigor = new Player("Kroxigor", 140000);
    beastsBigGuys.players.Add(Kroxigor);
    Player ratOgre = new Player("Rat Ogre", 150000);
    beastsBigGuys.players.Add(ratOgre);
    Player bloodSpawn = new Player("Bloodspawn", 160000);
    beastsBigGuys.players.Add(bloodSpawn);
    Player yhetee = new Player("Yhetee", 140000);
    beastsBigGuys.players.Add(yhetee);
    beasts.positions.Add(beastsBigGuys);
    Player beerBoar = new Player("Beer Boar", 20000);
    beasts.positions.Add(beastsSpecial);
    Teams.Add(beasts);

    Team heavens = new Team("College of Heavens", 50000);
    Position heavensLino = new Position("Linemen", 16, 3);
    Position heavensBlitzers = new Position("Blitzers", 4, 3);
    Position heavensThrowers = new Position("Throwers", 4, 2);
    Position heavensBlockers = new Position("Blockers", 6, 2);
    Position heavensSpecial = new Position("Special", 2, 2);
    Player skinkLineman = new Player("Skink Lineman", 60000);
    heavensLino.players.Add(skinkLineman);
    Player norseRaiderLineMan = new Player("Norse Raider Lineman", 50000);
    heavensLino.players.Add(norseRaiderLineMan);
    Player eagleWarriorLinewoman = new Player("Eagle Warrior Linewoman", 50000);
    heavensLino.players.Add(eagleWarriorLinewoman);
    heavens.positions.Add(heavensLino);
    Player nobleBlitzer = new Player("Imperial Blitzer", 105000);
    heavensBlitzers.players.Add(nobleBlitzer);
    Player norseBerzerker = new Player("Norse Berzerker", 90000);
    heavensBlitzers.players.Add(norseBerzerker);
    Player pirahnaWarriorBlitzer = new Player("Piranha Warrior Blitzer", 90000);
    heavensBlitzers.players.Add(pirahnaWarriorBlitzer);
    heavens.positions.Add(heavensBlitzers);
    Player humanThrower = new Player("Human Thrower", 80000);
    heavensThrowers.players.Add(humanThrower);
    Player pythonWarriorThrower = new Player("Python Warrior Thrower", 75000);
    heavensThrowers.players.Add(pythonWarriorThrower);
    heavens.positions.Add(heavensThrowers);
    Player saurusBlocker = new Player("Saurus Blocker", 85000);
    heavensBlockers.players.Add(saurusBlocker);
    Player jaguarWarriorBlocker = new Player("Jaguar Warrior Blocker", 110000);
    heavensBlockers.players.Add(jaguarWarriorBlocker);
    heavens.positions.Add(heavensBlockers);
    Player chameleonSkink = new Player("Chameleon Skink", 70000);
    heavensSpecial.players.Add(chameleonSkink);
    Player valkyrie = new Player("Valkyrie", 95000);
    heavensSpecial.players.Add(valkyrie);
    heavens.positions.Add(heavensSpecial);
    Teams.Add(heavens);
    
    foreach(Team t in Teams)
    {
        handleTeam(t);
        Console.WriteLine("END OF TEAM");
    }

    Console.WriteLine("END OF FILE");

}

static void defineTestTeam()
{
    FullRosterStats stats = new FullRosterStats("College of Metal");
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
    Console.WriteLine("END OF FILE");
}
static BigInteger getCombinationsFromTestTeam(Team testTeam)
{
    BigInteger combinations = 1;
    foreach (Position p in testTeam.positions)
    {
        BigInteger thisMany = TestFunctions.MultiChooseSum(p.maximumPlayers, p.numberOfPlayerTypes);
        Console.WriteLine($"{p.name}: {thisMany}");
        combinations *= thisMany;
    }
    Console.WriteLine($"Total Player Combinations: {combinations.ToString()}");
    combinations *= 9;
    Console.WriteLine($"Total Player Combinations WITH rerolls: {combinations.ToString()}");
    return combinations;
}
static void getRostersFromTestTeam(Team testTeam)
{
    foreach (Position pos in testTeam.positions)
    {
        Console.WriteLine($"Combinations for {pos.name}:");
        for (int i = 0; i <= pos.maximumPlayers; i++)
        {
            List<List<Player>> combinations = GenerateMultichooseCombinations(pos.players, i);
            foreach (var combination in combinations)
            {
                // Create a roster with the combination of players
                Roster roster = new Roster(testTeam);
                foreach (Player player in combination)
                {
                    roster.AddPlayer(player);
                }
                Console.WriteLine($"Roster Value: {roster.value}");
                Console.WriteLine(roster.GetRoster());
            }
        }
    }
}

static void handleTeam(Team currentTeam)
{
    BigInteger potentialRosterCount = getCombinationsFromTestTeam(currentTeam);
    Console.WriteLine($"Considering all rosters for {currentTeam.name}");
    Console.WriteLine($"There are {potentialRosterCount.ToString()} potential rosters.");
    List<List<List<Player>>> bigList = FullCombinations(currentTeam); 
    EveryCombination(bigList);
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
{ public string name;
    public int rerollValue;
  public List<Position> positions;
    public bool apothecary = false;
    public Team (string collegeName, int rerollCost)
    {
        name=collegeName;
        rerollValue= rerollCost;
        positions = new List<Position>();
    }
    //this constructor is for Blood Bowl Teams, that may include an apothecary.
    public Team(string raceName, int rerollCost, bool apo)
    {
        name = raceName;
        rerollValue = rerollCost;
        positions=new List<Position>();
        apothecary = apo;
    }
}


public class FullRosterStats {
    string name;
    int attemptedRosters;
    int acceptableRosters;
    public FullRosterStats(string inputName)
    {
        name = inputName;
        attemptedRosters=0;
        acceptableRosters=0;
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
            if(potentialRerolls > 8)
            {
                Console.WriteLine("Budget exceeds 8 rerolls, maximum eight allowed.");
                potentialRerolls = 8;
            }
            Console.WriteLine($"Up to {potentialRerolls} rerolls. \n");
        }
        else
        {
           //Console.WriteLine($"Unacceptable Roster: Value: {value}. Players: {playerCount}\n");
        }
    }

    public void ShowBloodBowlRoster()
    {
        if (checkIfValid())
        {
            Console.WriteLine("Acceptable Roster:");
            Console.Write(GetRoster());
            Console.WriteLine(value.ToString());
            int leftoverCash = 1000000 - value; 
            double potrer = leftoverCash / raceOrCollege.rerollValue;
            int potentialRerolls = (int)Math.Floor(potrer);
            if (leftoverCash >= 50000 && raceOrCollege.apothecary == true)
            {
                int apoLeftCash = leftoverCash -= 50000;
                double apoPotRer = apoLeftCash / raceOrCollege.rerollValue;
                int apoPotRerolls = (int)Math.Floor(apoPotRer);
                Console.WriteLine($"You may take an apothecary. If so, you may take up to {apoPotRerolls} rerolls.");
                apoLeftCash -= apoPotRerolls / raceOrCollege.rerollValue;
                if (apoLeftCash >= 10000)
                {
                    Console.WriteLine($"If you take the maximum number, you can hire up to {apoLeftCash / 10000} dedicated fans, assistant coaches and cheerleaders.");
                }
            }
            leftoverCash = leftoverCash / raceOrCollege.rerollValue* potentialRerolls;
            
            Console.WriteLine($"Up to {potentialRerolls} rerolls.");
            Console.WriteLine($"If you take the maximum number, you may take on up to {leftoverCash / 10000} dedicated fans, assistant coaches or cheerleaders. \n");
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