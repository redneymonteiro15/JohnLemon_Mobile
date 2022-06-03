using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMesh;
    public bool attack = false;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attack)
        {
            navMesh.destination = player.transform.position;
        }
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            attack = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == player)
        {
            attack = false;
        }
    }
    
}
