using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasaNivel : MonoBehaviour
{
    [SerializeField] private string escena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameObject.Find("Boss")==null)
        {
            SceneManager.LoadScene(escena);
        }
    }

    public void CambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
