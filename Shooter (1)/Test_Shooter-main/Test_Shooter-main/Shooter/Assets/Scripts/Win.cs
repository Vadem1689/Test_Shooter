using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject panelWin;
    public Animator anim;
    public TDA_Player TDA_Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelWin.SetActive(true);
           anim.SetBool("run", false);
            anim.SetBool("idle", true);

            TDA_Player.isRun = false;

        }

    }

}
