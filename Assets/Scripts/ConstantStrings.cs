using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PurchaseItemType { CandyBasket1, CandyBasket2, CandySign, BigCauldron, CandifyHouse1, CandifyHouse2, HouseExpansion1,
    HouseExpansion2, BallPit, Drones, Pony, Arcade, TRex, Pool, NeonSign, RockConcert, RollerCoaster,
    WitchBroom, McDonalds, CandySmells, DuckFeet, FreePuppies, Balloons, BaseCauldron, BaseHouse, HouseExpansion3,
    DecoyChildren, Telescope, FireInsurance, RigElection, DecoyWitchHut, FrameWerewolves, ChangeTrailSigns, HideTrueIdentity,
    YourSoul, SoulMateSoul, FirstBorn, FavoriteMemory, FiveYears, PowerOfAttorney, LeftFromRight, SocialSecurity}

public class ConstantStrings : MonoBehaviour
{

    private static ConstantStrings instance = null;
    public static ConstantStrings Instance { get { return instance; } }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    public const string totalSouls = "totalSouls";

    public const string collectionTime = "collectionTime";

    public const string fireCheckTime = "fireCheckTime";

    public const string offerCheckTime = "offerCheckTime";

    public const string built = "built";
    public const string onFire = "onFire";
    public const string destroyed = "destroyed";
    public const string available = "available";

    private string candyBasket1ID = "candyBasket1";
    private string candyBasket2ID = "candyBasket2";
    private string candySignID = "candySign";
    private string bigCauldronID = "bigCauldron";
    private string candifyHouse1ID = "candifyHouse1";
    private string candifyHouse2ID = "candifyHouse2";
    private string houseExpansion1ID = "houseExpansion1";
    private string houseExpansion2ID = "houseExpansion2";
    private string ballPitID = "ballPit";
    private string dronesID = "drones";
    private string ponyID = "pony";
    private string arcadeID = "arcade";
    private string tRexID = "tRex";
    private string poolID = "pool";
    private string neonSignID = "neonSign";
    private string rockConcertID = "rockConcert";
    private string rollerCoasterID = "rollerCoaster";
    private string witchBroomID = "witchBroom";
    private string mcDonaldsID = "mcDonalds";
    private string candySmellsID = "candySmells";
    private string duckFeetID = "duckFeet";
    private string freePuppiesID = "freePuppies";
    private string balloonsID = "balloons";
    private string baseCauldronID = "baseCauldron";
    private string baseHouseID = "baseHouse";
    private string houseExpansion3ID = "houseExpansion3";
    private string decoyChildrenID = "decoyChildren";
    private string telescopeID = "telescope";
    private string fireInsuranceID = "fireInsurance";
    private string rigElectionID = "rigElection";
    private string decoyWitchHutID = "decoyWitchHut";
    private string frameWerewolvesID = "frameWerewolves";
    private string changeTrailSignsID = "changeTrailSigns";
    private string hideTrueIdentityID = "hideTrueIdentity";
    private string yourSoulID = "yourSoul";
    private string soulMateSoulID = "soulMateSoul";
    private string firstBornID = "firstBorn";
    private string favoriteMemoryID = "favoritMemory";
    private string fiveYearsID = "fiveYears";
    private string powerOfAttorneyID = "powerOfAttorney";
    private string leftFromRightID = "leftFromRight";
    private string socialSecurityID = "socialSecurity";


