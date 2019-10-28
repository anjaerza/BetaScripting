using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip pista;
    private AudioSource player;
    private int flip;
    private bool cambio;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
        cambio = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cambio == true)
        {
            player.clip = pista;
            if (player.isPlaying == false)
            {
                player.Play();
            }
        }
     
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cambio = true;
    }
}
