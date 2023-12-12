using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private SpriteRenderer rend;
    public Sprite spriteA;
    public Sprite spriteS;
    public Sprite spriteD;
    public Sprite spriteF;
    public Sprite spriteG;

    public bool A = false;
    public bool S = false;
    public bool D = false;
    public bool F = false;
    public bool G = false;

    bool called = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
       
    }
    void Update()
    {
        if(PlayerPrefs.GetInt("Start") == 1 && !called )
        {
            rb.velocity = new Vector2(0, -speed);
            called = true;
        }
        
    }

   
    public void OnTriggerExit2D(Collider2D col)
    {
        if (A)
        {
            rend.color = new Color(31f/255, 255f/255, 0f/255);
            rend.sprite = spriteA;
        }
        if (S)
        {
            rend.color = new Color(255f/255, 0f/255, 0f/255);
            rend.sprite = spriteS;
        }
        if (D)
        {
            rend.color = new Color(229f/255, 243f/255, 0f/255);
            rend.sprite = spriteD;
        }
        if (F)
        {
            rend.color = new Color(0f/255, 117f/255, 255f/255);
            rend.sprite = spriteF;
        }
        if (G)
        {
            rend.color = new Color(255f/255, 255f/255, 255f/255);
            rend.sprite = spriteG;

        }
    }
}