    [Header("DISPLAY NAMES")]
    [SerializeField] private string candyBasket1Name = "candyBasket1";
    [SerializeField] private string candyBasket2Name = "candyBasket2";
    [SerializeField] private string candySignName = "candySign";
    [SerializeField] private string bigCauldronName = "bigCauldron";
    [SerializeField] private string candifyHouse1Name = "candifyHouse1";
    [SerializeField] private string candifyHouse2Name = "candifyHouse2";
    [SerializeField] private string houseExpansion1Name = "houseExpansion1";
    [SerializeField] private string houseExpansion2Name = "houseExpansion2";
    [SerializeField] private string ballPitName = "ballPit";
    [SerializeField] private string dronesName = "drones";
    [SerializeField] private string ponyName = "pony";
    [SerializeField] private string arcadeName = "arcade";
    [SerializeField] private string tRexName = "tRex";
    [SerializeField] private string poolName = "pool";
    [SerializeField] private string neonSignName = "neonSign";
    [SerializeField] private string rockConcertName = "rockConcert";
    [SerializeField] private string rollerCoasterName = "rollerCoaster";
    [SerializeField] private string witchBroomName = "witchBroom";
    [SerializeField] private string mcDonaldsName = "mcDonalds";
    [SerializeField] private string candySmellsName = "candySmells";
    [SerializeField] private string duckFeetName = "duckFeet";
    [SerializeField] private string freePuppiesName = "freePuppies";
    [SerializeField] private string balloonsName = "balloons";
    [SerializeField] private string baseCauldronName = "baseCauldron";
    [SerializeField] private string baseHouseName = "baseHouse";
    [SerializeField] private string houseExpansion3Name = "houseExpansion3";
    [SerializeField] private string decoyChildrenName = "decoyChildren";
    [SerializeField] private string telescopeName = "telescope";
    [SerializeField] private string fireInsuranceName = "fireInsurance";
    [SerializeField] private string rigElectionName = "rigElection";
    [SerializeField] private string decoyWitchHutName = "decoyWitchHut";
    [SerializeField] private string frameWerewolvesName = "frameWerewolves";
    [SerializeField] private string changeTrailSignsName = "changeTrailSigns";
    [SerializeField] private string hideTrueIdentityName = "hideTrueIdentity";
    [SerializeField] private string yourSoulName = "yourSoul";
    [SerializeField] private string soulMateSoulName = "soulMateSoul";
    [SerializeField] private string firstBornName = "firstBorn";
    [SerializeField] private string favoriteMemoryName = "favoritMemory";
    [SerializeField] private string fiveYearsName = "fiveYears";
    [SerializeField] private string powerOfAttorneyName = "powerOfAttorney";
    [SerializeField] private string leftFromRightName = "leftFromRight";
    [SerializeField] private string socialSecurityName = "socialSecurity";


    [Header("PURCHASE PRICES")]
    [SerializeField] private int candyBasket1Price = 20;
    [SerializeField] private int candyBasket2Price = 20;
    [SerializeField] private int candySignPrice = 20;
    [SerializeField] private int bigCauldronPrice = 20;
    [SerializeField] private int candifyHouse1Price = 20;
    [SerializeField] private int candifyHouse2Price = 20;
    [SerializeField] private int houseExpansion1Price = 20;
    [SerializeField] private int houseExpansion2Price = 20;
    [SerializeField] private int ballPitPrice = 20;
    [SerializeField] private int dronesPrice = 20;
    [SerializeField] private int ponyPrice = 20;
    [SerializeField] private int arcadePrice = 20;
    [SerializeField] private int tRexPrice = 20;
    [SerializeField] private int poolPrice = 20;
    [SerializeField] private int neonSignPrice = 20;
    [SerializeField] private int rockConcertPrice = 20;
    [SerializeField] private int rollerCoasterPrice = 20;
    [SerializeField] private int witchBroomPrice = 20;
    [SerializeField] private int mcDonaldsPrice = 20;
    [SerializeField] private int candySmellsPrice = 20;
    [SerializeField] private int duckFeetPrice = 20;
    [SerializeField] private int freePuppiesPrice = 20;
    [SerializeField] private int balloonsPrice = 20;
    [SerializeField] private int baseCauldronPrice = 20;
    [SerializeField] private int baseHousePrice = 20;
    [SerializeField] private int houseExpansion3Price = 20;
    [SerializeField] private int decoyChildrenPrice = 20;
    [SerializeField] private int telescopePrice = 20;
    [SerializeField] private int fireInsurancePrice = 20;
    [SerializeField] private int rigElectionPrice = 20;
    [SerializeField] private int decoyWitchHutPrice = 20;
    [SerializeField] private int frameWerewolvesPrice = 20;
    [SerializeField] private int changeTrailSignsPrice = 20;
    [SerializeField] private int hideTrueIdentityPrice = 20;
    [SerializeField] private int yourSoulPrice = 20;
    [SerializeField] private int soulMateSoulPrice = 20;
    [SerializeField] private int firstBornPrice = 20;
    [SerializeField] private int favoriteMemoryPrice = 20;
    [SerializeField] private int fiveYearsPrice = 20;
    [SerializeField] private int powerOfAttorneyPrice = 20;
    [SerializeField] private int leftFromRightPrice = 20;
    [SerializeField] private int socialSecurityPrice = 20;


