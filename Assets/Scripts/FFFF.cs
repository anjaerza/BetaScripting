using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class FFFF : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] float speed, force;
     public int jumpcount=1;
    int PlayerLayer;
    int PlatformLayer;
    bool atacando=false;
    [SerializeField] float Esperarsegundos;
    [SerializeField] Animator anim;
    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        PlayerLayer = LayerMask.NameToLayer("Player");
        PlatformLayer = LayerMask.NameToLayer("Platform");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetBool("walking", false);
        anim.SetBool("attacking", false);
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("walking",true);
        }
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walking", true);
        }
        Vector2 distance = Vector2.right * x * speed * Time.deltaTime;
        
        rigidbody.position += distance;
        if (Input.GetKey("s") && Input.GetButtonDown("Jump"))
        {
            StartCoroutine("Saltoabajo");
        }else if
         (Input.GetButtonDown("Jump"))
        {
            Jump();
            jumpcount--;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            atacando=true;
          
            
            
        }
        if (atacando == true)
        {
            Atacar();
        }

    }
    void Jump()
    {
        if (jumpcount >0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f); ;
            rigidbody.AddForce(Vector2.up * force);
        }


    }
    void Atacar()
    {
        anim.SetBool("attacking", true);
        source.Play();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
            {
                atacando = false;
                anim.SetBool("attacking", false);
            }

            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "plataforma")
        {
            jumpcount = 1;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor" || collision.gameObject.tag == "plataforma")
        {
            jumpcount = 1;
        }
    }
    IEnumerator Saltoabajo()
    {
        Debug.Log("obo");
        Physics2D.IgnoreLayerCollision(PlayerLayer, PlatformLayer, true);
         yield return new WaitForSeconds(Esperarsegundos);
        Physics2D.IgnoreLayerCollision(PlayerLayer, PlatformLayer, false);
    }
}
