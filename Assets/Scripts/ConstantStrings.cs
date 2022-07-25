using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PurchaseItemType { CandyBasket1, CandyBasket2, CandySign, BigCauldron, CandifyHouse1, CandifyHouse2, HouseExpansion1,
    HouseExpansion2, BallPit, Drones, Pony, Arcade, TRex, Pool, NeonSign, RockConcert, RollerCoaster,
    WitchBroom, McDonalds, CandySmells, DuckFeet, FreePuppies, Balloons, BaseCauldron, BaseHouse, HouseExpansion3 }

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

    public const string built = "built";

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

            default:
                displayDescription = "";
                break;
        }

        return displayDescription;
    }
}
