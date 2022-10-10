using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TDA_Enemy : MonoBehaviour
{
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float Radius = 4;
    public Animator anim;


    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > Radius )
        {
            nav.enabled = false;
            
        }
        else if (dist < Radius )
        {
            transform.LookAt(player.transform);
            if (dist<=0.9f)
            {
                anim.SetBool("run", false);
                anim.SetBool("fire", true);
                nav.enabled = false;

               
            }
            else if (dist>0.9&&dist<Radius)
            {
                anim.SetBool("fire", false);
                nav.enabled = true;
                nav.SetDestination(player.transform.position);
                anim.SetBool("run", true);
               
            }
        }
        
    }

}
