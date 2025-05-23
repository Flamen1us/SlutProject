using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shopmanager : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTXT;
    private EventSystem eventsystem;
    
  


    void Start()
    {
        eventsystem = GetComponent<EventSystem>();
        CoinsTXT.text = "Coins:" + coins.ToString();
        // ID's for items
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
       
        // Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;
        
        // Amunt
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;
       

    }

    public void Buy()
    {
         GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

       
        
        
        if( coins >= shopItems[2, ButtonRef.GetComponent<Buttoninfo>().ItemID])
        {
          coins -= shopItems[2, ButtonRef.GetComponent<Buttoninfo>().ItemID];
           shopItems[3, ButtonRef.GetComponent<Buttoninfo>().ItemID]++;
            CoinsTXT.text = "Coins:" + coins.ToString();
            //Text update
            ButtonRef.GetComponent<Buttoninfo>().quantetyText.text = shopItems[3, ButtonRef.GetComponent<Buttoninfo>().ItemID].ToString();

        }
      
    }


}
