using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrar : MonoBehaviour
{
    bool cerrado =true;
    public GameObject inv;
    float timer = 0;
    int contador = 0;

    public void AbrirCerrar()
    {
        if (cerrado == true)
        {
            inv.SetActive(true);
            cerrado = false;
        }
        else
        {
            inv.SetActive(false);
            cerrado = true;
        }
    }
    public void Start()
    {
        inv.SetActive(true);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 0.01 && contador ==0)
        {
            Iniciar();
            contador++;
        }
    }
    public void Iniciar()
    {
        inv.SetActive(false);
    }
}
