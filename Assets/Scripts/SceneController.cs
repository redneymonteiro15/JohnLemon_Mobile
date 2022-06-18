using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneController : MonoBehaviour
{
    public string scene;
    public GameObject painel, painelAudio, painelPause;


    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}
    
    public void Carregar()
    {
        SceneManager.LoadScene(scene);
    }
    public void Paused()
    {
        painel.SetActive(true);
    }

    public void Resume()
    {
        painel.SetActive(false);
        painelAudio.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Audio()
    {
        painelPause.SetActive(false);
        painelAudio.SetActive(true);
    }

    public void Voltar()
    {
        painelPause.SetActive(true);
        painelAudio.SetActive(false);
    }

}
