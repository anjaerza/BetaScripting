using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL :MonoBehaviour
{
  [SerializeField]  public  List<GameObject> _ddolObjects;

    public static void NoDestruirAlCargar()
    {
       
    }
    private void Update()
    {
        foreach (GameObject obj in _ddolObjects)
        {
            DontDestroyOnLoad(obj);
            
        }
    }

   
}