    [Header("STORE DESCRIPTIONS")]
    [SerializeField] private string candyBasket1Description = "candyBasket1";
    [SerializeField] private string candyBasket2Description = "candyBasket2";
    [SerializeField] private string candySignDescription = "candySign";
    [SerializeField] private string bigCauldronDescription = "bigCauldron";
    [SerializeField] private string candifyHouse1Description = "candifyHouse1";
    [SerializeField] private string candifyHouse2Description = "candifyHouse2";
    [SerializeField] private string houseExpansion1Description = "houseExpansion1";
    [SerializeField] private string houseExpansion2Description = "houseExpansion2";
    [SerializeField] private string ballPitDescription = "ballPit";
    [SerializeField] private string dronesDescription = "drones";
    [SerializeField] private string ponyDescription = "pony";
    [SerializeField] private string arcadeDescription = "arcade";
    [SerializeField] private string tRexDescription = "tRex";
    [SerializeField] private string poolDescription = "pool";
    [SerializeField] private string neonSignDescription = "neonSign";
    [SerializeField] private string rockConcertDescription = "rockConcert";
    [SerializeField] private string rollerCoasterDescription = "rollerCoaster";
    [SerializeField] private string witchBroomDescription = "witchBroom";
    [SerializeField] private string mcDonaldsDescription = "mcDonalds";
    [SerializeField] private string candySmellsDescription = "candySmells";
    [SerializeField] private string duckFeetDescription = "duckFeet";
    [SerializeField] private string freePuppiesDescription = "freePuppies";
    [SerializeField] private string balloonsDescription = "balloons";
    [SerializeField] private string baseCauldronDescription = "baseCauldron";
    [SerializeField] private string baseHouseDescription = "baseHouse";
    [SerializeField] private string houseExpansion3Description = "houseExpansion3";
    [SerializeField] private string decoyChildrenDescription = "decoyChildren";
    [SerializeField] private string telescopeDescription = "telescope";
    [SerializeField] private string fireInsuranceDescription = "fireInsurance";
    [SerializeField] private string rigElectionDescription = "rigElection";
    [SerializeField] private string decoyWitchHutDescription = "decoyWitchHut";
    [SerializeField] private string frameWerewolvesDescription = "frameWerewolves";
    [SerializeField] private string changeTrailSignsDescription = "changeTrailSigns";
    [SerializeField] private string hideTrueIdentityDescription = "hideTrueIdentity";
    [SerializeField] private string yourSoulDescription = "yourSoul";
    [SerializeField] private string soulMateSoulDescription = "soulMateSoul";
    [SerializeField] private string firstBornDescription = "firstBorn";
    [SerializeField] private string favoriteMemoryDescription = "favoritMemory";
    [SerializeField] private string fiveYearsDescription = "fiveYears";
    [SerializeField] private string powerOfAttorneyDescription = "powerOfAttorney";
    [SerializeField] private string leftFromRightDescription = "leftFromRight";
    [SerializeField] private string socialSecurityDescription = "socialSecurity";


    [Header("MOB CHANCE INCREASE")]
    [SerializeField] private int candyBasket1Chance = 4;
    [SerializeField] private int candyBasket2Chance = 4;
    [SerializeField] private int candySignChance = 4;
    [SerializeField] private int bigCauldronChance = 4;
    [SerializeField] private int candifyHouse1Chance = 4;
    [SerializeField] private int candifyHouse2Chance = 4;
    [SerializeField] private int houseExpansion1Chance = 4;
    [SerializeField] private int houseExpansion2Chance = 4;
    [SerializeField] private int ballPitChance = 4;
    [SerializeField] private int dronesChance = 4;
    [SerializeField] private int ponyChance = 4;
    [SerializeField] private int arcadeChance = 4;
    [SerializeField] private int tRexChance = 4;
    [SerializeField] private int poolChance = 4;
    [SerializeField] private int neonSignChance = 4;
    [SerializeField] private int rockConcertChance = 4;
    [SerializeField] private int rollerCoasterChance = 4;
    [SerializeField] private int witchBroomChance = 4;
    [SerializeField] private int mcDonaldsChance = 4;
    [SerializeField] private int candySmellsChance = 4;
    [SerializeField] private int duckFeetChance = 4;
    [SerializeField] private int freePuppiesChance = 4;
    [SerializeField] private int balloonsChance = 4;
    [SerializeField] private int baseCauldronChance = 4;
    [SerializeField] private int baseHouseChance = 4;
    [SerializeField] private int houseExpansion3Chance = 4;
    [SerializeField] private int decoyChildrenChance = -5;
    [SerializeField] private int telescopeChance = -5;
    [SerializeField] private int fireInsuranceChance = -5;
    [SerializeField] private int rigElectionChance = -5;
    [SerializeField] private int decoyWitchHutChance = -5;
    [SerializeField] private int frameWerewolvesChance = -5;
    [SerializeField] private int changeTrailSignsChance = -5;
    [SerializeField] private int hideTrueIdentityChance = -5;

