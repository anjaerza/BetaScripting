using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partida : MonoBehaviour
{
    [SerializeField]private GameObject menu;
    bool toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            menu.SetActive(toggle);
            toggle = !toggle;
       
        }
    }
}
