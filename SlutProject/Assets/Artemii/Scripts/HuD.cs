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
    [SerializeField]Stats stat;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        healthbar = root.Q<ProgressBar>("HealthBar");
        coins = root.Q<Label>("Coins");
    }

    private void Update()
    {
        healthbar.value = player.playerHealth;
        coinCount = stat.coins;
    }
    public void AddCoin()
    {
        coinCount++;
        coins.text = coinCount.ToString();
    }
}