    [Header("OFFERS SOUL AMOUNTS")]
    [SerializeField] private int yourSoulSoulAmount = 200;
    [SerializeField] private int soulMateSoulSoulAmount = 200;
    [SerializeField] private int firstBornSoulAmount = 300;
    [SerializeField] private int favoriteMemorySoulAmount = 300;
    [SerializeField] private int fiveYearsSoulAmount = 300;
    [SerializeField] private int powerOfAttorneySoulAmount = 400;
    [SerializeField] private int leftFromRightSoulAmount = 400;
    [SerializeField] private int socialSecuritySoulAmount = 400;

    public string GetDisplayName(PurchaseItemType _type)
    {
        string displayNameString = "";

        switch (_type)
        {
            case PurchaseItemType.CandyBasket1:
                displayNameString = candyBasket1Name;
                break;

            case PurchaseItemType.CandyBasket2:
                displayNameString = candyBasket2Name;
                break;

            case PurchaseItemType.CandySign:
                displayNameString = candySignName;
                break;

            case PurchaseItemType.BigCauldron:
                displayNameString = bigCauldronName;
                break;

            case PurchaseItemType.CandifyHouse1:
                displayNameString = candifyHouse1Name;
                break;

            case PurchaseItemType.CandifyHouse2:
                displayNameString = candifyHouse2Name;
                break;

            case PurchaseItemType.HouseExpansion1:
                displayNameString = houseExpansion1Name;
                break;

            case PurchaseItemType.HouseExpansion2:
                displayNameString = houseExpansion2Name;
                break;

            case PurchaseItemType.BallPit:
                displayNameString = ballPitName;
                break;

            case PurchaseItemType.Drones:
                displayNameString = dronesName;
                break;

            case PurchaseItemType.Pony:
                displayNameString = ponyName;
                break;

            case PurchaseItemType.Arcade:
                displayNameString = arcadeName;
                break;

            case PurchaseItemType.TRex:
                displayNameString = tRexName;
                break;

            case PurchaseItemType.Pool:
                displayNameString = poolName;
                break;

            case PurchaseItemType.NeonSign:
                displayNameString = neonSignName;
                break;

            case PurchaseItemType.RockConcert:
                displayNameString = rockConcertName;
                break;

            case PurchaseItemType.RollerCoaster:
                displayNameString = rollerCoasterName;
                break;

            case PurchaseItemType.WitchBroom:
                displayNameString = witchBroomName;
                break;

            case PurchaseItemType.McDonalds:
                displayNameString = mcDonaldsName;
                break;

            case PurchaseItemType.CandySmells:
                displayNameString = candySmellsName;
                break;

            case PurchaseItemType.DuckFeet:
                displayNameString = duckFeetName;
                break;

            case PurchaseItemType.FreePuppies:
                displayNameString = freePuppiesName;
                break;

            case PurchaseItemType.Balloons:
                displayNameString = balloonsName;
                break;

            case PurchaseItemType.BaseCauldron:
                displayNameString = baseCauldronName;
                break;

            case PurchaseItemType.BaseHouse:
                displayNameString = baseHouseName;
                break;

            case PurchaseItemType.HouseExpansion3:
                displayNameString = houseExpansion3Name;
                break;

            case PurchaseItemType.DecoyChildren:
                displayNameString = decoyChildrenName;
                break;

            case PurchaseItemType.Telescope:
                displayNameString = telescopeName;
                break;

            case PurchaseItemType.FireInsurance:
                displayNameString = fireInsuranceName;
                break;

            case PurchaseItemType.RigElection:
                displayNameString = rigElectionName;
                break;

            case PurchaseItemType.DecoyWitchHut:
                displayNameString = decoyWitchHutName;
                break;

            case PurchaseItemType.FrameWerewolves:
                displayNameString = frameWerewolvesName;
                break;

            case PurchaseItemType.ChangeTrailSigns:
                displayNameString = changeTrailSignsName;
                break;

            case PurchaseItemType.HideTrueIdentity:
                displayNameString = hideTrueIdentityName;
                break;

            case PurchaseItemType.YourSoul:
                displayNameString = yourSoulName;
                break;

            case PurchaseItemType.SoulMateSoul:
                displayNameString = soulMateSoulName;
                break;

            case PurchaseItemType.FirstBorn:
                displayNameString = firstBornName;
                break;

            case PurchaseItemType.FavoriteMemory:
                displayNameString = favoriteMemoryName;
                break;

            case PurchaseItemType.FiveYears:
                displayNameString = fiveYearsName;
                break;

            case PurchaseItemType.PowerOfAttorney:
                displayNameString = powerOfAttorneyName;
                break;

            case PurchaseItemType.LeftFromRight:
                displayNameString = leftFromRightName;
                break;

            case PurchaseItemType.SocialSecurity:
                displayNameString = socialSecurityName;
                break;

            default:
                displayNameString = "";
                break;
        }

        return displayNameString;
    }

