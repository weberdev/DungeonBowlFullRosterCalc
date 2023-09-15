using System;
using System.Numerics;

Console.WriteLine("Hello, sports fans!");
//testing information for College of Metal Team
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
Team metal = new Team("College of Metal");
metal.positions.Add(linos);
metal.positions.Add(blockers);
metal.positions.Add(blitzers);
metal.positions.Add(throwers);


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

public class Team
{ string name;
  public List<Position> positions;
    public Team (string collegeName)
    {
        name=(collegeName);
    }
}

public class roster
{
    int playerCount;
    BigInteger value;
    int rerolls;
    List<Player> players;
    bool checkIfValid()
    {
        //commented out value prevents team value scumming, albeit imperfectly
        //we love our inducement abuse, don't we, folks?
        if (this.playerCount > 16 || this.playerCount < 11 || this.value > 1000000 /*|| this.value <= 950000*/)
        {
            return false;
        }
        else return true;
    }
    string toString()
    {
        string outputstr = $"Players: {playerCount} \n ";
        return outputstr;
    }
}

public static class TestFunctions
{
    public static BigInteger MultiChooseSum (BigInteger maxValue, BigInteger options)
    {
        BigInteger result = 0;
        for (BigInteger i = 0; i <= maxValue; i++)
        {
            result+=MultiChoose(i, options);
        }
        return result;
    }
    public static BigInteger LazyFactorial(BigInteger target)
    {
        BigInteger result = 1;
        for(BigInteger i = 1; i <= target; i++)
        {
            result *=  i;
        }
        return result;
    }
    public static BigInteger MultiChoose(BigInteger sample, BigInteger objects)
    {
        BigInteger numerator = LazyFactorial(sample + objects - 1);
        BigInteger denominator = LazyFactorial(sample) * LazyFactorial(objects - 1);
        return numerator / denominator;
    }
}   