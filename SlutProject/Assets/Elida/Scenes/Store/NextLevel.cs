using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] EnemySpawner ene;
    public void MoveToScene(int sceneID)
    {
        ene.waveNumber++;
        SceneManager.LoadScene(sceneID);
    }
   
}
