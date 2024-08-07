using System.Numerics;
int startingValue = 1000000;

Team activeTeam = new Team("defaultTeam", 50000, false);
Console.WriteLine("Greetings, sports fans!\n");
List<Team> bloodBowlTeams = defineBloodBowlTeams();
List<Team> dungeonBowlTeams = defineDungeonBowlTeams();
List<Team> allTeams = dungeonBowlTeams.Concat(bloodBowlTeams).ToList();
bloodBowlTeams = bloodBowlTeams.OrderBy(team => team.name).ToList();
dungeonBowlTeams = dungeonBowlTeams.OrderBy(team => team.name).ToList();
List<List<Team>> fullTeamLists = new List<List<Team>>();
fullTeamLists.Add(bloodBowlTeams);
fullTeamLists.Add(dungeonBowlTeams);
fullTeamLists.Add(allTeams);

//Console.WriteLine("Listing all teams.");
//handleTeam(chooseTeam(allTeams));

processTeamList(bloodBowlTeams);
//DO NOT UNCOMMENT EITHER OF THE LINES BELOW UNLESS YOU ARE EXTREMELY SURE YOU WANT TO GENERATE EVERY DUNGEON BOWL ROSTER: IT WILL TAKE HOURS
//processTeamList(dungeonBowlTeams);
//processTeamList(allTeams);
char choice;


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

List<Team> defineDungeonBowlTeams()
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
    Player dwarfBlitzer = new Player("Dwarf Blitzer", 80000);
    Position fireblitzers = new Position("Blitzers", 2, 1);
    fireblitzers.players.Add(dwarfBlitzer);
    Position fireSpecial = new Position("Special", 2, 1);
    fireSpecial.players.Add(trollSlayer);
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
    fire.positions.Add(fireSpecial);
    Teams.Add(fire);

    Position shadowLinos = new Position("Linemen", 16, 4);
    //not that kind
    Position shadowRunners = new Position("Runners", 4, 3);
    Position shadowBlitzers = new Position("Blitzers", 2, 2);
    Position shadowThrowers = new Position("Throwers", 2, 2);
    Position shadowSpecial = new Position("Special", 2, 3);
    Player darkElfLino = new Player("Dark Elf Lineman", 70000);
    Player skavenLino = new Player("Skaven Lineman", 50000);
    Player goblinLino = new Player("Goblin Lineman", 40000);
    Player gnomeLino = new Player("Gnome Lineman", 40000);
    shadowLinos.players.Add(darkElfLino);
    shadowLinos.players.Add(skavenLino);
    shadowLinos.players.Add(goblinLino);
    shadowLinos.players.Add(gnomeLino);
    Player gutterRunner = new Player("Gutter Runner", 85000);
    Player darkElfRunner = new Player("Dark Elf Runner", 80000);
    Player woodlandFox = new Player("Woodland Fox", 50000);
    shadowRunners.players.Add(gutterRunner);
    shadowRunners.players.Add(darkElfRunner);
    shadowRunners.players.Add(woodlandFox);
    Player darkElfBlitzer = new Player("Dark Elf Blitzer", 100000);
    Player skavenBlitzer = new Player("Skaven Blitzer", 90000);
    shadowBlitzers.players.Add(darkElfBlitzer);
    shadowBlitzers.players.Add(skavenBlitzer);
    Player skavenThrower = new Player("Skaven Thrower", 85000);
    Player gnomeIllusionist = new Player("Gnome Illusionist", 50000);
    shadowThrowers.players.Add(skavenThrower);
    shadowThrowers.players.Add(gnomeIllusionist);
    Player witchElf = new Player("Witch Elf", 110000);
    Player assassin = new Player("Assassin", 85000);
    Player gnomeBeastmaster = new Player("Gnome Beastmaster", 55000);
    shadowSpecial.players.Add(assassin);
    shadowSpecial.players.Add(witchElf);
    shadowSpecial.players.Add(gnomeBeastmaster);
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
    Player unionCatcher = new Player("Union Catcher", 100000);
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
    light.positions.Add(lightRunners);
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
    Position deathLinos = new Position("Linemen", 16, 3);
    Player zombieLineman = new Player("Zombie Lineman", 40000);
    Player skeletonLineman = new Player("Skeleton Lineman", 40000);
    Player thrallLineman = new Player("Thrall Lineman", 40000);
    deathLinos.players.Add(skeletonLineman);
    deathLinos.players.Add(zombieLineman);
    deathLinos.players.Add(thrallLineman);
    death.positions.Add(deathLinos);
    Position deathRunners = new Position("Runners", 4, 2);
    Player ghoulRunner = new Player("Ghoul Runner", 75000);
    Player vampireRunner = new Player("Vampire Runner", 100000);
    deathRunners.players.Add(ghoulRunner);
    deathRunners.players.Add(vampireRunner);
    death.positions.Add(deathRunners);
    Player wightBlitzer = new Player("Wight Blitzer", 90000);
    Player wraith = new Player("Wraith", 95000);
    Player vampireBlitzer = new Player("Vampire Blitzer", 110000);
    Position deathBlitzers = new Position("Blitzers", 4, 3);
    deathBlitzers.players.Add(wraith);
    deathBlitzers.players.Add(wightBlitzer);
    deathBlitzers.players.Add(vampireBlitzer);
    death.positions.Add(deathBlitzers);
    Player fleshGolem = new Player("Flesh Golem", 115000);
    Position deathBlockers = new Position("Blockers", 4, 1);
    deathBlockers.players.Add(fleshGolem);
    death.positions.Add(deathBlockers);
    Player mummy = new Player("Mummy", 125000);
    Player vargheist = new Player("Vargheist", 150000);
    Position deathBigGuys = new Position("Big Guys", 2, 2);
    deathBigGuys.players.Add(mummy);
    deathBigGuys.players.Add(vargheist);
    death.positions.Add(deathBigGuys);
    Player vampireThrower = new Player("Vampire Thrower", 110000);
    Position deathThrowers = new Position("Throwers", 2, 1);
    deathThrowers.players.Add(vampireThrower);
    death.positions.Add(deathThrowers);

    
    

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

    return Teams;
}