    public string GetItemID(PurchaseItemType _type)
    {
        string itemID = "";

        switch (_type)
        {
            case PurchaseItemType.CandyBasket1:
                itemID = candyBasket1ID;
                break;

            case PurchaseItemType.CandyBasket2:
                itemID = candyBasket2ID;
                break;

            case PurchaseItemType.CandySign:
                itemID = candySignID;
                break;

            case PurchaseItemType.BigCauldron:
                itemID = bigCauldronID;
                break;

            case PurchaseItemType.CandifyHouse1:
                itemID = candifyHouse1ID;
                break;

            case PurchaseItemType.CandifyHouse2:
                itemID = candifyHouse2ID;
                break;

            case PurchaseItemType.HouseExpansion1:
                itemID = houseExpansion1ID;
                break;

            case PurchaseItemType.HouseExpansion2:
                itemID = houseExpansion2ID;
                break;

            case PurchaseItemType.BallPit:
                itemID = ballPitID;
                break;

            case PurchaseItemType.Drones:
                itemID = dronesID;
                break;

            case PurchaseItemType.Pony:
                itemID = ponyID;
                break;

            case PurchaseItemType.Arcade:
                itemID = arcadeID;
                break;

            case PurchaseItemType.TRex:
                itemID = tRexID;
                break;

            case PurchaseItemType.Pool:
                itemID = poolID;
                break;

            case PurchaseItemType.NeonSign:
                itemID = neonSignID;
                break;

            case PurchaseItemType.RockConcert:
                itemID = rockConcertID;
                break;

            case PurchaseItemType.RollerCoaster:
                itemID = rollerCoasterID;
                break;

            case PurchaseItemType.WitchBroom:
                itemID = witchBroomID;
                break;

            case PurchaseItemType.McDonalds:
                itemID = mcDonaldsID;
                break;

            case PurchaseItemType.CandySmells:
                itemID = candySmellsID;
                break;

            case PurchaseItemType.DuckFeet:
                itemID = duckFeetID;
                break;

            case PurchaseItemType.FreePuppies:
                itemID = freePuppiesID;
                break;

            case PurchaseItemType.Balloons:
                itemID = balloonsID;
                break;

            case PurchaseItemType.BaseCauldron:
                itemID = baseCauldronID;
                break;

            case PurchaseItemType.BaseHouse:
                itemID = baseHouseID;
                break;

            case PurchaseItemType.HouseExpansion3:
                itemID = houseExpansion3ID;
                break;

            case PurchaseItemType.DecoyChildren:
                itemID = decoyChildrenID;
                break;

            case PurchaseItemType.Telescope:
                itemID = telescopeID;
                break;

            case PurchaseItemType.FireInsurance:
                itemID = fireInsuranceID;
                break;

            case PurchaseItemType.RigElection:
                itemID = rigElectionID;
                break;

            case PurchaseItemType.DecoyWitchHut:
                itemID = decoyWitchHutID;
                break;

            case PurchaseItemType.FrameWerewolves:
                itemID = frameWerewolvesID;
                break;

            case PurchaseItemType.ChangeTrailSigns:
                itemID = changeTrailSignsID;
                break;

            case PurchaseItemType.HideTrueIdentity:
                itemID = hideTrueIdentityID;
                break;

            case PurchaseItemType.YourSoul:
                itemID = yourSoulID;
                break;

            case PurchaseItemType.SoulMateSoul:
                itemID = soulMateSoulID;
                break;

            case PurchaseItemType.FirstBorn:
                itemID = firstBornID;
                break;

            case PurchaseItemType.FavoriteMemory:
                itemID = favoriteMemoryID;
                break;

            case PurchaseItemType.FiveYears:
                itemID = fiveYearsID;
                break;

            case PurchaseItemType.PowerOfAttorney:
                itemID = powerOfAttorneyID;
                break;

            case PurchaseItemType.LeftFromRight:
                itemID = leftFromRightID;
                break;

            case PurchaseItemType.SocialSecurity:
                itemID = socialSecurityID;
                break;

            default:
                itemID = "";
                break;
        }

        return itemID;
    }

