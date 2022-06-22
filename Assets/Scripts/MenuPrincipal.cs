using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string scene;
    public GameObject panelPrincipal, painelAudio;
    
    void Start()    
    {
        PlayerPrefs.DeleteAll();
    }
    
    void Update()
    {
        Vector3 vetor;
        vetor.y = 0;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, vetor.y, transform.eulerAngles.z);
    }

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
