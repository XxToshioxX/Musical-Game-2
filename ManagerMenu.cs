using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerMenu : MonoBehaviour
{
    public int Contador;
    public Animator anim;
    public KeyCode key;
    public string Fase1;
    public string Fase2;
    public string Fase3;
    public string Fase4;
    public string Fase5;
    public string Final;

    public GameObject Fase1Clear;
    public GameObject Fase2Clear;
    public GameObject Fase3Clear;
    public GameObject Fase4Clear;
    public GameObject Fase5Clear;

    public GameObject FaseIcon1;
   

    public bool Reset = false;
    private void Start()
    {
       
        Contador = PlayerPrefs.GetInt("Stage");
        anim = GetComponent<Animator>();
        if(Reset == true || PlayerPrefs.GetInt("Reset") == 1 )
        {

            PlayerPrefs.SetInt("Stage", 0);
            PlayerPrefs.SetInt("Reset", 0);
            Fase1Clear.SetActive(false);
            Fase2Clear.SetActive(false);
            Fase3Clear.SetActive(false);
            Fase4Clear.SetActive(false);
            Fase5Clear.SetActive(false);
            FaseIcon1.SetActive(false);

        }  
        if (PlayerPrefs.GetInt("Stage") != 0)
        {
            if (PlayerPrefs.GetInt("Stage") >= 1)
            {
                Fase1Clear.SetActive(false);
                Fase2Clear.SetActive(false);
                Fase3Clear.SetActive(false);
                Fase4Clear.SetActive(false);
                Fase5Clear.SetActive(false);
                if (PlayerPrefs.GetInt("Stage") >= 2)
                {
                    Fase1Clear.SetActive(true);
                    Fase2Clear.SetActive(false);
                    Fase3Clear.SetActive(false);
                    Fase4Clear.SetActive(false);
                    Fase5Clear.SetActive(false);
                    if (PlayerPrefs.GetInt("Stage") >= 3)
                    {
                        Fase1Clear.SetActive(true);
                        Fase2Clear.SetActive(true);
                        Fase3Clear.SetActive(false);
                        Fase4Clear.SetActive(false);
                        Fase5Clear.SetActive(false);
                        if (PlayerPrefs.GetInt("Stage") >= 4)
                        {
                            Fase1Clear.SetActive(true);
                            Fase2Clear.SetActive(true);
                            Fase3Clear.SetActive(true);
                            Fase4Clear.SetActive(false);
                            Fase5Clear.SetActive(false);
                            if (PlayerPrefs.GetInt("Stage") >= 5)
                            {
                                Fase1Clear.SetActive(true);
                                Fase2Clear.SetActive(true);
                                Fase3Clear.SetActive(true);
                                Fase4Clear.SetActive(true);
                                Fase5Clear.SetActive(false);

                            }
                        }
                    }
                }
            }
        }
        
    }   
    void Update()
    {
        if(PlayerPrefs.GetInt("Stage") == 0 && Input.GetKeyDown(key))
        {        
            StartCoroutine("Espera");
            SceneManager.LoadScene(Fase1);
        }
        if(PlayerPrefs.GetInt("Stage") == 1)
        {
            anim.SetBool("Fase1Clear", true);
            if (PlayerPrefs.GetInt("Stage") == 1 && Input.GetKeyDown(key))
            {
                StartCoroutine("Espera");
                SceneManager.LoadScene(Fase2);
            }
        }
        if (PlayerPrefs.GetInt("Stage") == 2)
        {
            anim.SetBool("Fase2Clear", true);
            if (PlayerPrefs.GetInt("Stage") == 2 && Input.GetKeyDown(key))
            {
                StartCoroutine("Espera");
                SceneManager.LoadScene(Fase3);
            }
        }
        if (PlayerPrefs.GetInt("Stage") == 3)
        {
            anim.SetBool("Fase3Clear", true);
            if (PlayerPrefs.GetInt("Stage") == 3 && Input.GetKeyDown(key))
            {
                StartCoroutine("Espera");
                SceneManager.LoadScene(Fase4);
            }
        }
        if (PlayerPrefs.GetInt("Stage") == 4)
        {
            anim.SetBool("Fase4Clear", true);
            if (PlayerPrefs.GetInt("Stage") == 4 && Input.GetKeyDown(key))
            {
                StartCoroutine("Espera");
                SceneManager.LoadScene(Fase5);
            }
        }
        if (PlayerPrefs.GetInt("Stage") == 5)
        {
           // anim.SetBool("Fase5Clear", true);
            if (PlayerPrefs.GetInt("Stage") == 5 && Input.GetKeyDown(key))
            {
                StartCoroutine("Espera");
                SceneManager.LoadScene(Final);
            }
        }

    }
    public IEnumerator Espera()
    {
        yield return new WaitForSeconds(5);
    }
}
