using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetConfig : MonoBehaviour
{
    public string Nome ;
    public string MaoDomin;

    public GameObject inputFieldName;
    public GameObject textDisplayName;

    public GameObject inputFieldMao;
    public GameObject textDisplayMao;

    public void Update()
    {
        PlayerPrefs.SetString("Nome", Nome);
        PlayerPrefs.SetString("Mao", MaoDomin);

    }
   public void Text_Name()
    {
        Nome = inputFieldName.GetComponent<Text>().text;
        PlayerPrefs.SetString("Nome", Nome);
        textDisplayName.GetComponent<Text>().text = PlayerPrefs.GetString("Nome", Nome); 
    }
    public void Text_Mao()
    {
        MaoDomin = inputFieldMao.GetComponent<Text>().text;
        PlayerPrefs.SetString("Mao", MaoDomin);
        textDisplayMao.GetComponent<Text>().text = PlayerPrefs.GetString("Mao", MaoDomin);
    }

}
