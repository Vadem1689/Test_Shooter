using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDA_Player : MonoBehaviour
{
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float Radius= 15;
    public bool isStand;
    public bool isRun  = true;

 
    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
    
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist>Radius || isStand == true || isRun ==false)
        {
           nav.enabled = false;
        }
        if (dist < Radius && isStand == false && isRun ==true)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
    
}
