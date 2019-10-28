using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mostroataque : MonoBehaviour
{
    [SerializeField] Color colorataque;
    new SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = transform.parent.Find("srenderer").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        renderer.color = colorataque;

    }

 
}