    public int GetItemPrice(PurchaseItemType _type)
    {
        int itemPrice = 0;

        switch (_type)
        {
            case PurchaseItemType.CandyBasket1:
                itemPrice = candyBasket1Price;
                break;

            case PurchaseItemType.CandyBasket2:
                itemPrice = candyBasket2Price;
                break;

            case PurchaseItemType.CandySign:
                itemPrice = candySignPrice;
                break;

            case PurchaseItemType.BigCauldron:
                itemPrice = bigCauldronPrice;
                break;

            case PurchaseItemType.CandifyHouse1:
                itemPrice = candifyHouse1Price;
                break;

            case PurchaseItemType.CandifyHouse2:
                itemPrice = candifyHouse2Price;
                break;

            case PurchaseItemType.HouseExpansion1:
                itemPrice = houseExpansion1Price;
                break;

            case PurchaseItemType.HouseExpansion2:
                itemPrice = houseExpansion2Price;
                break;

            case PurchaseItemType.BallPit:
                itemPrice = ballPitPrice;
                break;

            case PurchaseItemType.Drones:
                itemPrice = dronesPrice;
                break;

            case PurchaseItemType.Pony:
                itemPrice = ponyPrice;
                break;

            case PurchaseItemType.Arcade:
                itemPrice = arcadePrice;
                break;

            case PurchaseItemType.TRex:
                itemPrice = tRexPrice;
                break;

            case PurchaseItemType.Pool:
                itemPrice = poolPrice;
                break;

            case PurchaseItemType.NeonSign:
                itemPrice = neonSignPrice;
                break;

            case PurchaseItemType.RockConcert:
                itemPrice = rockConcertPrice;
                break;

            case PurchaseItemType.RollerCoaster:
                itemPrice = rollerCoasterPrice;
                break;

            case PurchaseItemType.WitchBroom:
                itemPrice = witchBroomPrice;
                break;

            case PurchaseItemType.McDonalds:
                itemPrice = mcDonaldsPrice;
                break;

            case PurchaseItemType.CandySmells:
                itemPrice = candySmellsPrice;
                break;

            case PurchaseItemType.DuckFeet:
                itemPrice = duckFeetPrice;
                break;

            case PurchaseItemType.FreePuppies:
                itemPrice = freePuppiesPrice;
                break;

            case PurchaseItemType.Balloons:
                itemPrice = balloonsPrice;
                break;

            case PurchaseItemType.BaseCauldron:
                itemPrice = baseCauldronPrice;
                break;

            case PurchaseItemType.BaseHouse:
                itemPrice = baseHousePrice;
                break;

            case PurchaseItemType.HouseExpansion3:
                itemPrice = houseExpansion3Price;
                break;

            case PurchaseItemType.DecoyChildren:
                itemPrice = decoyChildrenPrice;
                break;

            case PurchaseItemType.Telescope:
                itemPrice = telescopePrice;
                break;

            case PurchaseItemType.FireInsurance:
                itemPrice = fireInsurancePrice;
                break;

            case PurchaseItemType.RigElection:
                itemPrice = rigElectionPrice;
                break;

            case PurchaseItemType.DecoyWitchHut:
                itemPrice = decoyWitchHutPrice;
                break;

            case PurchaseItemType.FrameWerewolves:
                itemPrice = frameWerewolvesPrice;
                break;

            case PurchaseItemType.ChangeTrailSigns:
                itemPrice = changeTrailSignsPrice;
                break;

            case PurchaseItemType.HideTrueIdentity:
                itemPrice = hideTrueIdentityPrice;
                break;

            case PurchaseItemType.YourSoul:
                itemPrice = yourSoulPrice;
                break;

            case PurchaseItemType.SoulMateSoul:
                itemPrice = soulMateSoulPrice;
                break;

            case PurchaseItemType.FirstBorn:
                itemPrice = firstBornPrice;
                break;

            case PurchaseItemType.FavoriteMemory:
                itemPrice = favoriteMemoryPrice;
                break;

            case PurchaseItemType.FiveYears:
                itemPrice = fiveYearsPrice;
                break;

            case PurchaseItemType.PowerOfAttorney:
                itemPrice = powerOfAttorneyPrice;
                break;

            case PurchaseItemType.LeftFromRight:
                itemPrice = leftFromRightPrice;
                break;

            case PurchaseItemType.SocialSecurity:
                itemPrice = socialSecurityPrice;
                break;

            default:
                itemPrice = 0;
                break;
        }

        return itemPrice;
    }

