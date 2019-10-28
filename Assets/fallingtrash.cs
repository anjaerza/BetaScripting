using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingtrash : MonoBehaviour
{
    private GameObject trashrb;
    Rigidbody2D rb;
    private int counter;
    bool falling = false;

    public bool Falling { get => falling; set => falling = value; }

    // Start is called before the first frame update
    void Start()
    {
        
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Falling == true)
        {

        
            if (rb.velocity == new Vector2(0,0) || counter ==8)
            {
            Destroy(this.gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {

            counter++;
            rb.AddForce(new Vector2(-3, 0) * 0.5f, ForceMode2D.Impulse);
        }

        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<HPmanager>().currentlifePoints -= 50;
            Destroy(gameObject);
        }
    }
}
