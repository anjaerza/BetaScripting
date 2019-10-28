using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class AutoGuardado : MonoBehaviour
{
    [SerializeField]
    static GameMaster gm;
    [SerializeField]
    static HPmanager hpm;
    [SerializeField]
    static Bank monedas;
    [SerializeField]
    static GameObject player;
    [SerializeField]
    static AutoGuardado este;
    private Vector3 positionPlayer;
    private void Start()
    {
        RePos();

    }

    public static void Save()
    {
        PlayerPrefs.SetFloat("lifePoints", hpm.CurrentlifePoints);
        PlayerPrefs.SetFloat("coinsA", monedas.goldCounterA);
        PlayerPrefs.SetFloat("coinsB", monedas.goldCounterB);
        PlayerPrefs.SetFloat("pX", gm.ultimocheckpos.x);
        PlayerPrefs.SetFloat("pY", gm.ultimocheckpos.y);
        PlayerPrefs.SetFloat("pZ", gm.ultimocheckpos.z);
    }
    void RePos()
    {
        positionPlayer = new Vector3(
        PlayerPrefs.GetFloat("pX"),
        PlayerPrefs.GetFloat("pY"),
        PlayerPrefs.GetFloat("pZ"));
    }
    public static void Load()
    {
        hpm.currentlifePoints = PlayerPrefs.GetFloat("lifePoints", 100);
        monedas.goldCounterA = PlayerPrefs.GetFloat("coinsA", 0);
        monedas.goldCounterB = PlayerPrefs.GetFloat("coinsB", 0);
        player.transform.position = este.positionPlayer;
    }


}