    public string GetDisplayDescription(PurchaseItemType _type)
    {
        string displayDescription = "";

        switch (_type)
        {
            case PurchaseItemType.CandyBasket1:
                displayDescription = candyBasket1Description;
                break;

            case PurchaseItemType.CandyBasket2:
                displayDescription = candyBasket2Description;
                break;

            case PurchaseItemType.CandySign:
                displayDescription = candySignDescription;
                break;

            case PurchaseItemType.BigCauldron:
                displayDescription = bigCauldronDescription;
                break;

            case PurchaseItemType.CandifyHouse1:
                displayDescription = candifyHouse1Description;
                break;

            case PurchaseItemType.CandifyHouse2:
                displayDescription = candifyHouse2Description;
                break;

            case PurchaseItemType.HouseExpansion1:
                displayDescription = houseExpansion1Description;
                break;

            case PurchaseItemType.HouseExpansion2:
                displayDescription = houseExpansion2Description;
                break;

            case PurchaseItemType.BallPit:
                displayDescription = ballPitDescription;
                break;

            case PurchaseItemType.Drones:
                displayDescription = dronesDescription;
                break;

            case PurchaseItemType.Pony:
                displayDescription = ponyDescription;
                break;

            case PurchaseItemType.Arcade:
                displayDescription = arcadeDescription;
                break;

            case PurchaseItemType.TRex:
                displayDescription = tRexDescription;
                break;

            case PurchaseItemType.Pool:
                displayDescription = poolDescription;
                break;

            case PurchaseItemType.NeonSign:
                displayDescription = neonSignDescription;
                break;

            case PurchaseItemType.RockConcert:
                displayDescription = rockConcertDescription;
                break;

            case PurchaseItemType.RollerCoaster:
                displayDescription = rollerCoasterDescription;
                break;

            case PurchaseItemType.WitchBroom:
                displayDescription = witchBroomDescription;
                break;

            case PurchaseItemType.McDonalds:
                displayDescription = mcDonaldsDescription;
                break;

            case PurchaseItemType.CandySmells:
                displayDescription = candySmellsDescription;
                break;

            case PurchaseItemType.DuckFeet:
                displayDescription = duckFeetDescription;
                break;

            case PurchaseItemType.FreePuppies:
                displayDescription = freePuppiesDescription;
                break;

            case PurchaseItemType.Balloons:
                displayDescription = balloonsDescription;
                break;

            case PurchaseItemType.BaseCauldron:
                displayDescription = baseCauldronDescription;
                break;

            case PurchaseItemType.BaseHouse:
                displayDescription = baseHouseDescription;
                break;

            case PurchaseItemType.HouseExpansion3:
                displayDescription = houseExpansion3Description;
                break;

            case PurchaseItemType.DecoyChildren:
                displayDescription = decoyChildrenDescription;
                break;

            case PurchaseItemType.Telescope:
                displayDescription = telescopeDescription;
                break;

            case PurchaseItemType.FireInsurance:
                displayDescription = fireInsuranceDescription;
                break;

            case PurchaseItemType.RigElection:
                displayDescription = rigElectionDescription;
                break;

            case PurchaseItemType.DecoyWitchHut:
                displayDescription = decoyWitchHutDescription;
                break;

            case PurchaseItemType.FrameWerewolves:
                displayDescription = frameWerewolvesDescription;
                break;

            case PurchaseItemType.ChangeTrailSigns:
                displayDescription = changeTrailSignsDescription;
                break;

            case PurchaseItemType.HideTrueIdentity:
                displayDescription = hideTrueIdentityDescription;
                break;

            case PurchaseItemType.YourSoul:
                displayDescription = yourSoulDescription;
                break;

            case PurchaseItemType.SoulMateSoul:
                displayDescription = soulMateSoulDescription;
                break;

            case PurchaseItemType.FirstBorn:
                displayDescription = firstBornDescription;
                break;

            case PurchaseItemType.FavoriteMemory:
                displayDescription = favoriteMemoryDescription;
                break;

            case PurchaseItemType.FiveYears:
                displayDescription = fiveYearsDescription;
                break;

            case PurchaseItemType.PowerOfAttorney:
                displayDescription = powerOfAttorneyDescription;
                break;

            case PurchaseItemType.LeftFromRight:
                displayDescription = leftFromRightDescription;
                break;

            case PurchaseItemType.SocialSecurity:
                displayDescription = socialSecurityDescription;
                break;

            default:
                displayDescription = "";
                break;
        }

        return displayDescription;
    }

