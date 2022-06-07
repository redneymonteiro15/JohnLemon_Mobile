using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string level1, level2, level3;
    public int lockLevel2 = 1, lockLevel3 = 1;
    public static LevelManager instance;

    void Awake()
    {
        instance = this;
        lockLevel2 = PlayerPrefs.GetInt("unlocked2");
        lockLevel3 = PlayerPrefs.GetInt("unlocked3");
    }


    public void CarregarLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void CarregarLevel2()
    {
        if(lockLevel2==0)
        {
            SceneManager.LoadScene(level2);
        }
    }
    public void CarregarLevel3()
    {
        if(lockLevel3==0)
        {
            SceneManager.LoadScene(level3);
        }
    }
    
}
