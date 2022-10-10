using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public float dist = 17;
    public float way;
    public Animator anim;


    private void Update()
    {
        way = Vector3.Distance(player.transform.position, transform.position);
        if (dist>= way)
        {
            transform.LookAt(player.transform);
            anim.SetBool("fire", true);
        }
        else
        {
            anim.SetBool("fire", false);
        }
        
    }
}