List<Team> defineBloodBowlTeams()
{
    List<Team> Teams = new List<Team>();
    Team amazons = new Team("Amazons", 60000, true);
    Position amazonLinos = new Position("Linemen", 16, 1);
    Position amazonBlitzers = new Position("Blitzers", 2, 1);
    Position amazonThrowers = new Position("Throwers", 2, 1);
    Position amazonBlockers = new Position("Blockers", 2, 1);
    Player eagleWarriorLinewoman = new Player("Eagle Warrior Linewoman", 50000);
    amazonLinos.players.Add(eagleWarriorLinewoman);
    amazons.positions.Add(amazonLinos);
    Player pirahnaWarriorBlitzer = new Player("Piranha Warrior Blitzer", 90000);
    amazonBlitzers.players.Add(pirahnaWarriorBlitzer);
    amazons.positions.Add(amazonBlitzers);
    Player pythonWarriorThrower = new Player("Python Warrior Thrower", 75000);
    amazonThrowers.players.Add(pythonWarriorThrower);
    amazons.positions.Add(amazonThrowers);
    Player jaguarWarriorBlocker = new Player("Jaguar Warrior Blocker", 110000);
    amazonBlockers.players.Add(jaguarWarriorBlocker);
    amazons.positions.Add(amazonBlockers);
    Teams.Add(amazons);

    Team chaosDwarfs = new Team("Chaos Dwarfs", 50000, true);
    Player hobgoblinLineman = new Player("Hobgoblin Lineman", 40000);
    Position chaosDwarfLinemen = new Position("Linemen", 16, 1);
    chaosDwarfLinemen.players.Add(hobgoblinLineman);
    Player chaosDwarfBlocker = new Player("Chaos Dwarf Blocker", 70000);
    Position chaosDwarfBlockers = new Position("Blockers", 6, 1);
    chaosDwarfBlockers.players.Add(chaosDwarfBlocker);
    Player bullCentaur = new Player("Bull Centaur", 130000);
    Position bullCentaurs = new Position("Bull Centaurs", 2, 1);
    bullCentaurs.players.Add(bullCentaur);
    Player chaosDwarfMinotaur = new Player("Enslaved Minotaur", 130000);
    Position chaosDwarfMinotaurs = new Position("Big Guys", 1, 1);
    chaosDwarfMinotaurs.players.Add(chaosDwarfMinotaur);
    chaosDwarfs.positions.Add(chaosDwarfLinemen);
    chaosDwarfs.positions.Add(chaosDwarfBlockers);
    chaosDwarfs.positions.Add(bullCentaurs);
    chaosDwarfs.positions.Add(chaosDwarfMinotaurs);
    Teams.Add(chaosDwarfs);

    Team darkElves = new Team("Dark Elves", 50000, true);
    Player darkElfLino = new Player("Dark Elf Lineman", 70000);
    Position darkElfLinos = new Position("Linemen", 12, 1);
    darkElfLinos.players.Add(darkElfLino);
    darkElves.positions.Add(darkElfLinos);
    Player darkElfRunner = new Player("Dark Elf Runner", 80000);
    Position darkElfRunners = new Position("Runners", 2, 1);
    darkElfRunners.players.Add(darkElfRunner);
    darkElves.positions.Add(darkElfRunners);
    Player darkElfBlitzer = new Player("Dark Elf Blitzer", 100000);
    Position darkElfBlitzers = new Position("Blitzers", 4, 1);
    darkElfBlitzers.players.Add(darkElfBlitzer);
    darkElves.positions.Add(darkElfBlitzers);
    Player witchElf = new Player("Witch Elf", 110000);
    Position witchElves = new Position("Witch Elves", 2, 1);
    witchElves.players.Add(witchElf);
    darkElves.positions.Add(witchElves);
    Player assassin = new Player("Assassin", 85000);
    Position assassins = new Position("Assassins", 2, 1);
    assassins.players.Add(assassin);
    darkElves.positions.Add(assassins);
    Teams.Add(darkElves);

    Team dwarfs = new Team("Dwarfs", 50000, true);
    Player dwarfLino = new Player("Dwarf Lineman", 70000);
    Player dwarfRunner = new Player("Dwarf Runner", 85000);
    Player dwarfBlitzer = new Player("Dwarf Blitzer", 80000);
    Player trollSlayer = new Player("Trollslayer", 95000);
    Player deathroller = new Player("Deathroller", 170000);
    Position roller = new Position("Deathroller", 1, 1);
    roller.players.Add(deathroller);
    Position dwarfLinos = new Position("Linemen", 16, 1);
    dwarfLinos.players.Add(dwarfLino);
    Position dwarfRunners = new Position("Runners", 2, 1);
    dwarfRunners.players.Add(dwarfRunner);
    Position dwarfBlitzers = new Position("Blitzers", 2, 1);
    dwarfBlitzers.players.Add(dwarfBlitzer);
    Position trollSlayers = new Position("Trollslayer", 2, 1);
    trollSlayers.players.Add(trollSlayer);
    dwarfs.positions.Add(dwarfLinos);
    dwarfs.positions.Add(dwarfRunners);
    dwarfs.positions.Add(trollSlayers);
    dwarfs.positions.Add(dwarfBlitzers);
    dwarfs.positions.Add(roller);
    Teams.Add(dwarfs);


    Team elvenUnion = new Team("Elven Union", 50000, true);
    Player unionLineman = new Player("Union Lineman", 60000);
    Player unionCatcher = new Player("Union Catcher", 100000);
    Player unionThrower = new Player("Union Thrower", 75000);
    Player unionBlitzer = new Player("Union Blitzer", 115000);
    Position unionLinos = new Position("Linemen", 12, 1);
    unionLinos.players.Add(unionLineman);
    elvenUnion.positions.Add(unionLinos);
    Position unionCatchers = new Position("Catchers", 4, 1);
    unionCatchers.players.Add(unionCatcher);
    elvenUnion.positions.Add(unionCatchers);
    Position unionThrowers = new Position("Throwers", 2, 1);
    unionThrowers.players.Add(unionThrower);
    elvenUnion.positions.Add(unionThrowers);
    Position unionBlitzers = new Position("Blitzers", 2, 1);
    unionBlitzers.players.Add(unionBlitzer);
    elvenUnion.positions.Add(unionBlitzers);
    Teams.Add(elvenUnion);


    Team highElves = new Team("High Elves", 50000, true);
    Player highElfLineman = new Player("High Elf Lineman", 70000);
    Position highElfLinemen = new Position("Linemen", 16, 1);
    highElfLinemen.players.Add(highElfLineman);
    highElves.positions.Add(highElfLinemen);
    Player highElfThrower = new Player("High Elf Thrower", 100000);
    Position highElfThrowers = new Position("Throwers", 2, 1);
    highElfThrowers.players.Add(highElfThrower);
    highElves.positions.Add(highElfThrowers);
    Player highElfCatcher = new Player("High Elf Catcher", 90000);
    Position highElfCatchers = new Position("Catchers", 4, 1);
    highElfCatchers.players.Add(highElfCatcher);
    highElves.positions.Add(highElfCatchers);
    Player highElfBlitzer = new Player("High Elf Blitzer", 100000);
    Position highElfBlitzers = new Position("Blitzers", 2, 1);
    highElfBlitzers.players.Add(highElfBlitzer);
    highElves.positions.Add(highElfBlitzers);
    Teams.Add(highElves);

    Team humans = new Team("Humans", 50000, true);
    Player humanLineman = new Player("Human Lineman", 50000);
    Position humanLinemen = new Position("Linemen", 16, 1);
    humanLinemen.players.Add(humanLineman);
    humans.positions.Add(humanLinemen);
    Player humanThrower = new Player("Human Thrower", 80000);
    Position humanThrowers = new Position("Throwers", 2, 1);
    humanThrowers.players.Add(humanThrower);
    humans.positions.Add(humanThrowers);
    Player humanCatcher = new Player("Human Catcher", 65000);
    Position humanCatchers = new Position("Catchers", 4, 1);
    humanCatchers.players.Add(humanCatcher);
    humans.positions.Add(humanCatchers);
    Player humanBlitzer = new Player("Human Blitzer", 85000);
    Position humanBlitzers = new Position("Blitzers", 4, 1);
    humanBlitzers.players.Add(humanBlitzer);
    humans.positions.Add(humanBlitzers);
    Player humanHalfling = new Player("Halfling Hopeful Lineman", 30000);
    Position humanHalflings = new Position("Halflings", 3, 1);
    humanHalflings.players.Add(humanHalfling);
    humans.positions.Add(humanHalflings);
    Player humanOgre = new Player("Ogre", 140000);
    Position humanOgres = new Position("Ogres", 1, 1);
    humanOgres.players.Add(humanOgre);
    humans.positions.Add(humanOgres);
    Teams.Add(humans);

    Team blackOrcs = new Team("Black Orcs", 60000, true);
    Position blOrcLinos = new Position("Linemen", 12, 1);
    Player goblinBruiserLineman = new Player("Goblin Bruiser Lineman", 45000);
    blOrcLinos.players.Add(goblinBruiserLineman);
    Player blackOrc = new Player("Black Orc", 90000);
    Position blOrcBlOrcs = new Position("Black Orcs", 6, 1);
    blOrcBlOrcs.players.Add(blackOrc);
    Player trainedTroll = new Player("Trained Troll", 115000);
    Position blOrcTrolls = new Position("Troll", 1, 1);
    blOrcTrolls.players.Add(trainedTroll);
    blackOrcs.positions.Add(blOrcLinos);
    blackOrcs.positions.Add(blOrcBlOrcs);
    blackOrcs.positions.Add(blOrcTrolls);
    Teams.Add(blackOrcs);

    Team skaven = new Team("Skaven", 50000, true);
    Player skavenLineman = new Player("Skaven Clanrat Lineman", 50000);
    Position skavenLinemen = new Position("Linemen", 16, 1);
    skavenLinemen.players.Add(skavenLineman);
    skaven.positions.Add(skavenLinemen);
    Player skavenThrower = new Player("Skaven Thrower", 75000);
    Position skavenThrowers = new Position("Throwers", 2, 1);
    skavenThrowers.players.Add(skavenThrower);
    skaven.positions.Add(skavenThrowers);
    Player skavenBlitzer = new Player("Skaven Blitzer", 90000);
    Position skavenBlitzers = new Position("Blitzers", 2, 1);
    skavenBlitzers.players.Add(skavenBlitzer);
    skaven.positions.Add(skavenBlitzers);
    Player gutterRunner = new Player("Gutter Runner", 85000);
    Position skavenRunners = new Position("Runners", 4, 1);
    skavenRunners.players.Add(gutterRunner);
    skaven.positions.Add(skavenRunners);
    Player ratOgre = new Player("Rat Ogre", 150000);
    Position ratOgres = new Position("Big Guys", 1, 1);
    Teams.Add(skaven);

    Team woodElves = new Team("Wood Elves", 50000, true);
    Player woodElfLineman = new Player("Wood Elf Lineman", 70000);
    Position woodElfLinemen = new Position("Linemen", 12, 1);
    woodElfLinemen.players.Add(woodElfLineman);
    woodElves.positions.Add(woodElfLinemen);
    Player woodElfThrower = new Player("Wood Elf Thrower", 95000);
    Position woodElfThrowers = new Position("Throwers", 2, 1);
    woodElfThrowers.players.Add(woodElfThrower);
    woodElves.positions.Add(woodElfThrowers);
    Player woodElfCatcher = new Player("Wood Elf Catcher", 90000);
    Position woodElfCatchers = new Position("Catchers", 4, 1);
    woodElfCatchers.players.Add(woodElfCatcher);
    woodElves.positions.Add(woodElfCatchers);
    Player wardancer = new Player("Wardancer", 125000);
    Position wardancers = new Position("Wardancers", 2, 1);
    wardancers.players.Add(wardancer);
    woodElves.positions.Add(wardancers);
    Player woodElfTreeman = new Player("Loren Forest Treeman", 120000);
    Position woodElfTreemen = new Position("Big Guys", 1, 1);
    woodElfTreemen.players.Add(woodElfTreeman);
    woodElves.positions.Add(woodElfTreemen);
    Teams.Add(woodElves);

    Team ChaosChosen = new Team("Chaos Chosen", 60000, true);
    Player chaosBeastman = new Player("Beastman Lineman", 60000);
    Position chaosLinos = new Position("Linemen", 16, 1);
    chaosLinos.players.Add(chaosBeastman);
    ChaosChosen.positions.Add(chaosLinos);
    Player chosenBlocker = new Player("Chosen Blocker", 100000);
    Position chaosBlockers = new Position("Blockers", 6, 1);
    chaosBlockers.players.Add(chosenBlocker);
    ChaosChosen.positions.Add(chaosBlockers);
    Player chaosTroll = new Player("Chaos Troll", 115000);
    Player chaosOgre = new Player("Chaos Ogre", 140000);
    Player chaosMinotaur = new Player("Chaos Minotaur", 150000);
    Position chosenBigGuys = new Position("Big Guys", 1, 3);
    chosenBigGuys.players.Add(chaosTroll);
    chosenBigGuys.players.Add(chaosOgre);
    chosenBigGuys.players.Add(chaosMinotaur);
    ChaosChosen.positions.Add(chosenBigGuys);
    Teams.Add(ChaosChosen);

    Team ChaosRenegades = new Team("Chaos Renegades", 70000, true);
    Player renegadeLineman = new Player("Renegade Lineman", 50000);
    Position renegadeLinos = new Position("Linemen", 16, 1);
    renegadeLinos.players.Add(renegadeLineman);
    ChaosRenegades.positions.Add(renegadeLinos);
    Player renegadeThrower = new Player("Renegade Thrower", 75000);
    Position renegadeThrowers = new Position("Throwers", 1, 1);
    renegadeThrowers.players.Add(renegadeThrower);
    ChaosRenegades.positions.Add(renegadeThrowers);
    Player renegadeOrce = new Player("Renegade Orc", 50000);
    Position renegadeOrcs = new Position("Orc", 1, 1);
    renegadeOrcs.players.Add(renegadeOrce);
    ChaosRenegades.positions.Add(renegadeOrcs);
    Player renegadeSkaven = new Player("Renegade Skaven", 50000);
    Position renegadeSkavens = new Position("Skaven", 1, 1);
    renegadeSkavens.players.Add(renegadeSkaven);
    ChaosRenegades.positions.Add(renegadeSkavens);
    Player renegadeGoblin = new Player("Renegade Goblin", 40000);
    Position rGoblinz = new Position("Goblin", 1, 1);
    rGoblinz.players.Add(renegadeGoblin);
    ChaosRenegades.positions.Add(rGoblinz);
    Player renegadeDarkElf = new Player("Renegade Dark Elf", 75000);
    Position renElf = new Position("Dark Elf", 1, 1);
    renElf.players.Add(renegadeDarkElf);
    ChaosRenegades.positions.Add(renElf);
    Player renTroll = new Player("Renegade Troll", 115000);
    Position renTrollz = new Position("Troll", 1, 1);
    renTrollz.players.Add(renTroll);
    ChaosRenegades.positions.Add(renTrollz);
    Player renOgre = new Player("Renegade Ogre", 140000);
    Position renOGREZ = new Position("Ogre", 1, 1);
    renOGREZ.players.Add(renOgre);
    ChaosRenegades.positions.Add(renOGREZ);
    Player renMinotaur = new Player("Renegade Minotaur", 150000);
    Position rMinoz = new Position("Minotaur", 1, 1);
    rMinoz.players.Add(renMinotaur);
    ChaosRenegades.positions.Add(rMinoz);
    Player renRatOgre = new Player("Renegade Rat Ogre", 150000);
    Position rRogre = new Position("Rat Ogre", 1, 1);
    rRogre.players.Add(renRatOgre);
    ChaosRenegades.positions.Add(rRogre);
    Teams.Add(ChaosRenegades);

    Team GoblinTeam = new Team("Goblins", 60000, true);
    Player goblin = new Player("Goblin", 40000);
    Position goblinos = new Position("Linemen", 16, 1);
    goblinos.players.Add(goblin);
    GoblinTeam.positions.Add(goblinos);
    Position goblinTrolls = new Position("Trolls", 2, 1);
    goblinTrolls.players.Add(trainedTroll);
    Player Bomma = new Player("Bomma", 45000);
    Position bomma = new Position("Bomma", 1, 1);
    bomma.players.Add(Bomma);
    GoblinTeam.positions.Add(goblinTrolls);
    GoblinTeam.positions.Add(bomma);
    Player Looney = new Player("Looney", 40000);
    Position looneys = new Position("Looney", 1, 1);
    looneys.players.Add(Looney);
    GoblinTeam.positions.Add(looneys);
    Player Fanatic = new Player("Fanatic", 70000);
    Position fanatics = new Position("Fanatics", 1, 1);
    fanatics.players.Add(Fanatic);
    GoblinTeam.positions.Add(fanatics);
    Player Pogoer = new Player("Pogoer", 75000);
    Position pogoers = new Position("Pogoers", 1, 1);
    pogoers.players.Add(Pogoer);
    GoblinTeam.positions.Add(pogoers);
    Player ooligan = new Player("'ooligan", 65000);
    Position olgns = new Position("'Ooligans", 1, 1);
    olgns.players.Add(ooligan);
    GoblinTeam.positions.Add(olgns);
    Player doomDiver = new Player("Doom Diver", 60000);
    Position divers = new Position("Doom Divers", 1, 1);
    divers.players.Add(doomDiver);
    GoblinTeam.positions.Add(divers);
    Teams.Add(GoblinTeam);

    Team HalflingTeam = new Team("Halflings", 60000, true);
    Position halflinos = new Position("Linemen", 16, 1);
    halflinos.players.Add(humanHalfling);
    HalflingTeam.positions.Add(halflinos);
    Player hefty = new Player("Halfling Hefty", 50000);
    Position hefties = new Position("Hefties", 2, 1);
    hefties.players.Add(hefty);
    HalflingTeam.positions.Add(hefties);
    Player halfCatcher = new Player("Halfling Catcher", 55000);
    Position halflingCatchers = new Position("Catchers", 2, 1);
    halflingCatchers.players.Add(halfCatcher);
    HalflingTeam.positions.Add(halflingCatchers);
    Player halfTree = new Player("Altern Forest Treeman", 120000);
    Position halflingTrees = new Position("Big Guys", 2, 1);
    HalflingTeam.positions.Add(halflingTrees);
    Teams.Add(HalflingTeam);

    Team imperialNobility = new Team("Imperial Nobility", 70000, true);
    Player nobilityLineman = new Player("Imperial Retainer Lineman", 45000);
    Position nobilityLinos = new Position("Linemen", 16, 1);
    nobilityLinos.players.Add(nobilityLineman);
    imperialNobility.positions.Add(nobilityLinos);
    Player nobilityBlitzer = new Player("Noble Blitzer", 105000);
    Position nobLitzers = new Position("Blitzers", 2, 1);
    nobLitzers.players.Add(nobilityBlitzer);
    imperialNobility.positions.Add(nobLitzers);
    Player nobleThrower = new Player("Imperial Thrower", 75000);
    Position nobThrowers = new Position("Throwers", 2, 1);
    nobThrowers.players.Add(nobleThrower);
    imperialNobility.positions.Add(nobThrowers);
    Player bodyguard = new Player("Bodyguard", 90000);
    Position nobBG = new Position("Bodyguards", 4, 1);
    nobBG.players.Add(bodyguard);
    imperialNobility.positions.Add(nobBG);
    imperialNobility.positions.Add(humanOgres);
    Teams.Add(imperialNobility);

    Team lizardmanTeam = new Team("Lizardmen", 70000, true);
    Player skink = new Player("Skink Runner Lineman", 60000);
    Position lineLizards = new Position("Linemen", 12, 1);
    lineLizards.players.Add(skink);
    lizardmanTeam.positions.Add(lineLizards);
    Player Saurus = new Player("Saurus Blocker", 85000);
    Position lizardBl = new Position("Blockers", 6, 1);
    lizardBl.players.Add(Saurus);
    lizardmanTeam.positions.Add(lizardBl);
    Player chameleon = new Player("Chameleon Skink", 70000);
    Position chameleons = new Position("Chameleons", 2, 1);
    chameleons.players.Add(chameleon);
    lizardmanTeam.positions.Add(chameleons);
    Player kroxigor = new Player("Kroxigor", 140000);
    Position kroxigors = new Position("Big Guys", 1, 1);
    kroxigors.players.Add(kroxigor);
    lizardmanTeam.positions.Add(kroxigors);
    Teams.Add(lizardmanTeam);

    Team necromanticHorror = new Team("Necromantic Horror", 70000, false);
    Player Zombie = new Player("Zombie", 40000);
    Position spookyLinemen = new Position("Linemen", 16, 1);
    spookyLinemen.players.Add(Zombie);
    necromanticHorror.positions.Add(spookyLinemen);
    Player ghoulRunner = new Player("Ghoul Runner", 75000);
    Position necromanticRunners = new Position("Runners", 2, 1);
    necromanticRunners.players.Add(ghoulRunner);
    necromanticHorror.positions.Add(necromanticRunners);
    Player wraith = new Player("Wraith", 95000);
    Position spookyBlitzers = new Position("Blitzers", 2, 1);
    spookyBlitzers.players.Add(wraith);
    necromanticHorror.positions.Add(spookyBlitzers);
    Player fleshGolem = new Player("Flesh Golem", 115000);
    Position spookyBlockers = new Position("Blockers", 2, 1);
    spookyBlockers.players.Add(fleshGolem);
    necromanticHorror.positions.Add(spookyBlockers);
    Teams.Add(necromanticHorror);

    Team nurgle = new Team("Nurgle", 70000, false);
    Player Rotter = new Player("Rotter Lineman", 35000);
    Position nurglinos = new Position("Linemen", 12, 1);
    nurglinos.players.Add(Rotter);
    nurgle.positions.Add(nurglinos);
    Player Bloater = new Player("Bloater", 115000);
    Position nurgleBlockers = new Position("Blockers", 4, 1);
    nurgleBlockers.players.Add(Bloater);
    nurgle.positions.Add(nurgleBlockers);
    Player pestigor = new Player("Pestigor", 75000);
    Position nurgleRunner = new Position("Runner", 4, 1);
    nurgleRunner.players.Add(pestigor);
    nurgle.positions.Add(nurgleRunner);
    Player rotspawn = new Player("Rotspawn", 140000);
    Position nBigGuy = new Position("Big Guy", 1, 1);
    nBigGuy.players.Add(rotspawn);
    nurgle.positions.Add(nBigGuy);
    Teams.Add(nurgle);

    Team ogreTeam = new Team("Ogres", 70000, true);
    Player gnoblarLineman = new Player("Gnoblar Lineman", 15000, 0);
    Position ogreLinos = new Position("Linemen", 16, 1);
    Player ogreBlocker = new Player("Ogre Blocker", 140000);
    Position ogreBlockers = new Position("Ogre Blockers", 5, 1);
    ogreLinos.players.Add(gnoblarLineman);
    ogreBlockers.players.Add(ogreBlocker);
    Player ogreRuntPunter = new Player("Ogre Runt Punter", 145000);
    Position runtPunters = new Position("Runt Punter", 1, 1);
    runtPunters.players.Add(ogreRuntPunter);
    ogreTeam.positions.Add(ogreLinos);
    ogreTeam.positions.Add(ogreBlockers);
    ogreTeam.positions.Add(runtPunters);
    Teams.Add(ogreTeam);

    Team oldWorldAlliance = new Team("Old World Alliance", 70000, true);
    Player oldwHuman = new Player("Old World Human Lineman", 50000);
    Position owLinos = new Position("Linemen", 12, 1);
    owLinos.players.Add(oldwHuman);
    oldWorldAlliance.positions.Add(owLinos);
    Player owThrower = new Player("Old World Thrower", 80000);
    Position owThr = new Position("Thrower", 1, 1);
    owThr.players.Add(owThrower);
    oldWorldAlliance.positions.Add(owThr);
    Player owCatcher = new Player("Old World Catcher", 65000);
    Position owCatch = new Position("Catcher", 1, 1);
    owCatch.players.Add(owCatcher);
    oldWorldAlliance.positions.Add(owCatch);
    Player owHBlitz = new Player("Old World Human Blitzer", 90000);
    Position owHB = new Position("Human Blitzer", 1, 1);
    owHB.players.Add(owHBlitz);
    oldWorldAlliance.positions.Add(owHB);
    Player owDwarfB = new Player("Old World Dwarf Blockers", 75000);
    Position owDB = new Position("Dwarf Blockers", 2, 1);
    owDB.players.Add(owDwarfB);
    oldWorldAlliance.positions.Add(owDB);
    Player owDwarfBlitz = new Player("Old World Dwarf Blitzer", 80000);
    Position owDBlitz = new Position("Dwarf Blitzer", 1, 1);
    owDBlitz.players.Add(owDwarfBlitz);
    oldWorldAlliance.positions.Add(owDBlitz);
    Player owDRunner = new Player("Old World Dwarf Runner", 85000);
    Position owDR = new Position("Dwarf Runner", 1, 1);
    owDR.players.Add(owDRunner);
    oldWorldAlliance.positions.Add(owDR);
    Player oldWTrollSl = new Player("Old World Trollslayer", 95000);
    Position owTS = new Position("Trollslayer", 1, 1);
    owTS.players.Add(oldWTrollSl);
    oldWorldAlliance.positions.Add(owTS);
    Player owHalfling = new Player("Old World Halfling Hopeful", 30000);
    Position owH = new Position("Halfling", 2, 1);
    owH.players.Add(owHalfling);
    oldWorldAlliance.positions.Add(owH);
    Position owBigGuy = new Position("Big Guy", 1, 2);
    owBigGuy.players.Add(humanOgre);
    owBigGuy.players.Add(halfTree);
    oldWorldAlliance.positions.Add(owBigGuy);
    Teams.Add(oldWorldAlliance);


    Team orcTeam = new Team("Orcs", 60000, true);
    Player orcLino = new Player("Orc Lineman", 50000);
    Position orcLinos = new Position("Linemen", 16, 1);
    orcLinos.players.Add(orcLino);
    orcTeam.positions.Add(orcLinos);
    Player orcBlitzer = new Player("Orc Blitzer", 80000);
    Position orcBli = new Position("Blitzers", 4, 1);
    orcBli.players.Add(orcBlitzer);
    orcTeam.positions.Add(orcBli);
    Player orcBlocker = new Player("Big Un Blocker", 90000);
    Position orcBL = new Position("Blocker", 4, 1);
    orcBL.players.Add(orcBlocker);
    orcTeam.positions.Add(orcBL);
    Player orcThrower = new Player("Orc Thrower", 65000);
    Position orcThrowers = new Position("Throwers", 2, 1);
    orcThrowers.players.Add(orcThrower);
    orcTeam.positions.Add(orcThrowers);
    Position orcGoblins = new Position("Goblins", 4, 1);
    orcGoblins.players.Add(goblin);
    orcTeam.positions.Add(orcGoblins);
    Player untrainedTroll = new Player("Untrained Troll", 115000);
    Position orcTroll = new Position("Big Guy", 1, 1);
    orcTroll.players.Add(untrainedTroll);
    orcTeam.positions.Add(orcTroll);
    Teams.Add(orcTeam);

    Team shamblingUndead = new Team("Shambling Undead", 70000, false);
    Position zombieLinos = new Position("Zombies", 12, 1);
    zombieLinos.players.Add(Zombie);
    Player skeleton = new Player("Skeleton", 40000);
    Position skeletonLinos = new Position("Skeletons", 12, 1);
    skeletonLinos.players.Add(skeleton);
    shamblingUndead.positions.Add(skeletonLinos);
    shamblingUndead.positions.Add(zombieLinos);
    Position shambleRunners = new Position("Runners", 4, 1);
    shambleRunners.players.Add(ghoulRunner);
    shamblingUndead.positions.Add(shambleRunners);
    Player wightBlitzer = new Player("Wight Blitzer", 90000);
    Position shamblitz = new Position("Blitzers", 2, 1);
    shamblitz.players.Add(wightBlitzer);
    shamblingUndead.positions.Add(shamblitz);
    Player mummy = new Player("Mummy", 125000);
    Position mummies = new Position("Big Guys", 2, 1);
    mummies.players.Add(mummy);
    shamblingUndead.positions.Add(mummies);
    Teams.Add(shamblingUndead);

    Team snotlingTeam = new Team("Snotlings", 60000, true);
    Player snotLino = new Player("Snotling Lineman", 15000, 0);
    Position snotLin = new Position("Linemen", 16, 1);
    snotLin.players.Add(snotLino);
    snotlingTeam.positions.Add(snotLin);
    Player fungusFlinga = new Player("Fungus Flinga", 30000);
    Position flingas = new Position("Fungus Flingas", 2, 1);
    flingas.players.Add(fungusFlinga);
    snotlingTeam.positions.Add(flingas);
    Player funhoppa = new Player("Fun-hoppa", 20000);
    Position hoppas = new Position("Fun-hoppas", 2, 1);
    hoppas.players.Add(funhoppa);
    snotlingTeam.positions.Add(hoppas);
    Player stiltyRunna = new Player("Stilty Runna", 20000);
    Position stilty = new Position("Stilty Runnas", 2, 1);
    stilty.players.Add(stiltyRunna);
    snotlingTeam.positions.Add(stilty);
    Player pumpWagon = new Player("Pump Wagon", 105000);
    Position wagons = new Position("Pump Wagons", 2, 1);
    wagons.players.Add(pumpWagon);
    snotlingTeam.positions.Add(wagons);
    Position snotTrolls = new Position("Trolls", 2, 1);
    snotTrolls.players.Add(trainedTroll);
    snotlingTeam.positions.Add(snotTrolls);
    Teams.Add(snotlingTeam);

    Team underworldDenizens = new Team("Underworld Denizens", 70000, true);
    Player undGoblin = new Player("Underworld Goblin", 40000);
    Position undLinos = new Position("Linemen", 12, 1);
    undLinos.players.Add(undGoblin);
    underworldDenizens.positions.Add(undLinos);
    Player undSnot = new Player("Underworld Snotling", 15000);
    Position undSnots = new Position("Snotlings", 6, 1);
    undSnots.players.Add(undSnot);
    underworldDenizens.positions.Add(undSnots);
    Player undClanrat = new Player("Skaven Clanrat", 50000);
    Position undClan = new Position("Clanrats", 3, 1);
    undClan.players.Add(undClanrat);
    underworldDenizens.positions.Add(undClan);
    Position undThrower = new Position("Thrower", 1, 1);
    undThrower.players.Add(skavenThrower);
    underworldDenizens.positions.Add(undThrower);
    Position undBlitzer = new Position("Blitzer", 1, 1);
    undBlitzer.players.Add(skavenBlitzer);
    underworldDenizens.positions.Add(undBlitzer);
    Position undGutter = new Position("Gutter Runner", 1, 1);
    undGutter.players.Add(gutterRunner);
    underworldDenizens.positions.Add(undGutter);
    Position undBigGuys = new Position("Big Guys", 1, 2);
    Player mutantRatOgre = new Player("Mutant Rat Ogre", 150000);
    Player underworldTroll = new Player("Underworld Troll", 115000);
    undBigGuys.players.Add(mutantRatOgre);
    undBigGuys.players.Add(underworldTroll);
    underworldDenizens.positions.Add(undBigGuys);
    Teams.Add(underworldDenizens);

    Team norse = new Team("Norse", 60000, true);
    Player norseLino = new Player("Norse Raider Lineman", 50000);
    Position norseLinos = new Position("Linemen", 16, 1);
    norseLinos.players.Add(norseLino);
    norse.positions.Add(norseLinos);
    Player beerBoar = new Player("Beer Boar", 20000);
    Position beers = new Position("Beer Boars", 2, 1);
    beers.players.Add(beerBoar);
    norse.positions.Add(beers);
    Player berserker = new Player("Norse Berserker", 90000);
    Position bers = new Position("Berserkers", 2, 1);
    bers.players.Add(berserker);
    norse.positions.Add(bers);
    Player valkyrie = new Player("Valkyrie", 95000);
    Position valk = new Position("Valkyries", 2, 1);
    valk.players.Add(valkyrie);
    norse.positions.Add(valk);
    Player ulfwerener = new Player("Ulfwerener", 105000);
    Position ulfs = new Position("Ulfwereners", 2, 1);
    ulfs.players.Add(ulfwerener);
    norse.positions.Add(ulfs);
    Player yhetee = new Player("Yhetee", 140000);
    Position yhet = new Position("Yhetee(s?)", 1, 1);
    yhet.players.Add(yhetee);
    norse.positions.Add(yhet);
    Teams.Add(norse);

    Team khorne = new Team("Khorne", 60000, true);
    Player bloodBornLino = new Player("Bloodborn Marauder Lineman", 50000);
    Position khornelinos = new Position("Linemen", 16, 1);
    khornelinos.players.Add(bloodBornLino);
    khorne.positions.Add(khornelinos);
    Player khorngor = new Player("Khorngor", 70000);
    Position kgors = new Position("Khorngors", 4, 1);
    kgors.players.Add(khorngor);
    khorne.positions.Add(kgors);
    Player bloodseeker = new Player("Bloodseeker", 110000);
    Position seekers = new Position("Bloodseekers", 4, 1);
    seekers.players.Add(bloodseeker);
    khorne.positions.Add(seekers);
    Player bloodspawn = new Player("Bloodspawn", 160000);
    Position spawn = new Position("Big Guys", 1, 1);
    spawn.players.Add(bloodspawn);
    khorne.positions.Add(spawn);
    Teams.Add(khorne);

    Team Vampires = new Team("Vampires", 60000, true);
    Player vampireLino = new Player("Thrall Lineman", 40000);
    Position vampLinos = new Position("Linemen", 16, 1);
    vampLinos.players.Add(vampireLino);
    Vampires.positions.Add(vampLinos);
    Player vampThrower = new Player("Vampire Thrower", 110000);
    Position vampThrowers = new Position("Throwers", 2, 1);
    vampThrowers.players.Add(vampThrower);
    Vampires.positions.Add(vampThrowers);
    Player vampRunner = new Player("Vampire Runner", 100000);
    Position vampRunners = new Position("Runners", 2, 1);
    vampRunners.players.Add(vampRunner);
    Vampires.positions.Add(vampRunners);
    Player vampBlitzer = new Player("Vampire Blitzer", 110000);
    Position vampBlitzers = new Position("Blitzers", 2, 1);
    vampBlitzers.players.Add(vampBlitzer);
    Vampires.positions.Add(vampBlitzers);
    Player vargheist = new Player("Vargheist", 150000);
    Position varg = new Position("Big Guys", 1, 1);
    varg.players.Add(vargheist);
    Vampires.positions.Add(varg);
    Teams.Add(Vampires);

    Team Gnomes = new Team("Gnomes", 50000, true);
    Player gnomeLino = new Player("Gnome Lineman", 40000);
    Position gnomeLinos = new Position("Linemen", 16, 1);
    gnomeLinos.players.Add(gnomeLino);
    Gnomes.positions.Add(gnomeLinos);
    Position gnomeTrees = new Position("Big Guys", 2, 1);
    gnomeTrees.players.Add(halfTree);
    Gnomes.positions.Add(gnomeTrees);
    Player gnomeBeastmaster = new Player("Gnome Beastmaster", 55000);
    Position gnomeBeastmasters = new Position("Beastmasters", 2, 1);
    gnomeBeastmasters.players.Add(gnomeBeastmaster);
    Gnomes.positions.Add(gnomeBeastmasters);
    Player gnomeIllusionist = new Player("Gnome Illusionist", 50000);
    Position gnomeIllusionists = new Position("Illusionists", 2, 1);
    gnomeIllusionists.players.Add(gnomeIllusionist);
    Gnomes.positions.Add(gnomeIllusionists);
    Player gnomeFox = new Player("Woodland Fox", 50000);
    Position gnomeFoxes = new Position("Foxes", 2, 1);
    gnomeFoxes.players.Add(gnomeFox);
    Gnomes.positions.Add(gnomeFoxes);
    Teams.Add(Gnomes);
    

    return Teams;
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
        BigInteger thisMany = TestFunctions.MultiChooseSum(p.maximumPlayers, p.numberOfPlayerTypes);
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


}
//Each position contains a list of players, a maximum number of players in that position, and, for the sake of avoiding int to BigInteger conversion, a count of the number of options.
//This is not as expandable as I'd like, but I think it's a better option right now.
public class Position
{
    public string name;
    public Position(string positionName, int maxPlayers, int numTypes)
    {
        name = positionName;
        maximumPlayers = maxPlayers;
        numberOfPlayerTypes = numTypes;
        players = new List<Player>();
    }
    public int maximumPlayers;
    public int numberOfPlayerTypes;
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