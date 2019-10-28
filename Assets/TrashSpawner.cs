using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    float timer;
    [SerializeField] float SpawnRate;
    
    [SerializeField] fallingtrash trash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnRate)
        {
            SpawnTrash();
        }
    }
    void SpawnTrash()
    {
        timer = 0;
        fallingtrash clon = Instantiate(trash, transform.position, Quaternion.identity);
        clon.Falling = true;
    }
}
