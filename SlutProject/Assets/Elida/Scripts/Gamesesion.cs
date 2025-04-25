using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamesesion : MonoBehaviour
{
    [SerializeField] int PlayerHealth = 3;
    [SerializeField] int Playerlife = 3;
    int starthealth;

    void Awake()
    {
        int ngamesesion = FindObjectsByType<Gamesesion>(FindObjectsSortMode.None).Length;
        if(ngamesesion > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        starthealth = PlayerHealth;

    }

    public void PlayerDamage()
    {
        if(PlayerHealth > 1)
        {
            TakeHealth();
        }
        else
        {
            TakeLife();
        }
    }

    public void TakeHealth()
    {
        PlayerHealth--;
    }

    public void TakeLife()
    {
        if (Playerlife > 1)
        {
            Playerlife--;
            PlayerHealth = starthealth;
            int currentSceneindex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneindex);
        }
        else
        {
            ResetGamesesion();
        }
    }

    void ResetGamesesion()
    {
        FindFirstObjectByType<Scenepersist>().ResetScenepersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
