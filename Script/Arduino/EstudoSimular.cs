using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.IO;




public class EstudoSimular : MonoBehaviour
{
    public static string ArdPort = "COM7";

    public static bool ArdCon;

    //public int size;

    public string[] Teclado;

    public static bool[] Botao;

    public static bool[] BotaoDown;

    public float timer = 0f;

    SerialPort porta = new SerialPort(ArdPort, 9600);


    // Start is called before the first frame update


    void Start()
    {

        //DontDestroyOnLoad(this.gameObject);

        Botao = new bool[Teclado.Length];

        BotaoDown = new bool[Teclado.Length];

        ConectarArd();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Botao[0]);

        if (Input.GetButton("Cancel")) //Se apeertar ESC, o arduino é desconectado, mudar para a forma mais conveniente
        {
            DesconectarArd();
        }

        LerArd();

    }

    public void ConectarArd() //Função que conecta o arduino
    {
        porta.Open();
        porta.ReadTimeout = 1000;

        if (porta.IsOpen)
        {
            ArdCon = true;
            Debug.Log("Arduino Conectado");
            porta.WriteLine("c");
        }

    }

    public void DesconectarArd() //Função que desconecta o arduino
    {
        porta.Close();
        ArdCon = false;
        Debug.Log("Arduino Desconectado");

    }

    public void LerArd()
    {
        if (ArdCon) //Se o arduino estiver conectado, leia a porta serial dele
        {
            porta.WriteLine("c"); //Envia o comando "Coleta" para o arduino, recebe o botão           

            string value = porta.ReadLine(); //Le a porta serial do arduino e a atribui para a variavel "value"

            string[] vec3 = value.Split(null);

            //Debug.Log(vec3[0]);

            /*for (int i = 0; i < Teclado.Length; i++)
            {
               

            }*/

            for (int i = 0; i < Teclado.Length; i++)
            {
                if (Botao[i] == true) //Verifica se o valor recebido é igual ao valores definidos na variavel "Teclado"
                {
                    BotaoDown[i] = true;
                }
                else
                {
                    BotaoDown[i] = false;
                }

                if (vec3[0] == Teclado[i]) //Verifica se o valor recebido é igual ao valores definidos na variavel "Teclado"
                {
                    Botao[i] = true;
                }
                else
                {
                    Botao[i] = false;
                }

            }
            //Debug.Log(Botao[0]);
        }
    }

}
