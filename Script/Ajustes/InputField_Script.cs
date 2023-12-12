using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField_Script : MonoBehaviour
{
    public InputField mainInputField;
    public string NomeDefinido;

    public string Test;
    
    void Start()
    {

        mainInputField.text = NomeDefinido;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetString("Nome", NomeDefinido);
        Test = PlayerPrefs.GetString("Nome");
        PlayerPrefs.SetString("Test", Test);
    }
    public void DefineName()
    {
        NomeDefinido = mainInputField.text;
       
    }
}
