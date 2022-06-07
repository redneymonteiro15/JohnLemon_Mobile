using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string scene;
    public GameObject panelPrincipal, painelAudio;
    
    public void CarregarNiveis()
    {
        SceneManager.LoadScene(scene);
    }

    public void Audio()
    {
        painelAudio.SetActive(true);
        panelPrincipal.SetActive(false);
    }

    public void Voltar()
    {
        painelAudio.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
