using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HuD : MonoBehaviour
{
    VisualElement root;
    [SerializeField] PlayerHealth player;
    ProgressBar healthbar;
    public int coinCount = 0;
    Label coins;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        healthbar = root.Q<ProgressBar>("HealthBar");
        coins = root.Q<Label>("Coins");
        coinCount = FindObjectOfType<Stats>().coins;
    }

    private void Update()
    {
        healthbar.value = player.playerHealth;
    }
    public void AddCoin()
    {
        coinCount++;
        coins.text = coinCount.ToString();
    }
}
