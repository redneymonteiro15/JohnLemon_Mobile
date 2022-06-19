using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;

    public Text text;


    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
            
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if(m_IsPlayerAtExit)
            {
                if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("faseCompletada"))
                {
                    PlayerPrefs.SetInt("faseCompletada", SceneManager.GetActiveScene().buildIndex);
                    PlayerPrefs.Save();
                }
            }
            int total = Convert.ToInt32(text.text) + PlayerPrefs.GetInt("totalFruit");
            PlayerPrefs.SetInt("totalFruit", total);
            SceneManager.LoadScene ("Niveis");
        }
    }

    public void End()
    {
        m_IsPlayerAtExit = true;
        EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
    }
}
