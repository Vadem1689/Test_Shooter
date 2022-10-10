using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Image bar;
    public float fill;

    private void Start()
    {
        fill = 1f;
    }
    private void Update()
    {
        fill  -= Time.deltaTime *0.1f;
        bar.fillAmount = fill;
    }
}
