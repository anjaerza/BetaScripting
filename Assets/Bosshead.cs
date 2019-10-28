using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshead : MonoBehaviour
{
    private int puntosDestruidos;
    private GameObject[] spawners;
    private Animator anim;

    public int PuntosDestruidos { get => puntosDestruidos; set => puntosDestruidos = value; }

    // Start is called before the first frame update
    void Start()
    {
        PuntosDestruidos = 0;
        spawners = GameObject.FindGameObjectsWithTag("TSpawn");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PuntosDestruidos>=1 && spawners[PuntosDestruidos - 1]!=null)
        {
            Destroy(spawners[PuntosDestruidos - 1]);
        }
        
        
        anim.SetInteger("Damage", PuntosDestruidos);

        
    }

    public void Screech()
    {
        GetComponent<AudioSource>().Play();
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

}
