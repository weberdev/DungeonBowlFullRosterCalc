using System;
using System.Numerics;

Console.WriteLine("Hello, sports fans!");
//testing information for College of Metal Team
static void defineTestTeam()
{
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
}

//A Blood/Dungeon Bowl team is comprised of players. For the sake of this program, players consist of two values: name and price.
public class Player { 
    string name;
    BigInteger cost;
    public Player(string playerName, BigInteger playerCost)
    {
        name = playerName;
        cost = playerCost;
    }
    string getName()
    {
        string outputstr = $"{name}";
        return outputstr;
    }
    string summary()
    {
        string outputstr = $"{name}: {cost}";
        return outputstr;
    }
}
//Each position contains a list of players, a maximum number of players in that position, and, for the sake of avoiding int to BigInteger conversion, a count of the number of options.
//This is not as expandable as I'd like, but I think it's a better option right now.
public class Position
{
    string name;
    public Position(string positionName, BigInteger maxPlayers, BigInteger numTypes)
    {
        name=positionName;
        maximumPlayers=maxPlayers;
        numberOfPlayerTypes=numTypes;
    }
    BigInteger maximumPlayers;
    BigInteger numberOfPlayerTypes;
    public List<Player> players;

}
//Each team has a name, a cost for rerolls, and a list of positions.
public class Team
{ string name;
    BigInteger rerollValue;
  public List<Position> positions;
    public Team (string collegeName, BigInteger rerollCost)
    {
        name=collegeName;
        rerollValue= rerollCost;
    }
}

//A blood bowl league begins with every player filling out their starting roster.
//Constraints: 11-16 players, 1 million gold starting budget.
public class roster
{
    //Teams in Blood/Dungeon Bowl are chosen from race or wizard college lists, depending on the game.
    //For the purposes of this program, we list it at the top of the roster for clarity's sake.
    //All other calculations with it have already been made.
    Team raceOrCollege;
    //player count must be within 11-16, inclusive
    int playerCount;
    //BigInteger was chosen possibly incorrectly, but it can possibly be pared down to int later. This must not exceed one million.
    BigInteger value;
    //zero to eight rerolls. Each has a value between 50000 and 70000.
    int rerolls;
    //A roster is a list of players. At this point, we're looking at fresh, completely unremarkable nameless unnumbered rookies.
    List<Player> players;
    //checkIfValid determines if a roster is acceptable under the above constraints.
    //To reiterate: 11-16 players, value <= 1 million gold pieces.

    bool checkIfValid()
    {
        //commented out value prevents team value scumming, albeit imperfectly
        if (this.playerCount > 16 || this.playerCount < 11 || this.value > 1000000 /*|| this.value <= 950000*/)
        {
            return false;
        }
        return true;
    }
    string toString()
    {
        string outputstr = $"Players: {playerCount} \n ";
        return outputstr;
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