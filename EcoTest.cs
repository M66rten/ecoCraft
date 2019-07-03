using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EcoTest : MonoBehaviour
{
    // Invest Buttons
    public Button OneThousand;
    public Button TwoThousand;
    public Button ThreeThousand;
    public Button FiveThousand;

    // Influence
    public int influence = 0;

    // Floating Text
    public Text CashEarnedText;
    public int cashEarned = 0;
    public Animator CashAnimation;
    public float CashWaitTime = 10f;

    // Variables
    public int cash = 10000;
    public int week = 1;
    public float happiness = 30;
    public float eco = 10f;

    // UI
    public GameObject UI;
    public GameObject Introduction;
    public Text weekText;
    public Text ecoText;
    public Text happinessText;
    public Text cashText;
    public Text populationText;
    public Text investAmountText;
    public Text investOptionText;
    public GameObject ReportCard;
    // Investment
    public int investChoice;
    public int investAmount;
    // Cards
    public bool isDrawing = false;
    public int draw;
    public int hand;
    public bool handCard1 = false;
    public bool handCard2 = false;
    public bool handCard3 = false;
    public bool handCard4 = false;
    public bool handCard5 = false;
    public bool handCard6 = false;
    public bool handCard7 = false;
    public bool handCard8 = false;
    public bool handCard9 = false;
    public bool handCard10 = false;
    // Card Game Obejcts
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;
    public GameObject card9;
    public GameObject card10;
    // Color
    Color colorStart = Color.black;
    Color colorEnd = new Color(0.2f, 0.4f, 0.1f, 1.0f);
    Renderer rend;
    public float ecoColor;
    // Color Selected Object
    public Material sharedMaterial;
    public GameObject colorGameObject;
    // Shop
    public bool ownAppartement1;
    public GameObject Appartement1;
    public Button Appartement1Button;
    public bool ownAppartement2;
    public GameObject Appartement2;
    public Button Appartement2Button;
    public bool ownAppartement3;
    public GameObject Appartement3;
    public Button Appartement3Button;
    public bool ownAppartement4;
    public GameObject Appartement4;
    public Button Appartement4Button;
    public bool ownWindmill;
    public GameObject Windmill;
    public Button WindmillButton;
    public bool ownTreeswing;
    public GameObject Treeswing;
    public Button TreeswingButton;
    public bool ownCottage1;
    public GameObject Cottage1;
    public Button Cottage1Button;
    public bool ownCottage2;
    public GameObject Cottage2;
    public Button Cottage2Button;
    public bool ownBeetSeed, ownCarrotSeed, ownPotatoSeed, ownGuavaSeed;
    public Button BeetButton, CarrotButton, PotatoButton, GuavaButton;
    public GameObject Farm;
    public bool ownLights;
    public GameObject lights;
    public Button lightsButton;
    public bool ownBin;
    public GameObject bins;
    public Button binsButton;
    public bool ownFourth;
    public GameObject fourth;
    public Button fourthHouseButton;
    public bool ownFifth;
    public GameObject fifth;
    public Button fifthHouseButton;
    public bool ownSixth;
    public GameObject sixth;
    public Button sixthHouseButton;
    public bool ownSeventh;
    public GameObject seventh;
    public Button seventhHouseButton;
    public bool ownEighth;
    public GameObject eighth;
    public Button eighthHouseButton;
    public bool ownNinth;
    public GameObject ninth;
    public Button ninthHouseButton;
    public bool ownBench;
    public GameObject Benches;
    public Button BenchesButton;
    // Farm
    public Harvest harvestObj;
    // Card Visuals
    public GameObject Card2Obj;
    public bool Card2isOn = false;
    public GameObject Card3Obj;
    public bool Card3isOn = false;
    public GameObject Card8Stage1;
    public GameObject Card8Stage2;
    public GameObject Card8Stage3;
    public GameObject Card8Stage4;
    public bool Card8isOn = false;
    public int CoalStage = 0;
    public GameObject Card9Obj;
    public bool Card9isOn = false;
    public GameObject Card10Obj;
    public bool Card10isOn = false;
    // NPC Link
    public NPCsystem npcObj;
    // Report
    public reportcalculations reportObj;
    // NPCs
    public GameObject Charles;
    public GameObject Christian;
    public GameObject Jack;

    public void ShowFloatingText()
    {
        if(cashEarned > 0)
        {
            CashEarnedText.text = "+ " + Mathf.Abs(cashEarned);
            Debug.Log("Spawned floating text");
            CashEarnedText.color = Color.green;
        }

        if (cashEarned == 0)
        {
            CashEarnedText.text = "";
        }

        if (cashEarned < 0)
        {
            CashEarnedText.text = "- " + Mathf.Abs(cashEarned);
            Debug.Log("Spawned floating text");
            CashEarnedText.color = Color.red;
        }

    }

    void Start()
    {
        // NPCs
        Charles.SetActive(false);
        Christian.SetActive(false);
        Jack.SetActive(false);

        // Cash Earned Start
        CashEarnedText.text = "";

        // Report
        ReportCard.SetActive(false);

        // Renderer Color

        rend = colorGameObject.GetComponent<Renderer>();

        // Objects
        
        Treeswing.SetActive(false);
        Appartement1.SetActive(false);
        Appartement2.SetActive(false);
        Appartement3.SetActive(false);
        Appartement4.SetActive(false);
        Windmill.SetActive(false);
        Cottage1.SetActive(false);
        Cottage2.SetActive(false);
        Benches.SetActive(false);
        bins.SetActive(false);
        lights.SetActive(false);
        fourth.SetActive(false);
        fifth.SetActive(false);
        sixth.SetActive(false);
        seventh.SetActive(false);
        eighth.SetActive(false);
        ninth.SetActive(false);
        // Cards
        isDrawing = true;
        // UI
        UI.SetActive(false);

        // Coloring

        ecoColor = (eco / 100);
        rend.sharedMaterial.shader = Shader.Find("Standard");
        rend.sharedMaterial.color = Color.Lerp(colorStart, colorEnd, ecoColor);

        // Introduction
        Introduction.SetActive(false);

        // Coal Disabled
        Card8Stage1.SetActive(false);
        Card8Stage2.SetActive(false);
        Card8Stage3.SetActive(false);
        Card8Stage4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Invest Buttons

        if(cash < 1000)
        {
            OneThousand.interactable = (false);
        }

        if (cash >= 1000)
        {
            OneThousand.interactable = (true);
        }

        if (cash < 2000)
        {
            TwoThousand.interactable = (false);
        }

        if (cash >= 2000)
        {
            TwoThousand.interactable = (true);
        }

        if (cash < 3000)
        {
            ThreeThousand.interactable = (false);
        }

        if (cash >= 3000)
        {
            ThreeThousand.interactable = (true);
        }

        if (cash < 5000)
        {
            FiveThousand.interactable = (false);
        }

        if (cash >= 5000)
        {
            FiveThousand.interactable = (true);
        }


        // Limits

        if (eco <= 0)
        {
            eco = 0;
        }

        if (eco >= 100)
        {
            eco = 100;
        }

        if (happiness <= 0)
        {
            happiness = 0;
        }

        if (happiness >= 100)
        {
            happiness = 100;
        }

        if (cash <= 0)
        {
            cash = 0;
        }

        if (investChoice == 1)
        {
            investOptionText.text = "Option: Environment";
        }

        if (investChoice == 2)
        {
            investOptionText.text = "Option: Fossil Fuels";
        }

        if (investChoice == 3)
        {
            investOptionText.text = "Option: Tech Research";
        }

        if (investChoice == 4)
        {
            investOptionText.text = "Option: Entertainment";
        }

        if (investChoice == 0)
        {
            investOptionText.text = "Option: None";
        }

        // UI

        weekText.text = week.ToString();
        ecoText.text = eco.ToString();
        happinessText.text = happiness.ToString();
        cashText.text = cash.ToString();
        populationText.text = npcObj.numSpawned.ToString();
        investAmountText.text = "Amount: " + investAmount;
    }

    // Saving
    public void Save()
    {
        SaveLoad.Save();
    }

    // Loading
    public void Loading()
    {
        SaveLoad.Load();
    }

    // Check For Game Over
    public void EndGameCheck()
    {
        if (week == 52)
        {
            ReportCard.SetActive(true);
            reportObj.ReportFill();
        }
    }

    // Check For Christian
    public void NPCcheck()
    {
        if (week == 10)
        {
            Charles.SetActive(true);
        }

        if (week == 15)
        {
            Christian.SetActive(true);
        }

        if (week == 30)
        {
            Jack.SetActive(true);
        }
    }

    // Cash Earned is added
    public void CashEarnCheck()
    {
        cash = cash + cashEarned;
        CashAnimation.SetBool("CashFloatShowing", true);
        StartCoroutine(CashCoroutine());
    }

    IEnumerator CashCoroutine()
    {
        yield return new WaitForSeconds(3);
        cashEarned = 0;

        CashAnimation.SetBool("CashFloatShowing", false);

    }

    // Tax addition
    public void TaxAddition()
    {
        cashEarned = cashEarned + (npcObj.numNPC * 125);
    }

    // Buttons

    public void investButton1()
    {
        investChoice = 1;
    }

    public void investButton2()
    {
        investChoice = 2;
    }

    public void investButton3()
    {
        investChoice = 3;
    }

    public void investButton4()
    {
        investChoice = 4;
    }

    public void investAmount0()
    {
        investAmount = 0;
    }

    public void investAmount1000()
    {
        if (cash >= 1000)
        {
            investAmount = 1000;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void investAmount2000()
    {
        if (cash >= 2000)
        {
            investAmount = 2000;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void investAmount3000()
    {
        if (cash >= 3000)
        {
            investAmount = 3000;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void investAmount5000()
    {
        if (cash >= 5000)
        {
            investAmount = 5000;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void invest()
    {
        // Color
        ecoColor = (eco / 100);
        rend.sharedMaterial.shader = Shader.Find("Standard");
        rend.sharedMaterial.color = Color.Lerp(colorStart, colorEnd, ecoColor);

        // Choices

        if (investChoice == 1 && investAmount > 0)
        {
            cashEarned = cashEarned - investAmount;
            cashEarned = cashEarned + (investAmount * Random.Range(0, 80) / 100);
            eco = eco + (investAmount * Random.Range(110, 120) / 100000);
            happiness = happiness + 1;
        }

        if (investChoice == 2 && investAmount > 0)
        {
            cashEarned = cashEarned - investAmount;
            cashEarned = cashEarned + (investAmount * Random.Range(120, 140) / 100);
            eco = eco + (investAmount * Random.Range(-130, -120) / 100000);
        }

        if (investChoice == 3 && investAmount > 0)
        {
            cashEarned = cashEarned - investAmount;
            cashEarned = cashEarned + (investAmount * Random.Range(95, 130) / 100);
            eco = eco + (investAmount * Random.Range(-120, 90) / 100000);
        }

        if (investChoice == 4 && investAmount > 0)
        {
            cashEarned = cashEarned - investAmount;
            cashEarned = cashEarned + (investAmount * Random.Range(0, 200) / 100);
            eco = eco + (investAmount * Random.Range(-130, 130) / 100000);
            happiness = happiness + 2;
        }
    }

    // Shop

    public void BeetSeed()
    {
        if (((((ownBeetSeed == false && cash >= 500 && harvestObj.isGrowingBeet == false && ((investAmount + 500) <= cash)))  && ownCarrotSeed == false) && ownPotatoSeed == false) && ownGuavaSeed == false)
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownBeetSeed = (true);
            eco = eco + 1;

            cashEarned = cashEarned - 500;
            CashEarnCheck();
            ShowFloatingText();

            harvestObj.BeetSeeds.SetActive(true);

            BeetButton.interactable = false;
            CarrotButton.interactable = false;
            PotatoButton.interactable = false;
            GuavaButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void CarrotSeed()
    {
        if (((((ownCarrotSeed == false && cash >= 600 && harvestObj.isGrowingCarrot == false && ((investAmount + 600) <= cash))) && ownBeetSeed == false) && ownPotatoSeed == false) && ownGuavaSeed == false)
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownCarrotSeed = (true);
            eco = eco + 1;

            cashEarned = cashEarned - 600;
            CashEarnCheck();
            ShowFloatingText();

            harvestObj.CarrotSeeds.SetActive(true);

            BeetButton.interactable = false;
            CarrotButton.interactable = false;
            PotatoButton.interactable = false;
            GuavaButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void PotatoSeed()
    {
        if (((((ownPotatoSeed == false && cash >= 700 && harvestObj.isGrowingPotato == false && ((investAmount + 700) <= cash))) && ownCarrotSeed == false) && ownBeetSeed == false) && ownGuavaSeed == false)
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownPotatoSeed = (true);
            eco = eco + 1;

            cashEarned = cashEarned - 700;
            CashEarnCheck();
            ShowFloatingText();

            harvestObj.PotatoSeeds.SetActive(true);

            BeetButton.interactable = false;
            CarrotButton.interactable = false;
            PotatoButton.interactable = false;
            GuavaButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void GuavaSeed()
    {
        if (((((ownGuavaSeed == false && cash >= 800 && harvestObj.isGrowingGuava == false && ((investAmount + 800) <= cash))) && ownCarrotSeed == false) && ownBeetSeed == false) && ownPotatoSeed == false)
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownGuavaSeed = (true);
            eco = eco + 1;

            cashEarned = cashEarned - 800;
            CashEarnCheck();
            ShowFloatingText();

            harvestObj.GuavaSeeds.SetActive(true);

            BeetButton.interactable = false;
            CarrotButton.interactable = false;
            PotatoButton.interactable = false;
            GuavaButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void WindMillBonusCheck()
    {
        if(ownWindmill == true)
        {
            eco = eco + .5f;
        }
    }

    public void WindMill()
    {
        if (ownWindmill == false && cash >= 10000 && ((investAmount + 10000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownWindmill = (true);

            cashEarned = cashEarned - 10000;
            CashEarnCheck();
            ShowFloatingText();

            Windmill.SetActive(true);

            WindmillButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void TreeSwing()
    {
        if (ownTreeswing == false && cash >= 1000 && ((investAmount + 1000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownTreeswing = (true);

            cashEarned = cashEarned - 1000;
            CashEarnCheck();
            ShowFloatingText();

            happiness = happiness + 5;
            Treeswing.SetActive(true);

            TreeswingButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void AppartementOne()
    {
        if (ownAppartement1 == false && cash >= 30000 && ((investAmount + 30000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownAppartement1 = (true);

            cashEarned = cashEarned - 30000;
            CashEarnCheck();
            ShowFloatingText();

            happiness = happiness + 10;
            Appartement1.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 5;

            Appartement1Button.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void AppartementTwo()
    {
        if (ownAppartement2 == false && cash >= 31000 && ((investAmount + 31000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownAppartement2 = (true);

            cashEarned = cashEarned - 31000;
            CashEarnCheck();
            ShowFloatingText();

            happiness = happiness + 10;
            Appartement2.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 5;

            Appartement2Button.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void AppartementThree()
    {
        if (ownAppartement3 == false && cash >= 32000 && ((investAmount + 32000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownAppartement3 = (true);

            cashEarned = cashEarned - 32000;
            CashEarnCheck();
            ShowFloatingText();

            happiness = happiness + 10;
            Appartement3.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 5;

            Appartement3Button.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void AppartementFour()
    {
        if (ownAppartement4 == false && cash >= 33000 && ((investAmount + 33000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownAppartement4 = (true);

            cashEarned = cashEarned - 33000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            happiness = happiness + 10;
            Appartement4.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 5;

            Appartement4Button.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void Lights()
    {
        if (ownLights == false && cash >= 3000 && ((investAmount + 3000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownLights = (true);
            eco = eco - 1;

            cashEarned = cashEarned - 3000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            happiness = happiness + 10;
            lights.SetActive(true);

            lightsButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void Bins()
    {
        if(ownBin == false && cash >= 1500 && ((investAmount + 1500) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownBin = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 1500;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;

            bins.SetActive(true);

            binsButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void FourthHouse()
    {
        if (ownFourth == false && cash >= 10000 && ((investAmount + 10000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownFourth = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 10000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;

            fourth.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;

            fourthHouseButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void FifthHouse()
    {
        if (ownFifth == false && cash >= 10500 && ((investAmount + 10500) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownFifth = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 10500;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            fifth.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;

            fifthHouseButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void SixthHouse()
    {
        if (ownSixth == false && cash >= 11000 && ((investAmount + 1100) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownSixth = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 11000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            sixth.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;

            sixthHouseButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void SeventhHouse()
    {
        if (ownSeventh == false && cash >= 11500 && ((investAmount + 11500) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownSeventh = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 11500;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            seventh.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;

            seventhHouseButton.interactable = false;
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void EighthHouse()
    {
        if (ownEighth == false && cash >= 12000 && ((investAmount + 1200) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownEighth = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 12000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            eighth.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;
            eighthHouseButton.interactable = false;

        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void NinthHouse()
    {
        if (ownNinth == false && cash >= 12500 && ((investAmount + 12500) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownNinth = (true);
            eco = eco + 2;

            cashEarned = cashEarned - 12500;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            ninth.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 1;
            ninthHouseButton.interactable = false;

        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void Bench()
    {
        if (ownBench == false && cash >= 1500 && ((investAmount + 1500) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownBench = (true);
            happiness = happiness + 5;

            cashEarned = cashEarned - 1500;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;

            Benches.SetActive(true);

            BenchesButton.interactable = false;

        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void CottageOne()
    {
        if (ownCottage1 == false && cash >= 15000 && ((investAmount + 15000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownCottage1 = (true);
            happiness = happiness + 5;

            cashEarned = cashEarned - 15000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            Cottage1.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 2;

            Cottage1Button.interactable = false;

        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void CottageTwo()
    {
        if (ownCottage2 == false && cash >= 16000 && ((investAmount + 16000) <= cash))
        {
            FindObjectOfType<SoundManager>().Play("Cash");
            ownCottage2 = (true);
            happiness = happiness + 5;

            cashEarned = cashEarned - 16000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;


            Cottage2.SetActive(true);
            npcObj.numNPC = npcObj.numNPC + 2;

            Cottage2Button.interactable = false;

        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    // Next Turn & Card System

    public void Reset()
    {
        investAmount = 0;
        week = week + 1;
        isDrawing = true;
        eco = eco - 1;
    }

    public void drawCard()
    {
        if (isDrawing == true && hand <= 5)
        {
            draw = Random.Range(1, 11);

            if (draw == 1)
            {
                if (handCard1 == false)
                {
                    handCard1 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card1.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 2)
            {
                if (handCard2 == false)
                {
                    handCard2 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card2.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 3)
            {
                if (handCard3 == false)
                {
                    handCard3 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card3.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 4)
            {
                if (handCard4 == false)
                {
                    handCard4 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card4.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 5)
            {
                if (handCard5 == false)
                {
                    handCard5 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card5.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 6)
            {
                if (handCard6 == false)
                {
                    handCard6 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card6.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 7)
            {
                if (handCard7 == false)
                {
                    handCard7 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card7.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }
            
            if (draw == 8)
            {
                if (handCard8 == false)
                {
                    handCard8 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card8.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 9)
            {
                if (handCard9 == false)
                {
                    handCard9 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card9.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }

            if (draw == 10)
            {
                if (handCard10 == false)
                {
                    handCard10 = true;
                    hand = hand + 1;
                    isDrawing = false;
                    card10.SetActive(true);
                }
                else
                {
                    drawCard();
                }
            }
        }
    }

    // Card 1 = Large Cash Przie
    public void Card1()
    {
        card1.SetActive(false);
        cashEarned = cashEarned + 5000;
        CashEarnCheck();
        ShowFloatingText();

        cashEarned = 0;
        hand = hand - 1;
        handCard1 = (false);
    }

    // Card 2 = Community speech
    public void Card2()
    {
        card2.SetActive(false);
        happiness = happiness + 10;
        hand = hand - 1;
        handCard2 = (false);
        Card2isOn = true;
        Card2Obj.SetActive(true);
    }

    public void Card2Disable()
    {
        if (Card2isOn == true)
        {
            Card2isOn = false;
            Card2Obj.SetActive(false);
        }
    }


    // Card 3 = Smog filters
    public void Card3()
    {
        card3.SetActive(false);
        eco = eco + 5;
        hand = hand - 1;
        handCard3 = (false);
        Card3isOn = true;
        Card3Obj.SetActive(true);
    }

    public void Card3Disable()
    {
        if (Card3isOn == true)
        {
            Card3isOn = false;
            Card3Obj.SetActive(false);
        }
    }

    // Card 4 = Small Cash Prize
    public void Card4()
    {
        card4.SetActive(false);
        cashEarned = cashEarned + 2000;
        CashEarnCheck();
        ShowFloatingText();

        cashEarned = 0;
        hand = hand - 1;
        handCard4 = (false);
    }

    // Card 5 = Citizen Subsidy
    public void Card5()
    {
        if (cash >= 5000)
        {
            card5.SetActive(false);
            cashEarned = cashEarned - 5000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;
            happiness = happiness + 15;
            hand = hand - 1;
            handCard5 = (false);
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    // Card 6 = Increase Tax
    public void Card6()
    {
        card6.SetActive(false);
        cashEarned = cashEarned + 1000;
        CashEarnCheck();
        ShowFloatingText();

        cashEarned = 0;
        happiness = happiness - 5;
        hand = hand - 1;
        handCard6 = (false);
    }

    // Card 7 = Reduce Energy
    public void Card7()
    {
        card7.SetActive(false);
        eco = eco + 7;
        happiness = happiness - 5;
        hand = hand - 1;
        handCard7 = (false);
    }

    // Card 8 = Coal mining
    public void Card8()
    {
        card8.SetActive(false);

        cashEarned = cashEarned + 10000;
        CashEarnCheck();
        ShowFloatingText();

        cashEarned = 0;
        happiness = happiness - 10;
        eco = eco - 5;
        hand = hand - 1;
        handCard8 = (false);
        Card8isOn = true;
    }

    public void Card8Disable()
    {
        if (Card8isOn == true)
        {
            Card8isOn = false;

            CoalStage = CoalStage + 1;

            if (CoalStage == 1)
            {
                Card8Stage1.SetActive(true);
                Card8Stage2.SetActive(false);
                Card8Stage3.SetActive(false);
                Card8Stage4.SetActive(false);
            }

            if (CoalStage == 2)
            {
                Card8Stage1.SetActive(true);
                Card8Stage2.SetActive(true);
                Card8Stage3.SetActive(false);
                Card8Stage4.SetActive(false);
            }

            if (CoalStage == 3)
            {
                Card8Stage1.SetActive(true);
                Card8Stage2.SetActive(true);
                Card8Stage3.SetActive(true);
                Card8Stage4.SetActive(false);
            }

            if (CoalStage == 4)
            {
                Card8Stage1.SetActive(true);
                Card8Stage2.SetActive(true);
                Card8Stage3.SetActive(true);
                Card8Stage4.SetActive(true);
            }
        }
    }

    // Card 9 = Government Help
    public void Card9()
    {
        card9.SetActive(false);
        eco = eco + 5;

        cashEarned = cashEarned + 500;
        CashEarnCheck();
        ShowFloatingText();

        cashEarned = 0;
        hand = hand - 1;
        handCard9 = (false);
        Card9isOn = true;
        Card9Obj.SetActive(true);
    }

    public void Card9Disable()
    {
        if (Card9isOn == true)
        {
            Card9isOn = false;
            Card9Obj.SetActive(false);
        }
    }

    // Card 10 = Eco Movement
    public void Card10()
    {
        if(cash >= 1000)
        {
            card10.SetActive(false);
            eco = eco + 5;

            cashEarned = cashEarned - 1000;
            CashEarnCheck();
            ShowFloatingText();

            cashEarned = 0;

            hand = hand - 1;
            handCard10 = (false);
            Card10isOn = true;
            Card10Obj.SetActive(true);
        }
        else
        {
            FindObjectOfType<SoundManager>().Play("Wrong");
        }
    }

    public void Card10Disable()
    {
        if (Card10isOn == true)
        {
            Card10isOn = false;
            Card10Obj.SetActive(false);
        }
    }

    // Introduction
    public void IntroductionPageDisable()
    {
        Introduction.SetActive(false);
        UI.SetActive(true);
    }
}
