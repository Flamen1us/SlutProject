using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public int score = 0;
    public IntegerField Coincolecter;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        var uIdokument = FindAnyObjectByType<UIDocument>();
        if(uIdokument != null)
        {
            var root = uIdokument.rootVisualElement;
            Coincolecter = root.Q<IntegerField>("Coincolecter");
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateUI();
    }
    void CollectCoin()
    {
        score++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if(Coincolecter != null)
        {
            Coincolecter.value = score;
        }
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin();
            Destroy(other.gameObject);
        }
    }

}
