using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Continuar : MonoBehaviour
{
    
    [SerializeField] private string escena;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AutoGuardado.Load();
        if (collision.gameObject.tag == "Player" && GameObject.Find("Boss") == null)
        {
            SceneManager.LoadScene(escena);
        }
    }

    public void CambioEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
