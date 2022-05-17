using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string level1, level2, level3;
    public GameObject unlockLevel2, unlockLevel3;
    public bool lockLevel2 = true, lockLevel3 = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void CarregarLevel2()
    {
        if(!lockLevel2)
        {
            SceneManager.LoadScene(level2);
        }
    }
    public void CarregarLevel3()
    {
        if(!lockLevel3)
        {
            SceneManager.LoadScene(level3);
        }
    }

    public void UnlockLevel2()
    {
        lockLevel2 = false;
        unlockLevel2.SetActive(false);
    }

    public void UnlockLevel3()
    {
        lockLevel3 = false;
        unlockLevel3.SetActive(false);
    }


    
}
