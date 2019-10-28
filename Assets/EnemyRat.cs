using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyRat : MonoBehaviour
{
    [SerializeField]bool grande=false;
    Animator anim;
    GameObject enemy;
    GameObject player;
    DDOL ddol;
    float Counter;
    HPmanager playerHp;
    SimplePatrol patrol;
    ScaleConstraint constraints;
    public float timeBetweenAttacks = 1;
    public int attackDamage = 10;
    bool playerInRange = false;
    float timer;
    private GameObject rb2D;
    [SerializeField] Image Healthbar;
    Rigidbody2D rb;
     GameObject instance;
    [SerializeField] Collider2D col;

    private AudioSource source;

    [SerializeField] float totalHP;
    [SerializeField] float ActualHP;

    private void Awake()
    {
        patrol = transform.parent.GetComponent<SimplePatrol>();
        ddol = GameObject.Find("Manager").GetComponent<DDOL>();
        player = GameObject.Find("Player");
        rb2D = transform.parent.gameObject;
        rb = rb2D.GetComponent<Rigidbody2D>();
        playerHp = player.GetComponent<HPmanager>();
        source = GetComponent<AudioSource>();


        enemy = GetComponent<GameObject>();
        anim = GetComponent<Animator>();
        constraints = GetComponent<ScaleConstraint>();

        foreach(GameObject obj in ddol._ddolObjects)
        {
            if (obj.name == rb2D.name)
            {
                Debug.Log("ovo");
                Destroy(rb2D);
            }
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {

       
      


    }

    // Update is called once per frame
    void Update()
    {
        if (ActualHP <= 0 && Counter ==0)
        {
            
            
                ddol._ddolObjects.Add(rb2D);

            Counter++;

            
                       
        }
       
        
        Healthbar.fillAmount = ActualHP/100;
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange && (rb2D.transform.position.x > player.transform.position.x) && transform.rotation.y >= 0)
        {
            
            Attack();
        }
        if (timer >= timeBetweenAttacks && playerInRange && (rb2D.transform.position.x < player.transform.position.x) && transform.rotation.y <0)
        {
            Attack();
        }
        if (grande == true)
        {
            constraints.constraintActive = true;
            
            
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("agrandar"))
        {
            anim.SetBool("running", false);


            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                anim.SetBool("activar", false);
                grande = true;
                
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
            {
                anim.SetBool("attacking", false);


            }
        }
      
       
        if (ActualHP <= 0)
        {
            patrol = rb2D.GetComponent<SimplePatrol>();
            patrol.enabled = false;
            anim.SetBool("dead", true);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("death"))
            {
                

                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                {
                    

                    
                    Destroy(col);
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    
                    

                }
            }
        }

    }
    void Attack()
    {
        timer = 0;
        source.Play();
        anim.SetBool("attacking", true);

        if (playerHp.currentlifePoints > 0)
        {
            playerHp.TakeDamage(attackDamage);
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AtaqueBasico")
        {
            
            PlayerAttacks playerDmg = player.GetComponent<PlayerAttacks>();
            if (rb2D.transform.position.x > player.transform.position.x) {
                
                Rigidbody2D rb = rb2D.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(5, 0) * (playerDmg.forcedanobasico), ForceMode2D.Impulse);
            }
            if (rb2D.transform.position.x < player.transform.position.x)
            {
                
                Rigidbody2D rb = rb2D.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(-5, 0) * (playerDmg.forcedanobasico), ForceMode2D.Impulse);
                
            }




            ActualHP -= playerDmg.danobasico;

        }
    }
}
