using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static int totalCoal = 0;
    public static int totalIron = 0;
    public static int totalGold = 0;

    public TextMeshProUGUI ironBalance;
    public TextMeshProUGUI goldBalance;
    public TextMeshProUGUI coalBalance;

    void Start()
    {
        
    }

    void Update()
    {
        ironBalance.text = totalIron + Environment.NewLine + " Iron";
        goldBalance.text = totalGold + Environment.NewLine + " Gold";
        coalBalance.text = totalCoal + Environment.NewLine + " Coal";
    }
}
