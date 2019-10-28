using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detecta colision");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPmanager>().TakeDamage(100);
            Debug.Log("Detecta player");
        }
    }
}
