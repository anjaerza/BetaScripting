using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiondetector : MonoBehaviour
{
    private bool CollisionPlayer ;
    private bool GoingPoint1 ;
    private bool GoingPoint2 ;
    private bool CollisionObstacle ;
    private bool CollisionFinal1 ;
    private bool CollisionFinal2 ;

    public bool CollisionPlayer1 { get => CollisionPlayer; set => CollisionPlayer = value; }
    public bool GoingPoint11 { get => GoingPoint1; set => GoingPoint1 = value; }
    public bool GoingPoint21 { get => GoingPoint2; set => GoingPoint2 = value; }
    public bool CollisionObstacle1 { get => CollisionObstacle; set => CollisionObstacle = value; }
    public bool CollisionFinal11 { get => CollisionFinal1; set => CollisionFinal1 = value; }
    public bool CollisionFinal21 { get => CollisionFinal2; set => CollisionFinal2 = value; }

    // Start is called before the first frame update
    void Start()
    {
     CollisionPlayer1=false;
     GoingPoint11=false;
     GoingPoint21=true;
     CollisionObstacle1=false;
     CollisionFinal11=false;
     CollisionFinal21=false;

}

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            CollisionPlayer1 = true;
            GoingPoint21 = false;
            GoingPoint11 = false;
        }
        if (collision.gameObject.tag == "Final1")
        {
            CollisionFinal11 = true;
            CollisionPlayer1 = false;
        }
        if (collision.gameObject.tag == "Final2")
        {
            CollisionFinal21 = true;
            CollisionPlayer1 = false;
        }

      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            CollisionObstacle1 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.gameObject.tag =="floor")
        {
            CollisionObstacle1 = false;
        }
        if (collision.gameObject.tag == "Point1")
        {
            GoingPoint11 = false;
            GoingPoint21 = true;
        }
        if (collision.gameObject.tag == "Point2")
        {
            GoingPoint11 = true;
            GoingPoint21 = false;

        }






    }

}
