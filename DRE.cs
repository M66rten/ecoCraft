using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DRE : MonoBehaviour
{
    public TextMeshProUGUI DREtitle;
    public TextMeshProUGUI DREbody;
    public Text DREoption1;
    public Text DREoption2;
    public int DRErng;
    public GameObject DREui;
    public GameObject SmogFilter;
    public EcoTest ecoObj;
    public bool isDREon;
    public bool ownSmogfilter;
    public bool ownNuclearDeal;
    public bool ownFreeTransit;
    public bool ownCars;
    public bool ownGarbage;

    public GameObject circus;
    public bool circusOn;

    // UI
    public Text weekText;
    public Text happinessText;
    public Text cashText;
    public Text populationText;

    private void Awake()
    {
        ownGarbage = (false);
        ownCars = (false);
        ownFreeTransit = (false);
        ownNuclearDeal = (false);
        DREui.SetActive(false);
        ownSmogfilter = (false);
        SmogFilter.SetActive(false);
    }

    public void Update()
    {
        // UI

        weekText.text = ecoObj.week.ToString();
        happinessText.text = ecoObj.happiness.ToString();
        cashText.text = ecoObj.cash.ToString();
        populationText.text = ecoObj.npcObj.numSpawned.ToString();
    }

    public void DREclicked()
    {
        DREui.SetActive(false);
        ecoObj.UI.SetActive(true);
        isDREon = (false);
    }

    public void DRE_Check()
    {
        if(ownSmogfilter == true)
        {
            ecoObj.eco = ecoObj.eco + .5f;
        }

        if (ownNuclearDeal == true)
        {
            ecoObj.eco = ecoObj.eco + .5f;
        }
    }

    public void DRE_Opion1()
    {
        // Repair damages
        if(DRErng == 1)
        {
            if(ecoObj.cash >= 5000)
            {
                ecoObj.happiness = ecoObj.happiness - 1;
                ecoObj.cashEarned = ecoObj.cashEarned - 5000;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Accept Nuclear deal
        if (DRErng == 2)
        {
            if (ecoObj.cash >= 30000)
            {
                ecoObj.happiness = ecoObj.happiness - 3;
                ownNuclearDeal = (true);
                ecoObj.cashEarned = ecoObj.cashEarned - 30000;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Buy smogfilter
        if (DRErng == 3)
        {
            if(ecoObj.cash >= 10000)
            {
                ownSmogfilter = (true);
                SmogFilter.SetActive(true);
                ecoObj.happiness = ecoObj.happiness - 1;
                ecoObj.cashEarned = ecoObj.cashEarned - 10000;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Environmental effort
        if (DRErng == 4)
        {
            if(ecoObj.cash >= 2500)
            {
                ecoObj.happiness = ecoObj.happiness + 2;
                ecoObj.eco = ecoObj.eco + 5;
                ecoObj.cashEarned = ecoObj.cashEarned - 2500;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Repair Damages
        if (DRErng == 5)
        {
            if(ecoObj.cash >= 1000)
            {
                ecoObj.cashEarned = ecoObj.cashEarned - 1000;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Charge cheap tickets
        if (DRErng == 6)
        {
            ecoObj.happiness = ecoObj.happiness + 5;
            ecoObj.cashEarned = ecoObj.cashEarned + 1000;
            ecoObj.CashEarnCheck();
            ecoObj.ShowFloatingText();

            ecoObj.cashEarned = 0;

            circus.SetActive(true);
            circusOn = true;

            DREclicked();
        }

        // Reduce emissions
        if (DRErng == 7)
        {
            ecoObj.happiness = ecoObj.happiness - 10;
            ecoObj.eco = ecoObj.eco + 5;

            DREclicked();
        }

        // Public Transit
        if (DRErng == 8)
        {
            if (ecoObj.cash >= 3500 && ownFreeTransit == false)
            {
                ecoObj.eco = ecoObj.eco + 5;
                ecoObj.happiness = ecoObj.happiness + 10;
                ecoObj.cashEarned = ecoObj.cashEarned - 3500;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();

                ownFreeTransit = true;
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Garbage system
        if (DRErng == 9)
        {
            if (ecoObj.cash >= 1500 && ownGarbage == false)
            {
                ecoObj.eco = ecoObj.eco + 5;
                ecoObj.happiness = ecoObj.happiness + 5;
                ecoObj.cashEarned = ecoObj.cashEarned - 1500;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                DREclicked();

                ownGarbage = true;
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }

        // Electric cars
        if (DRErng == 10)
        {
            if (ecoObj.cash >= 5000)
            {
                ecoObj.eco = ecoObj.eco + 10;
                ecoObj.happiness = ecoObj.happiness + 10;
                ecoObj.cashEarned = ecoObj.cashEarned - 5000;
                ecoObj.CashEarnCheck();
                ecoObj.ShowFloatingText();

                ecoObj.cashEarned = 0;

                ownCars = true;

                DREclicked();
            }
            else
            {
                FindObjectOfType<SoundManager>().Play("Wrong");
            }
        }
    }

    public void DRE_Option2()
    {
        // Increase tax to repair damages
        if (DRErng == 1)
        {
            ecoObj.happiness = ecoObj.happiness - 5;
            DREclicked();
        }

        // Decline Nuclear deal
        if (DRErng == 2)
        {
            DREclicked();
        }

        // Dont buy smogfilter
        if (DRErng == 3)
        {
            ecoObj.happiness = ecoObj.happiness - 5;
            ecoObj.eco = ecoObj.eco - 3;

            DREclicked();
        }

        // Do nothing
        if (DRErng == 4)
        {
            ecoObj.happiness = ecoObj.happiness - 5;

            DREclicked();
        }

        // Do nothing
        if (DRErng == 5)
        {
            ecoObj.happiness = ecoObj.happiness - 5;

            DREclicked();
        }

        // Charge expensive tickets
        if (DRErng == 6)
        {
            ecoObj.happiness = ecoObj.happiness + 1;
            ecoObj.cashEarned = ecoObj.cashEarned + 2000;
            ecoObj.CashEarnCheck();
            ecoObj.ShowFloatingText();
            DREclicked();

                        circus.SetActive(true);
            circusOn = true;
        }

        // Do nothing
        if (DRErng == 7)
        {
            ecoObj.happiness = ecoObj.happiness - 5;

            DREclicked();
        }

        // Public Transit
        if (DRErng == 8)
        {
            DREclicked();
        }

        // Garbage System
        if (DRErng == 9)
        {
            DREclicked();
        }

        // Electric Cars
        if (DRErng == 10)
        {
            DREclicked();
        }
    }

    public void DREroll()
    {
        DRErng = Random.Range(1, 14);

        if (DRErng == 1)
        {
            Debug.Log("DRE roll 1");
            DREtitle.text = "Heavy Storm";
            DREbody.text = "A heavy storm hit the town.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Repair damages: 5000";
            DREoption2.text = "Increase tax to repair damages";
        }

        if ((DRErng == 2 && ownNuclearDeal == false) && ecoObj.cash >= 30000)
        {
            Debug.Log("DRE roll 2");
            DREtitle.text = "Nuclear Energy";
            DREbody.text = "A nuclear power company is offering to provide your city with clean nuclear energy for 30000";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Accept deal: 30000";
            DREoption2.text = "Decline deal";

        }

        if (DRErng == 3 && ownSmogfilter == false)
        {
            Debug.Log("DRE roll 3");
            DREtitle.text = "Smog";
            DREbody.text = "The air is thick with smog.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Buy a Smogfilter: 10000";
            DREoption2.text = "Don't buy a Smogfilter";
        }

        if (DRErng == 4 && ecoObj.eco < 50)
        {
            Debug.Log("DRE roll 4");
            DREtitle.text = "Civilian Complaints";
            DREbody.text = "Citizens are complaining about the state of the environment.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            ecoObj.happiness = ecoObj.happiness - 10;

            DREoption1.text = "Environmental effort: 2500";
            DREoption2.text = "Do nothing";
        }

        if (DRErng == 5 && ecoObj.happiness < 15)
        {
            Debug.Log("DRE roll 5");
            DREtitle.text = "Riots Break Out";
            DREbody.text = "Your civilians are angry and rioting.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Repair damages: 1000";
            DREoption2.text = "Do nothing";
        }

        if (DRErng == 6 && ecoObj.happiness >= 40)
        {
            Debug.Log("DRE roll 6");
            DREtitle.text = "Carnival";
            DREbody.text = "A carnival has been set up for the week.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Charge cheap tickets";
            DREoption2.text = "Charge expensive tickets";
        }

        if (DRErng == 7 && ecoObj.eco <= 40)
        {
            Debug.Log("DRE roll 7");
            DREtitle.text = "Acid Rain";
            DREbody.text = "The rain has damaged trees and made some people sick.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            ecoObj.eco = ecoObj.eco - 5;
            ecoObj.happiness = ecoObj.happiness - 10;

            DREoption1.text = "Reduce carbon emissions";
            DREoption2.text = "Do nothing";
        }
        if (DRErng == 8 && ownFreeTransit == false)
        {
            Debug.Log("DRE roll 8");
            DREtitle.text = "Public transit";
            DREbody.text = "Making public transit free will reduce carbon emmisions and make citizens happier, but this will cost some money";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Free Transit: 3500";
            DREoption2.text = "Do nothing";
        }

        if (DRErng == 9 && ownGarbage == false)
        {
            Debug.Log("DRE roll 9");
            DREtitle.text = "Garbage System";
            DREbody.text = "The town has a poor garbage sorting system. We can improve this for more efficient recycling.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Improve garbage system: 1500";
            DREoption2.text = "Do nothing";
        }

        if (DRErng == 10 && ownCars == false)
        {
            Debug.Log("DRE roll 10");
            DREtitle.text = "Electric Cars";
            DREbody.text = "We can reduce carbon emissions and improve happiness, if we give citizens subsidies for electric cars.";
            DREui.SetActive(true);
            ecoObj.UI.SetActive(false);
            isDREon = (true);

            DREoption1.text = "Subsidies for cars: 5000";
            DREoption2.text = "Do nothing";
        }

        if (DRErng == 11 || DRErng == 12 || DRErng == 13 || DRErng == 14)
        {
            Debug.Log("DRE roll 11-14");
        }
    }

    public void checkCircus()
    {
        if(circusOn == true)
        {
            circus.SetActive(false);
            circusOn = false;
        }
    }
}
