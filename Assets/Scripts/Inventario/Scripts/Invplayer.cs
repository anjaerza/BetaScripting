using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invplayer : MonoBehaviour
{
    public bool[] lleno;
    public GameObject[] hueco;
    public List<GameObject> objetosRecolectados;
    public GameObject[] icon;

    // Start is called before the first frame update
    void Start()
    {
        icon = GameObject.FindGameObjectsWithTag("HabilityIcon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
