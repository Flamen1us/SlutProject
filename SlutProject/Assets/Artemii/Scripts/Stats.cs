using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100;
    [SerializeField] public float damage = 10;
    [SerializeField] public float healling = 0; // never used
    [SerializeField] public float movementSpeed = 10; //never used
    public int coins;
}
