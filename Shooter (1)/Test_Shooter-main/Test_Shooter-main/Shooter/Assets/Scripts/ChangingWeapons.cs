using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWeapons : MonoBehaviour
{
    public GameObject gun;
    public GameObject automat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gun.SetActive(false);
            automat.SetActive(true);

        }

    }
    
}