    public int GetItemChanceChange(PurchaseItemType _type)
    {
        int chanceChange = 0;

        switch (_type)
        {
            case PurchaseItemType.CandyBasket1:
                chanceChange = candyBasket1Chance;
                break;

            case PurchaseItemType.CandyBasket2:
                chanceChange = candyBasket2Chance;
                break;

            case PurchaseItemType.CandySign:
                chanceChange = candySignChance;
                break;

            case PurchaseItemType.BigCauldron:
                chanceChange = bigCauldronChance;
                break;

            case PurchaseItemType.CandifyHouse1:
                chanceChange = candifyHouse1Chance;
                break;

            case PurchaseItemType.CandifyHouse2:
                chanceChange = candifyHouse2Chance;
                break;

            case PurchaseItemType.HouseExpansion1:
                chanceChange = houseExpansion1Chance;
                break;

            case PurchaseItemType.HouseExpansion2:
                chanceChange = houseExpansion2Chance;
                break;

            case PurchaseItemType.BallPit:
                chanceChange = ballPitChance;
                break;

            case PurchaseItemType.Drones:
                chanceChange = dronesChance;
                break;

            case PurchaseItemType.Pony:
                chanceChange = ponyChance;
                break;

            case PurchaseItemType.Arcade:
                chanceChange = arcadeChance;
                break;

            case PurchaseItemType.TRex:
                chanceChange = tRexChance;
                break;

            case PurchaseItemType.Pool:
                chanceChange = poolChance;
                break;

            case PurchaseItemType.NeonSign:
                chanceChange = neonSignChance;
                break;

            case PurchaseItemType.RockConcert:
                chanceChange = rockConcertChance;
                break;

            case PurchaseItemType.RollerCoaster:
                chanceChange = rollerCoasterChance;
                break;

            case PurchaseItemType.WitchBroom:
                chanceChange = witchBroomChance;
                break;

            case PurchaseItemType.McDonalds:
                chanceChange = mcDonaldsChance;
                break;

            case PurchaseItemType.CandySmells:
                chanceChange = candySmellsChance;
                break;

            case PurchaseItemType.DuckFeet:
                chanceChange = duckFeetChance;
                break;

            case PurchaseItemType.FreePuppies:
                chanceChange = freePuppiesChance;
                break;

            case PurchaseItemType.Balloons:
                chanceChange = balloonsChance;
                break;

            case PurchaseItemType.BaseCauldron:
                chanceChange = baseCauldronChance;
                break;

            case PurchaseItemType.BaseHouse:
                chanceChange = baseHouseChance;
                break;

            case PurchaseItemType.HouseExpansion3:
                chanceChange = houseExpansion3Chance;
                break;

            case PurchaseItemType.DecoyChildren:
                chanceChange = decoyChildrenChance;
                break;

            case PurchaseItemType.Telescope:
                chanceChange = telescopeChance;
                break;

            case PurchaseItemType.FireInsurance:
                chanceChange = fireInsuranceChance;
                break;

            case PurchaseItemType.RigElection:
                chanceChange = rigElectionChance;
                break;

            case PurchaseItemType.DecoyWitchHut:
                chanceChange = decoyWitchHutChance;
                break;

            case PurchaseItemType.FrameWerewolves:
                chanceChange = frameWerewolvesChance;
                break;

            case PurchaseItemType.ChangeTrailSigns:
                chanceChange = changeTrailSignsChance;
                break;

            case PurchaseItemType.HideTrueIdentity:
                chanceChange = hideTrueIdentityChance;
                break;

            default:
                chanceChange = 0;
                break;
        }

        return chanceChange;
    }

    public int GetOfferSoulAmount(PurchaseItemType _type)
    {
        int soulAmount = 0;

        switch (_type)
        {
            case PurchaseItemType.YourSoul:
                soulAmount = yourSoulSoulAmount;
                break;

            case PurchaseItemType.SoulMateSoul:
                soulAmount = soulMateSoulSoulAmount;
                break;

            case PurchaseItemType.FirstBorn:
                soulAmount = firstBornSoulAmount;
                break;

            case PurchaseItemType.FavoriteMemory:
                soulAmount = favoriteMemorySoulAmount;
                break;

            case PurchaseItemType.FiveYears:
                soulAmount = fiveYearsSoulAmount;
                break;

            case PurchaseItemType.PowerOfAttorney:
                soulAmount = powerOfAttorneySoulAmount;
                break;

            case PurchaseItemType.LeftFromRight:
                soulAmount = leftFromRightSoulAmount;
                break;

            case PurchaseItemType.SocialSecurity:
                soulAmount = socialSecuritySoulAmount;
                break;

            default:
                soulAmount = 0;
                break;
        }

        return soulAmount;
    }
}
