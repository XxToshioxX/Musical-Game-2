using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public string CenaWin;
    public string CenaLose;
    public int multiplier = 1;
    public int streak = 0;

    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject nivel3;
    public GameObject nivel4;
    public GameObject nivel5;
    void Start()
    {
        NivelFase();
        
        //Geral
        streak = 0;
        PlayerPrefs.SetInt("Start", 1);
        PlayerPrefs.SetInt("RockMeter", 25);
        PlayerPrefs.SetInt("Streak", 0);
        //Fase1
        PlayerPrefs.SetInt("Score", 0);            
        PlayerPrefs.SetInt("HighStreak", 0);
        PlayerPrefs.SetInt("Mult", 1);
        PlayerPrefs.SetInt("NotesHit", 0);       

        //Fase2
        PlayerPrefs.SetInt("Score2", 0);      
        PlayerPrefs.SetInt("HighStreak2", 0);
        PlayerPrefs.SetInt("Mult2", 1);
        PlayerPrefs.SetInt("NotesHit2", 0);

        //Fase3
        PlayerPrefs.SetInt("Score3", 0);
        PlayerPrefs.SetInt("HighStreak3", 0);
        PlayerPrefs.SetInt("Mult3", 1);
        PlayerPrefs.SetInt("NotesHit3", 0);
        
        //Fase4
        PlayerPrefs.SetInt("Score4", 0);
        PlayerPrefs.SetInt("HighStreak4", 0);
        PlayerPrefs.SetInt("Mult4", 1);
        PlayerPrefs.SetInt("NotesHit4", 0);

        //Fase5
        PlayerPrefs.SetInt("Score5", 0);
        PlayerPrefs.SetInt("HighStreak5", 0);
        PlayerPrefs.SetInt("Mult5", 1);
        PlayerPrefs.SetInt("NotesHit5", 0);
    }

    void Update()
    {
        
    }
    public void NivelFase()
    {
        if (PlayerPrefs.GetFloat("Speed") == 1)
        {
            nivel1.SetActive(true);
            nivel2.SetActive(false);
            nivel3.SetActive(false);
            nivel4.SetActive(false);
            nivel5.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("Speed") == 2)
        {
            nivel1.SetActive(false);
            nivel2.SetActive(true);
            nivel3.SetActive(false);
            nivel4.SetActive(false);
            nivel5.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("Speed") == 3)
        {
            nivel1.SetActive(false);
            nivel2.SetActive(false);
            nivel3.SetActive(true);
            nivel4.SetActive(false);
            nivel5.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("Speed") == 4)
        {
            nivel1.SetActive(false);
            nivel2.SetActive(false);
            nivel3.SetActive(false);
            nivel4.SetActive(true);
            nivel5.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("Speed") == 5)
        {
            nivel1.SetActive(false);
            nivel2.SetActive(false);
            nivel3.SetActive(false);
            nivel4.SetActive(false);
            nivel5.SetActive(true);
        }
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        ResetStreak();//*Corrigindo codigo
        // Destroy(col.gameObject);
    }
    public void AddStreak()
    {
        if (PlayerPrefs.GetInt("RockMeter") + 1 <= 80) //Setar valor Rockemeter da Direita 
        {
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 2);
        }
       
        streak++;
        Streaks();
        if (streak >=24) //QUANDO O STREAK CHEGAR A TAL PONTO MUDA O MULTIPLIER
        {
            multiplier = 4;
            UpdateGUI();
        }
       else if(streak >= 16)
        {
            multiplier = 3;
            UpdateGUI();
        }
       else if(streak >= 8)
        {
            multiplier = 2;
            UpdateGUI();
        }
        else
        {
            multiplier = 1;
            UpdateGUI();
        }

       
        
    }
    public void Streaks() //Streak de cada fase
    {
        //Fase1
        if (streak > PlayerPrefs.GetInt("HighStreak"))
        {          
                PlayerPrefs.SetInt("HighStreak", streak);
        }
        //Fase2
        if(streak > PlayerPrefs.GetInt("HighStreak2"))
        {
            PlayerPrefs.SetInt("HighStreak2", streak);
        }
        //Fase3
        if (streak > PlayerPrefs.GetInt("HighStreak3"))
        {
            PlayerPrefs.SetInt("HighStreak", streak);
        }
        //Fase4
        if (streak > PlayerPrefs.GetInt("HighStreak4"))
        {
            PlayerPrefs.SetInt("HighStreak4", streak);
        }
        //Fase5
        if (streak > PlayerPrefs.GetInt("HighStreak5"))
        {
            PlayerPrefs.SetInt("HighStreak5", streak);
        }


        PlayerPrefs.SetInt("NotesHit", PlayerPrefs.GetInt("NotesHit") + 1);
        PlayerPrefs.SetInt("NotesHit2", PlayerPrefs.GetInt("NotesHit2") + 1);
        PlayerPrefs.SetInt("NotesHit3", PlayerPrefs.GetInt("NotesHit3") + 1);
        PlayerPrefs.SetInt("NotesHit4", PlayerPrefs.GetInt("NotesHit4") + 1);
        PlayerPrefs.SetInt("NotesHit5", PlayerPrefs.GetInt("NotesHit5") + 1);
    }
    public void ResetStreak() //Rockmeter de cada fase
    {          
        PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") - 4);
        if (PlayerPrefs.GetInt("RockMeter") <= -71 && PlayerPrefs.GetInt("Create") == 0) //Setar o Valor Rockmeter da Esquerda
        {
            Lose();
        }
            streak = 0;
        multiplier = 1;
        UpdateGUI();
    }
    public void Lose()
    {
        PlayerPrefs.SetInt("Start", 0);
        SceneManager.LoadScene(CenaLose);
    }
    public void Win()
    {
        if (PlayerPrefs.GetInt("Stage") >= 0)
        {
            Fase();
        }
        PlayerPrefs.SetInt("Start", 0);
        SetHighScore();     
        SceneManager.LoadScene(CenaWin);//Mudar Cena de Win
    }
    public void SetHighScore() //Setar o High Score das Fases
    {
        //Fase1
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
        //Fase2
        if (PlayerPrefs.GetInt("HighScore2") < PlayerPrefs.GetInt("Score2"))
        {
            PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("Score2"));
        }
        //Fase3
        if (PlayerPrefs.GetInt("HighScore3") < PlayerPrefs.GetInt("Score3"))
        {
            PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("Score3"));
        }
        //Fase4
        if (PlayerPrefs.GetInt("HighScore4") < PlayerPrefs.GetInt("Score4"))
        {
            PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("Score4"));
        }
        //Fase5
        if (PlayerPrefs.GetInt("HighScore5") < PlayerPrefs.GetInt("Score5"))
        {
            PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("Score5"));
        }
    }
    public void Fase()
    {
        if (PlayerPrefs.GetInt("Stage") == 4)
        {
            PlayerPrefs.SetInt("Stage", 5);
        }
        else if (PlayerPrefs.GetInt("Stage") == 3)
        {
            PlayerPrefs.SetInt("Stage", 4);
        }
        else if (PlayerPrefs.GetInt("Stage") == 2)
        {
            PlayerPrefs.SetInt("Stage", 3);
        }
        else if (PlayerPrefs.GetInt("Stage") == 1)
        {
            PlayerPrefs.SetInt("Stage", 2);
        }
        else if (PlayerPrefs.GetInt("Stage") == 0)
        {
            PlayerPrefs.SetInt("Stage", 1);
        }       
    }

    public void UpdateGUI()
    {
       //Geral
        PlayerPrefs.SetInt("Streak", streak);           
        PlayerPrefs.SetInt("Mult", multiplier);
       
    }
    public int GetScore()
    {
       
        return 100 * multiplier;

    }

}
