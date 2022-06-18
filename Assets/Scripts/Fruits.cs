using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Fruits : MonoBehaviour
{
    public GameObject player, fruit;
    public Text text;
    public AudioSource audio;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            audio.Play();
            fruit.SetActive(false);
            SetFruit();
        }
    }

    public void SetFruit()
    {
        int num = Int32.Parse(text.text);
        num++;
        text.text = ""+num;
    }
}
