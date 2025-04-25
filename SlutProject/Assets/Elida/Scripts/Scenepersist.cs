using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenepersist : MonoBehaviour
{
    void Awake()
    {
        int nscenepersist = FindObjectsByType<Scenepersist>(FindObjectsSortMode.None).Length;

        if(nscenepersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }

    public void ResetScenepersist()
    {
        Destroy(gameObject);
    }
}
