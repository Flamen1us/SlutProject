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


    public int costSpeed = 10;
    public int costHealth = 20;
    public int costDamage = 30;

    private Stats stats;

    void Start()
    {
        stats = FindObjectOfType<Stats>();
    }

   
    void Update()
    {
        if(stats != null)
        {
            upgrade1.interactable = stats.coins >= costSpeed;
            upgrade2.interactable = stats.coins >= costHealth;
            upgrade3.interactable = stats.coins >= costDamage;
        }
    }

    public void BuyBulletspeed()
    {
        Stats stats = FindObjectOfType<Stats>();
        if(stats.coins >= costSpeed)
        {
            stats.coins -= costSpeed;
            FindObjectOfType<PlayerShotting>().Bulletspeed += speedtoadd;
        }
        else
        {
            Debug.Log("Not enough coins");
        }
       
    }

    public void BuyHealth()
    {
        Stats stats = FindObjectOfType<Stats>();
        if(stats.coins >= costHealth)
        {
            stats.coins -= costHealth;
            FindObjectOfType<Stats>().playerHealth += Healthup;
        }
        else
        {
            Debug.Log("Not enough coins");
        }
       
    }

    public void BuyEnemyDamage()
    {
        Stats stats = FindObjectOfType<Stats>();
        if(stats.coins >= costDamage)
        {
            stats.coins -= costDamage;
            FindObjectOfType<Stats>().damage += Damageup;
        }
        else
        {
            Debug.Log("Not enough coins");
        }
       
    }
}
