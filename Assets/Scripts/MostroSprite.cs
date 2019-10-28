using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostroSprite : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite mostrom;
    new SpriteRenderer renderer;
     CapsuleCollider2D col;
    CapsuleCollider2D colattack;

    void Awake()
    {
        renderer = gameObject.transform.Find("srenderer").GetComponent<SpriteRenderer>();
        col = GetComponent<CapsuleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        renderer.sprite = mostrom;
        Destroy(col);
        Destroy(colattack);
    }
}
