using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGen : MonoBehaviour
{
    private int baseLvl = 1;

    void Start()
    {
        if(gameObject.name.Contains("Iron"))
        {
            StartCoroutine(ironGen());
        }

        if(gameObject.name.Contains("Gold"))
        {
            StartCoroutine(goldGen());
        }

        if(gameObject.name.Contains("Coal"))
        {
            StartCoroutine(coalGen());
        }
    }

    void Update()
    {
        
    }

    IEnumerator ironGen()
    {
        yield return new WaitForSeconds(5);
        ResourceManager.totalIron += 2*baseLvl;
        StartCoroutine(ironGen());
    }

    IEnumerator goldGen()
    {
        yield return new WaitForSeconds(7);
        ResourceManager.totalGold += 1*baseLvl;
        StartCoroutine(goldGen());
    }

    IEnumerator coalGen()
    {
        yield return new WaitForSeconds(3);
        ResourceManager.totalCoal += 4*baseLvl;
        StartCoroutine(coalGen());
    }
}
