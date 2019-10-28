using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plomo : MonoBehaviour

{

    [SerializeField] float duration;
    float time = 0;
    new Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= duration)
        {
            Destroy(gameObject);
        }
        
    }

    public void Fire(Vector3 _direction)
    {
        rigidbody.AddForce(_direction * 500);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        time = duration - 0.5f;
    }
}
