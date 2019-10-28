using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    
    GameObject Banco;
    private AudioSource source;

    [SerializeField]private float goldDrop;

    
    
  




    public float GoldDrop { get => goldDrop; set => goldDrop = value; }
   
   

    // Start is called before the first frame update
    void Start()
    {
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        
        

    }

    // Update is called once per frame
    void Update()
    {

    




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pick();
            source.Play();
        }
    }

    void Pick()
    {


        Banco = GameObject.Find("Player");
        Bank contadormonedas = Banco.GetComponent<Bank>();

        contadormonedas.goldCounterA += GoldDrop;

        Destroy(this.gameObject);


    }
}

