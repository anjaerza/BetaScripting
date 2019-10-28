using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour {

    public GameObject startpoint;
    private GameObject playerTarget;
    public collisiondetector Collidervision;
    public GameObject sprite;
    public Rigidbody2D rb;
    private  SpriteRenderer spRenderer;
    public Collider2D Colliderpoint1;
    public Collider2D Colliderpoint2;
    public float timer;
    public Animator anim;
    public bool walkingback;
   
    public float EnemySpeed;
    public float timestill;
    public bool patrolling;
    public bool chasing;
    Vector3 prevPos;




    // Use this for initialization
    void Start ()
    {
       spRenderer = transform.Find("Ratanim").GetComponent<SpriteRenderer>();
        playerTarget = GameObject.Find("Player");
        patrolling = true;
        chasing = false;
        anim = transform.Find("Ratanim").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Collidervision = gameObject.GetComponentInChildren<collisiondetector>();
            
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (prevPos == transform.position && chasing == true)
        {
            timestill += Time.deltaTime;
            if (timestill >= 1)
            {
                timestill = 0;
               
               
                Forfeit();

            }
           
        }
        prevPos = transform.position;
        if (Collidervision.CollisionObstacle1 == true)
        {
            
            if(timer>=0.5)
            {
                Jump();
            }

           
        }
        if (Collidervision.CollisionPlayer1 == true)
        {

            Chasing();
        }
        if (Collidervision.CollisionFinal11==true || Collidervision.CollisionFinal21 == true)
        {
            Forfeit();
        }
        if (chasing == false)
        {
            spRenderer.color = new Color(1, 1, 1);
        }
        if (chasing == true)
        {
            spRenderer.color = new Color(1, 0, 0);
            if (transform.position.x > playerTarget.transform.position.x)
            {

                transform.position += transform.right * -1 * EnemySpeed * Time.deltaTime;

              

                sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (transform.position.x < playerTarget.transform.position.x)
            {

                transform.position += transform.right * 1 * EnemySpeed * Time.deltaTime;
               

                sprite.transform.rotation = new Quaternion(0, -180, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, -180, 0, 0);
            }

        }
        if (walkingback == true )
        {
            transform.position = Vector2.MoveTowards(transform.position, startpoint.transform.position,5 * Time.deltaTime);
            if(transform.position.x < startpoint.transform.position.x)
            {
                sprite.transform.rotation = new Quaternion(0, -180, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, -180, 0, 0);
            }
            if (transform.position.x > startpoint.transform.position.x)
            {
                sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, 0, 0, 0);
            }

        }

        if (patrolling == true)
        {
            anim.SetBool("running", true);

            if (Collidervision.GoingPoint11 == true)
            {
                Collidervision.CollisionFinal11 = false;
                Collidervision.CollisionFinal21 = false;
                walkingback = false;

                transform.position += transform.right *-1* EnemySpeed * Time.deltaTime;
                

                sprite.transform.rotation = new Quaternion(0, 0, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, 0, 0, 0);
              
            }


            if (Collidervision.GoingPoint21 == true)
            {
                Collidervision.CollisionFinal11 = false;
                Collidervision.CollisionFinal21 = false;
                walkingback = false;
                transform.position += transform.right * 1 * EnemySpeed * Time.deltaTime;
                

                sprite.transform.rotation = new Quaternion(0, -180, 0, 0);
                Collidervision.transform.rotation = new Quaternion(0, -180, 0, 0);

            }
            
           
        }
        if(patrolling == false && chasing == false)
        {
            anim.SetBool("running", false);
        }
       

    }
   
    public void Jump()
    {
        rb.AddForce(new Vector2(0, 10) * 135, ForceMode2D.Impulse);
        timer = 0;
        
    }
    public void Forfeit()
    {
        Collidervision.CollisionPlayer1 = false;
        Colliderpoint1.enabled = true;
        Colliderpoint2.enabled = true;
        walkingback = true;
        chasing = false;
        patrolling = true;
    }
    public void Chasing()
    {
        chasing = true;
        patrolling= false;
        Colliderpoint1.enabled = false;
        Colliderpoint2.enabled = false;
    }
    public void Stay()
    {
        Collidervision.GetComponent<PolygonCollider2D>().enabled = false;
        patrolling = false;
        chasing = false;
      
    }
	





}
     
