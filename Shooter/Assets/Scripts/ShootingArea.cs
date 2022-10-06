using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArea : MonoBehaviour
{
    public TDA_Player Tda_Player;
    public Animator anim;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Tda_Player.isRun = false;
            anim.SetBool("idle", true);
          
        }

    }
   

    private void OnDisable()
    {
        Tda_Player.isRun = true;
        anim.SetBool("idle", false);
    }


}
