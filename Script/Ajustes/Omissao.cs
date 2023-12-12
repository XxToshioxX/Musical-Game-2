using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omissao : MonoBehaviour
{
    public GameObject note;
    private void OnTriggerEnter2D(Collider2D other)
    {   
       PlayerPrefs.SetInt("ErroOmissao", PlayerPrefs.GetInt("ErroOmissao") + 1);
           
    }
}
