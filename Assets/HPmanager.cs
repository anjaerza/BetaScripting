using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPmanager : MonoBehaviour
{
   [SerializeField] float lifePoints;
    public float currentlifePoints;
    GameObject enemyrat;
    [SerializeField] Image Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentlifePoints = lifePoints;
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = currentlifePoints/100;
    }
   public void TakeDamage(float dano)
    {
        currentlifePoints -= dano;
    }
    public float CurrentlifePoints
    {
        get { return currentlifePoints; }
    }
   

}
