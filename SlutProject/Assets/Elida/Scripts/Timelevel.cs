using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timelevel : MonoBehaviour
{
    public bool inStore = false;
    public float Levelend = 100f;
    public float startTime;
    

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float timespent = Time.time - startTime;
        if(timespent>= Levelend)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {
       
        SceneManager.LoadScene("Stor");
        inStore = true;
     
    }
}
