using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgardes : MonoBehaviour
{
    public Button upgrade1, upgrade2, upgrade3;
    public int speedtoadd = 2;
    public int Healthup = 5;
    public int Damageup = 2;

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void BuyBulletspeed()
    {
        Debug.Log("Bought");
        FindObjectOfType<PlayerShotting>().Bulletspeed += speedtoadd;
    }

    public void BuyHealth()
    {
        Debug.Log("Buy");
        FindObjectOfType<Stats>().playerHealth += Healthup;
    }

    public void BuyEnemyDamage()
    {
        Debug.Log("Bought");
        FindObjectOfType<Stats>().damage += Damageup;
    }
}
