using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Bank : MonoBehaviour
{


    [SerializeField] private TMPro.TextMeshProUGUI textomoneda;

    [SerializeField] private TMPro.TextMeshProUGUI textomoneda2;

    public float goldCounterA;
    public float goldCounterB;
    private float Mostrarpuntuacion;
    private float Mostrarpuntuacion2;


    // Update is called once per frame
    void Update()
    {
        Mostrarpuntuacion = goldCounterA;
        Mostrarpuntuacion2= goldCounterB;
        textomoneda.text = Mostrarpuntuacion.ToString("F0");
       

       


    }



}
