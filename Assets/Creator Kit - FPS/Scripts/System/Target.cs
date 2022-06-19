using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Threading;

public class Target : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    public GameObject bossCollider;
    public NavMeshAgent navMesh;
    public bool attack = false;

    public float timeToLife;
    public Text txtTempo;
    public GameEnding end;

    public int pointValue;

    public ParticleSystem DestroyedEffect;

    [Header("Audio")]
    public RandomPlayer HitPlayer;
    public AudioSource IdleSource;
    
    public bool Destroyed => m_Destroyed;

    public bool m_Destroyed = false;

    void Awake()
    {
        Helpers.RecursiveLayerChange(transform, LayerMask.NameToLayer("Target"));
    }

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();

        DestroyedEffect.Stop();
        
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
        
        /*if(HitPlayer != null)
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

        
        
        
        m_Destroyed = true;
        
        gameObject.SetActive(false);

        
    
        GameSystem.Instance.TargetDestroyed(pointValue);*/

        
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
        DestroyedEffect.Play();

        HitPlayer.PlayRandom();

        boss.SetActive(false);
        bossCollider.SetActive(false);
     
        m_Destroyed = true;

        float tempo = 10;

        while (true)
        {
            tempo -= Time.deltaTime;
            if(tempo < 0)
            {
                break;
            }
        }

        end.End();
    
        GameSystem.Instance.TargetDestroyed(pointValue);
    }

    
}
