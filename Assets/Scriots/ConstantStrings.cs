using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PurchaseItemType { CandyBasket1, CandyBasket2, CandySign, BigCauldron, CandifyHouse1, CandifyHouse2, HouseExpansion1,
    HouseExpansion2, BallPit, Drones, Pony, Arcade, TRex, Pool, NeonSign, RockConcert, RollerCoaster,
    WitchBroom, McDonalds, CandySmells, DuckFeet, FreePuppies, Balloons, BaseCauldron }

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
                itemID = baseCauldronName;
                break;

            default:
                itemID = "";
                break;
        }

        return itemID;
    }

}
