using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour

{
    [SerializeField] Transform pivot;
    [SerializeField] plomo projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAttackStart()
    {
        plomo clon = Instantiate(projectile, pivot.position, Quaternion.identity);
        clon.Fire(-transform.right);
    }

    
}
