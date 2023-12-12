using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMeter : MonoBehaviour
{
    float rm;
    GameObject needle;
    void Start()
    {
        needle = transform.Find("Needle").gameObject;
    }
    void Update()
    {
        rm = PlayerPrefs.GetInt("RockMeter");

        needle.transform.localPosition = new Vector3((rm - 5)/25, 0, 0); //POSICAO DO MEDIDOR
    }
}
