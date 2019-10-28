using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private int impactos;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        impactos = 0;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (impactos >= 3)
        {
            anim.SetBool("Destroy", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AtaqueBasico")
        {
            Debug.Log("AAWGWGUAWGUGAIUW");
            impactos++;

        }

        
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
        GameObject.Find("Boss").GetComponent<Bosshead>().PuntosDestruidos++;
    }

    public void Sonar()
    {
        GetComponent<AudioSource>().Play();
    }
}
