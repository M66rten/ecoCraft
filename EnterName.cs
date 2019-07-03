using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterName : MonoBehaviour
{
    public InputField InputName;

    public TextMeshProUGUI TownName;
    public Text EnterNameHere;

    public TextMeshProUGUI ReportTownName;

    public void Awake()
    {
        TownName.enabled = false;
    }

    public void OnEdit(string name)
    {
        EnterNameHere.text = "";
    }

    public void GetInput (string name)
    {
        Debug.Log("You Entered: " + name);
        TownName.text = name;
        ReportTownName.text = name;
	}

    public void ShowName()
    {
        TownName.enabled = true;
    }
}
