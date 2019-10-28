using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rec : MonoBehaviour
{
    private Invplayer invplayer;
    public GameObject item;
    [SerializeField] GameObject itemimage;
    private GameObject clon;
    


    // Start is called before the first frame update
    void Start()
    {
        
       invplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Invplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            
            for (int i = 0; i < invplayer.hueco.Length; i++)
            {
                if(invplayer.lleno[i] == false)
                {
                    invplayer.lleno[i] = true;
                    invplayer.hueco[i] = this.gameObject;
                    clon = Instantiate(item, invplayer.icon[i].gameObject.transform, false);
                    
                    clon.AddComponent<Image>().sprite = itemimage.GetComponentInChildren<SpriteRenderer>().sprite;
                    clon.transform.localScale = new Vector3(0.2324f, 0.2324f, 0.2324f);
                    clon.transform.position = new Vector3(clon.transform.position.x-5,clon.transform.position.y,clon.transform.position.z) ;


                    transform.gameObject.SetActive(false);

                    break;
                }
                
            }
        }
    }
}
