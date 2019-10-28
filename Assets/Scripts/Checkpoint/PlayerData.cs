using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float monedas;
    public float vida;
    public float[] posicion;

    public PlayerData(PlayerManager pm, Bank banco)
    {
        monedas = banco.goldCounterA;
        vida = pm.HpManager.currentlifePoints;
        posicion = new float[3];
        posicion[0] = pm.transform.position.x;
        posicion[1] = pm.transform.position.y;
        posicion[2] = pm.transform.position.z;

    }
}
