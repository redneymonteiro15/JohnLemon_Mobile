using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string scene;
    public GameObject painel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
    }
    public void Retornar()
    {
        SceneManager.LoadScene(scene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
