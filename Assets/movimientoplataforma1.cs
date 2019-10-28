using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movimientoplataforma1 : MonoBehaviour

{

    [SerializeField] float duration;
    [SerializeField] Transform posA, posB;

    float time = 0;
    SpriteRenderer spriteRenderer;
    Vector3 currentPosition;
    bool state = true;

    Rigidbody2D r;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state)
        {
            currentPosition = Vector3.Lerp(posA.position, posB.position, time / duration);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            currentPosition = Vector3.Lerp(posB.position, posA.position, time / duration);
            transform.localScale = new Vector3(1, 1, 1);
        }

        r.MovePosition(currentPosition);
        time += Time.deltaTime;
        if (time >= duration)
        {
            time = 0;
            state = !state;
        }
    }
}
