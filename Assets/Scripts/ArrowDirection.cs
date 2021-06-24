using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrowDirection : MonoBehaviour
{
    
    public GameObject Arrow;
    public Transform Joint;
    public float PowerMultiplier =3f;
    float StartingMultiplier;
    private float scrollDistanceX;
    //private float scrollDistanceY;
    public float horizontalLimit = 2.5f;
    public float verticalLimit = 0.0f;
    public float LoadSpeed = 20f;
    public float RotationSpeed = 20f;
    private Touch theTouch;

    public GameObject PointPrefab;

    public GameObject[] Points;

    public int numberOfpoints;

    Vector2 Direction;

    
   
    private void Start()
    {
         
        Points = new GameObject[numberOfpoints];
        for(int i = 0; i < numberOfpoints ; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
        StartingMultiplier = PowerMultiplier;
        scrollDistanceX = Joint.transform.position.x;
        
       // scrollDistanceY = Joint.transform.position.y;
    }
   
    void Update()
    {
        if (Input.touchCount > 0)
        {
            

            

            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Moved)
            {
                
                var scrollDeltax = -theTouch.deltaPosition.x;
               
                /**if (transform.rotation.z < 0.9)
                {
                    scrollDeltax = -scrollDeltax;
                   
                }**/
               
               
              
                    // var scrollDeltay = theTouch.deltaPosition.y;

                    scrollDistanceX = Mathf.Clamp((float)(scrollDistanceX + scrollDeltax * Time.fixedDeltaTime * LoadSpeed), -horizontalLimit, 0);
               
                // scrollDistanceY = Mathf.Clamp((float)(scrollDistanceY + scrollDeltay * Time.fixedDeltaTime * LoadSpeed), -verticalLimit, verticalLimit);

                Joint.localPosition = new Vector2(scrollDistanceX, 0);
               // scrollDistanceY =scrollDeltay*LoadSpeed* Mathf.Deg2Rad;


                // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(theTouch.position);
                // Vector2 touchPos = new Vector2(worldPoint.x, worldPoint.y);
                //transform.LookAt(new Vector2(theTouch.position.x,theTouch.position.y));
     

                var dir = new Vector3(theTouch.position.x,theTouch.position.y,0) - Camera.main.WorldToScreenPoint(transform.position);
                Direction = dir;
                 var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                angle = Mathf.Clamp(angle, 0, 90);
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                //transform.rotation = Quaternion.Euler(0.0F, 0.0F, Mathf.Atan2((theTouch.position.y - transform.position.y) * 1, (theTouch.position.x - transform.position.x) * 1) * Mathf.Rad2Deg);

                for (int i = 0; i < Points.Length; i++)
                {
                    Points[i].transform.position = PointPosition(i * 0.1f);
                }


            }
            if (theTouch.phase == TouchPhase.Ended)
            {
                for (int i = 0; i < Points.Length; i++)
                {
                    Points[i].transform.position = Vector3.zero;
                }
                if (Joint.localPosition.x < -0.15)
                {
                    PowerMultiplier *= (-Joint.transform.localPosition.x);

                    GameObject arrow = GameObject.Instantiate(Arrow, transform.position, transform.rotation);
                    arrow.GetComponent<FireArrow>().shootForce *= PowerMultiplier;

                    PowerMultiplier = StartingMultiplier;
                    Joint.transform.localPosition = Vector2.zero;
                }
            }
        }

        
    }
    Vector2 PointPosition(float t)
    {
        var force = StartingMultiplier * (-Joint.transform.localPosition.x) * 10f;
        Vector2 currentPointPos = (Vector2)transform.position + (Direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
  
}
