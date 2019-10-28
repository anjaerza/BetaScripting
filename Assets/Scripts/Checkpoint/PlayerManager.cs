using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    private GameMaster gm;
    private HPmanager hpManager;
    private Bank banco;

    public HPmanager HpManager { get => hpManager; set => hpManager = value; }
    public GameMaster Gm { get => gm; set => gm = value; }

    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.FindGameObjectsWithTag
        HpManager = transform.GetComponent<HPmanager>();
        Gm = FindObjectOfType<GameMaster>();
        transform.position = Gm.ultimocheckpos;
        banco = GetComponent<Bank>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HpManager.currentlifePoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, this.GetComponent<Bank>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        HpManager.currentlifePoints = data.vida;
        banco.goldCounterA = data.monedas;

        Vector3 position;

        position.x = data.posicion[0];
        position.y = data.posicion[1];
        position.z = data.posicion[2];

        transform.position = position;

    }
   
}
