using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public string level1, level2, level3;
    public Button[] button;
    public Text text;
    
    private void Update()
    {
        for (int i = 0; i < button.Length; i++)
        {
            Debug.Log("Fase " + PlayerPrefs.GetInt("faseCompletada"));
            if(i+2 > PlayerPrefs.GetInt("faseCompletada"))
            {
                button[i].interactable = false;
            }
        }
        text.text = "Total Fruit: " + PlayerPrefs.GetInt("totalFruit");
    }


    public void CarregarLevel1()
    {
        SceneManager.LoadScene(level1);
    }

    public void CarregarLevel2()
    {
        SceneManager.LoadScene(level2);
        
    }
    public void CarregarLevel3()
    {

        SceneManager.LoadScene(level3);
    
    }
    
}
