using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    [SerializeField]private GameObject posIni;
    private Animator anim;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Impacto", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        anim.SetBool("Impacto", true);
       
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPmanager>().currentlifePoints -= 25;
        }


        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {

            anim.SetBool("Impacto", true);

            rb = transform.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            












        }
        
    }

    public void Splash()
    {

        GetComponent<AudioSource>().Play();
        rb = transform.GetComponent<Rigidbody2D>();
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY| RigidbodyConstraints2D.FreezeRotation| RigidbodyConstraints2D.FreezePositionX;
       
        anim.SetBool("Impacto", false);
        transform.position = posIni.transform.position;
    }


}
