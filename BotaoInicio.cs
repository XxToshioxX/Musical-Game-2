using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoInicio : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadSceneMan(string name)
    {
        PlayerPrefs.SetInt("Reset", 1);
        PlayerPrefs.SetFloat("Speed", 4);
        SceneManager.LoadScene(name);
        
    }
    public void LoadSceneWoman(string name)
    {
        PlayerPrefs.SetInt("Reset", 1);
        PlayerPrefs.SetFloat("Speed", 4);
        SceneManager.LoadScene(name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
