using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Plots : MonoBehaviour
{
    public string NoteHit = "NotesHit";
    public string Comissao = "ErroComissao";
    public string Omissao = "ErroOmissao";
    
   
    void Start()
    {
        print("Fase" + "" + PlayerPrefs.GetInt("Stage"));
        print(PlayerPrefs.GetInt(NoteHit)+ "" + "Nota");
        print(PlayerPrefs.GetInt(Comissao)+"" + "ErroComissao");
        print(PlayerPrefs.GetInt(Omissao)+"" + "ErroOmissao");
        print(PlayerPrefs.GetString("Test"));
        
        CreateText();
    }

    void CreateText()
    {
        //Caminho do arquivo

        string path = Application.dataPath + "/Log.txt";

        //Criar se não existir

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Log \n\n");
        }

        //Conteudo no arquivo

        string content = "\n" + "Nome:" + " " + PlayerPrefs.GetString("Test") + "\n" + "Fase" + " " + PlayerPrefs.GetInt("Stage") + "\n" + PlayerPrefs.GetInt(NoteHit) + " " + "Nota" + "\n" + PlayerPrefs.GetInt(Comissao) + " " + "ErroComissao" + "\n" + PlayerPrefs.GetInt(Omissao) + " " + "ErroOmissao" + "\n";

        //Adicionar texto
        File.AppendAllText(path, content);

    }
}

