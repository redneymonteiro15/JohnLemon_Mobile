using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Target : MonoBehaviour
{
    public GameObject player;

    public float health = 5.0f;
    public int pointValue;

    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    
    public bool Destroyed => m_Destroyed;

    public bool m_Destroyed = false;
    public float m_CurrentHealth;

    void Awake()
    {
        Vector3 position = transform.position;
        DestroyedEffect.transform.position = position;
        DestroyedEffect.Play();
        DestroyedEffect.time = 1f;
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        Vector3 position = transform.position;
        DestroyedEffect.transform.position = position;
        DestroyedEffect.Play();
        DestroyedEffect.time = 1f;

        m_CurrentHealth = health;

        if(DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);  
        
        if(IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);
    }

    public void Got(float damage)
    {
        Vector3 position = transform.position;

        /*var effect = DestroyedEffect;
        effect.time = 0.0f;
        effect.Play();
        effect.transform.position = position;*/

        

        m_CurrentHealth -= damage;
        
        if(HitPlayer != null)
            HitPlayer.PlayRandom();
        
        if(m_CurrentHealth > 0)
            return;

        
        
        //the audiosource of the target will get destroyed, so we need to grab a world one and play the clip through it
        if (HitPlayer != null)
        {
            var source = WorldAudioPool.GetWorldSFXSource();
            source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }

        

        m_Destroyed = true;
        
        gameObject.SetActive(false);
    
        GameSystem.Instance.TargetDestroyed(pointValue);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            Got(1);
        }
    }
}
