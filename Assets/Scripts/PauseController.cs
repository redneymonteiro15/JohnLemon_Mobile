using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public string levelMain;
    public GameObject painel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        painel.SetActive(true);
    }

    public void Retornar()
    {
        painel.SetActive(false);
    }

    
}
