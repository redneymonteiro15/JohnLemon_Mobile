using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public string scene;
    
    public void CarregarNiveis()
    {
        SceneManager.LoadScene(scene);
    }
}
