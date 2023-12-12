using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public int count = 0;
    SpriteRenderer sr;
   // public Sprite press; //mudar para Sprite
   // public Sprite oldS;
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;
    public KeyCode key4;
    public KeyCode key5;
    bool active = false;
    GameObject note;
    GameObject gm;
    Color old;
   
    public int createMode = 0;
    public GameObject n;

    public GameObject Nome;

    //Erros
    public bool comissao = true;
    public bool omissao = false;
   

    private void Awake()
    {
        PlayerPrefs.SetInt("Create", createMode);
        sr = GetComponent<SpriteRenderer>();
       
       
    }
    private void Start()
    {
        //Erros
        PlayerPrefs.SetInt("ErroComissao", 0); //Nao era para clickar mas clickou
        PlayerPrefs.SetInt("ErroOmissao", 0); //Acertar mas nao acertou
        count = 0;
        gm = GameObject.Find("GameManager"); //Encontrar objeto com nome
        old = sr.color; //Cor ao Clicar (Inicio)
        gm.GetComponent<Game_Manager>().ResetStreak();//*Corrigindo codigo
    }
    void Update()
    {
        
        //Debug.Log(EstudoSimular.Botao[0]);

        if (PlayerPrefs.GetInt("Create") == 1)
        {
            if (Input.GetKeyDown(key1))
            {
               Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            ControleTeclado();

            if (EstudoSimular.ArdCon)
            {

                ControleArd();

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
       
        if(col.gameObject.tag == "WinNote")
        {
            if(count == 0)
            {
                gm.GetComponent<Game_Manager>().Win();
            }
            count = 1;
        }
        if (col.gameObject.tag == "Note")
        {
            comissao = false;
            note = col.gameObject;
            active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {       
        active = false;
        comissao = true;
        //gm.GetComponent<Game_Manager>().ResetStreak();//*Corrigindo codigo
    }
    public void AddScore()
    {
        //Fase1
        if (PlayerPrefs.GetInt("Stage") == 0)
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gm.GetComponent<Game_Manager>().GetScore());
        }
        //Fase2
        if (PlayerPrefs.GetInt("Stage") == 1)
        {
            PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score2") + gm.GetComponent<Game_Manager>().GetScore());
        }
        //Fase3
        if (PlayerPrefs.GetInt("Stage") == 2)
        {
            PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score3") + gm.GetComponent<Game_Manager>().GetScore());
        }
        //Fase4
        if (PlayerPrefs.GetInt("Stage") == 3)
        {
            PlayerPrefs.SetInt("Score4", PlayerPrefs.GetInt("Score4") + gm.GetComponent<Game_Manager>().GetScore());
        }
        //Fase5
        if (PlayerPrefs.GetInt("Stage") == 4)
        {
            PlayerPrefs.SetInt("Score5", PlayerPrefs.GetInt("Score5") + gm.GetComponent<Game_Manager>().GetScore());
        }
    }

    IEnumerator Pressed() //Tempo e Cor que fica ao clicar no botao ao decorrer
    {
        if (comissao == true)
        {
            PlayerPrefs.SetInt("ErroComissao", PlayerPrefs.GetInt("ErroComissao") + 1);     
        }
        sr.color = new Color(0, 0, 0);
       // sr.sprite = press;
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
      //  sr.sprite = oldS;

    }

    public void ControleTeclado()
    {
        if (Input.GetKeyDown(key1)) //A
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key1) && active)
        {
            Destroy(note);
            gm.GetComponent<Game_Manager>().AddStreak();
            AddScore();
            active = false;
        }
        else if (Input.GetKeyDown(key1) && !active)
        {

            gm.GetComponent<Game_Manager>().ResetStreak();
        }
        if (Input.GetKeyDown(key2))
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key2) && active) //S
        {
            Destroy(note);
            gm.GetComponent<Game_Manager>().AddStreak();
            AddScore();
            active = false;
        }
        else if (Input.GetKeyDown(key2) && !active)
        {
            gm.GetComponent<Game_Manager>().ResetStreak();
        }

        if (Input.GetKeyDown(key3))  //D
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key3) && active)
        {
            Destroy(note);
            gm.GetComponent<Game_Manager>().AddStreak();
            AddScore();
            active = false;
        }
        else if (Input.GetKeyDown(key3) && !active)
        {
            gm.GetComponent<Game_Manager>().ResetStreak();
        }

        if (Input.GetKeyDown(key4)) //F
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key4) && active)
        {
            Destroy(note);
            gm.GetComponent<Game_Manager>().AddStreak();
            AddScore();
            active = false;
        }
        else if (Input.GetKeyDown(key4) && !active)
        {
            gm.GetComponent<Game_Manager>().ResetStreak();
        }

        if (Input.GetKeyDown(key5)) //G
        {
            StartCoroutine(Pressed());
        }
        if (Input.GetKeyDown(key5) && active)
        {
            Destroy(note);
            gm.GetComponent<Game_Manager>().AddStreak();
            AddScore();
            active = false;
        }
        else if (Input.GetKeyDown(key5) && !active)
        {
            gm.GetComponent<Game_Manager>().ResetStreak();
        }
    }

    public void ControleArd()
    {
        if (Nome.name == "Activator (4)")
        {

            if (EstudoSimular.Botao[0] && !EstudoSimular.BotaoDown[0]) //A
            {               

                StartCoroutine(Pressed());
            }
            if (EstudoSimular.Botao[0] && active && !EstudoSimular.BotaoDown[0])
            {

                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (EstudoSimular.Botao[0] && !active && !EstudoSimular.BotaoDown[0])
            {

                //Debug.Log(EstudoSimular.BotaoDown[0]);

                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }

        if (Nome.name == "Activator (3)")
        {


            if (EstudoSimular.Botao[1] && !EstudoSimular.BotaoDown[1])
            {

                StartCoroutine(Pressed());
            }
            if (EstudoSimular.Botao[1] && active && !EstudoSimular.BotaoDown[1]) //S
            {

                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (EstudoSimular.Botao[1] && !active && !EstudoSimular.BotaoDown[1])
            {

                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }


        if (Nome.name == "Activator (2)")
        {

            if (EstudoSimular.Botao[2] && !EstudoSimular.BotaoDown[2])  //D
            {

                StartCoroutine(Pressed());
            }
            if (EstudoSimular.Botao[2] && active && !EstudoSimular.BotaoDown[2])
            {

                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (EstudoSimular.Botao[2] && !active && !EstudoSimular.BotaoDown[2])
            {

                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }

        if (Nome.name == "Activator (1)")
        {

            if (EstudoSimular.Botao[3] && !EstudoSimular.BotaoDown[3]) //F
            {

                StartCoroutine(Pressed());
            }
            if (EstudoSimular.Botao[3] && active && !EstudoSimular.BotaoDown[3])
            {

                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (EstudoSimular.Botao[3] && !active && !EstudoSimular.BotaoDown[3])
            {

                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }

        if (Nome.name == "Activator")
        {

            if (EstudoSimular.Botao[4] && !EstudoSimular.BotaoDown[4]) //G
            {

                StartCoroutine(Pressed());
            }
            if (EstudoSimular.Botao[4] && active && !EstudoSimular.BotaoDown[4])
            {

                Destroy(note);
                gm.GetComponent<Game_Manager>().AddStreak();
                AddScore();
                active = false;
            }
            else if (EstudoSimular.Botao[4] && !active && !EstudoSimular.BotaoDown[4])
            {

                gm.GetComponent<Game_Manager>().ResetStreak();
            }
        }
    }
}
