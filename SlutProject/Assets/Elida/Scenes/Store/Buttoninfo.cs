using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Buttoninfo : MonoBehaviour
{

    public int ItemID;
    public Text priceText;
    public Text quantetyText;
    public GameObject Shopmanager;
    private Shopmanager shopmanager;
    public GameObject upgrades;

    public void Start()
    {
        shopmanager = FindObjectOfType<Shopmanager>();
        
    }


    void Update()
    {
        if(shopmanager != null)
        {
            priceText.text = "Price: $" + shopmanager.shopItems[2, ItemID].ToString();
            quantetyText.text = shopmanager.shopItems[3, ItemID].ToString();
        }
      

    }
}
