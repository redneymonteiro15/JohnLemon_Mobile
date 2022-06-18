using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public NavMeshAgent navMesh;
    public bool attack = false;

    public float timeToLife;
    public Text txtTempo;
    public GameEnding end;


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
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        DestroyedEffect.Stop();

        /*Vector3 position = transform.position;
        DestroyedEffect.transform.position = position;
        DestroyedEffect.Play();
        DestroyedEffect.time = 1f;*/

        m_CurrentHealth = health;

        if(DestroyedEffect)
            PoolSystem.Instance.InitPool(DestroyedEffect, 16);  
        
        if(IdleSource != null)
            IdleSource.time = Random.Range(0.0f, IdleSource.clip.length);
    }

    void Update()
    {
        if(attack)
        {
            navMesh.destination = player.transform.position;


            if(timeToLife > 0)
            { 
                timeToLife -= Time.deltaTime;
                txtTempo.text = "Falta " + (int)timeToLife + "s";
            } 
            else if(timeToLife == -10)
            {
                DestroyedEffect.Stop();
            }
            else if(timeToLife < 0)
            {
                if(!m_Destroyed)
                {
                    Deap();
                    timeToLife = -10;
                }
                
            }
        } 
        
    }

    public void Got(float damage)
    {
        //Vector3 position = transform.position;

        /*var effect = DestroyedEffect;
        effect.time = 0.0f;
        effect.Play();
        effect.transform.position = position;*/
        
        if(HitPlayer != null)
            HitPlayer.PlayRandom();
        
        if(m_CurrentHealth > 0)
            return;

   
        
        //the audiosource of the target will get destroyed, so we need to grab a world one and play the clip through it
        if (HitPlayer != null)
        {
            var source = WorldAudioPool.GetWorldSFXSource();
            //source.transform.position = position;
            source.pitch = HitPlayer.source.pitch;
            source.PlayOneShot(HitPlayer.GetRandomClip());
        }

        
        end.End();
        
        m_Destroyed = true;
        
        gameObject.SetActive(false);

        
    
        GameSystem.Instance.TargetDestroyed(pointValue);

        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            attack = true;
        }
    }

    void Deap()
    {
        boss.SetActive(false);

        DestroyedEffect.Play();

        HitPlayer.PlayRandom();
     
        m_Destroyed = true;
    
        GameSystem.Instance.TargetDestroyed(pointValue);
    }
}
