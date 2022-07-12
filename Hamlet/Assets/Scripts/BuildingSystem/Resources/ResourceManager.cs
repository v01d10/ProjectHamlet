using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        ironBalance.text = totalIron + " Iron";
        goldBalance.text = totalGold + " Gold";
        coalBalance.text = totalCoal + " Coal";
    }
}
