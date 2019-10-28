using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    public static Checkpoint current;
    private GameMaster gm;
    private bool its_active = false;
    Animator animator;
    private Vector3 ultimoChekAG;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            if(its_active == false)
            {
                GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("Activado", true);
                gm.ultimocheckpos = transform.position;
                animator.SetBool("rotar", true);
                its_active = true;
                AutoGuardado.Save();
            }
            else if(its_active == true)
            {
                Debug.Log("Chackpoint ya activado");
            }
        }
    }
}
