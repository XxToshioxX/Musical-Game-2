using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Mapa : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Stage") == 1)
        {
            anim.SetBool("Fase1Clear", true);
            anim.SetBool("Fase2Clear", false);
            anim.SetBool("Fase3Clear", false);
            anim.SetBool("Fase4Clear", false);
            anim.SetBool("Fase5Clear", false);
        }
        if (PlayerPrefs.GetInt("Stage") == 2)
        {
            anim.SetBool("Fase1Clear", false);
            anim.SetBool("Fase2Clear", true);
            anim.SetBool("Fase3Clear", false);
            anim.SetBool("Fase4Clear", false);
            anim.SetBool("Fase5Clear", false);
        }
        if (PlayerPrefs.GetInt("Stage") == 3)
        {
            anim.SetBool("Fase1Clear", false);
            anim.SetBool("Fase2Clear", false);
            anim.SetBool("Fase3Clear", true);
            anim.SetBool("Fase4Clear", false);
            anim.SetBool("Fase5Clear", false);
        }
        if (PlayerPrefs.GetInt("Stage") == 4)
        {
            anim.SetBool("Fase1Clear", false);
            anim.SetBool("Fase2Clear", false);
            anim.SetBool("Fase3Clear", false);
            anim.SetBool("Fase4Clear", true);
            anim.SetBool("Fase5Clear", false);
        }
        if (PlayerPrefs.GetInt("Stage") == 5)
        {
            anim.SetBool("Fase1Clear", false);
            anim.SetBool("Fase2Clear", false);
            anim.SetBool("Fase3Clear", false);
            anim.SetBool("Fase4Clear", false);
            anim.SetBool("Fase5Clear", true);
        }
    }
}
