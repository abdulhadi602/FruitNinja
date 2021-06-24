using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    // Start is called before the first frame update
    public float shootForce;
    Rigidbody2D rigidbody;
    Collider2D collider;
    SpriteRenderer renderer;
    public Vector2 shootingDir;
    public Vector2 startPos;
    int rotationSpeed;
    private bool hit;
    
    void Start()
    {
       
        
            shootForce = Random.Range(7, 9);
            shootingDir = new Vector2(Random.Range(-0.2f, 0.3f), 1);
       
       
        //renderer = GetComponent<SpriteRenderer>();
        //collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();

       // int sprite = Random.RandomRange(0, fruits.Length - 1);
        //renderer.sprite = fruits[sprite];
        rotationSpeed = Random.Range(100, 350);
        startPos = transform.position;
      
        rigidbody.AddForce(shootingDir * shootForce*100);
    }

    // Update is called once per frame
    void Update()
    {
       /**if (Input.GetKey(KeyCode.Mouse0))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (Transform fruitpiece in transform)
            {
                fruitpiece.gameObject.SetActive(true);
            }
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }**/
        if (!hit)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed, Space.World);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Arrow" )
        {
            hit = true;
            //GameObject.Instantiate(gameObject, startPos, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            foreach (Transform fruitpiece in transform)
            {
                fruitpiece.gameObject.SetActive(true);
            }
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
           
           /** transform.parent = collision.transform.GetChild(0);
            transform.localPosition = Vector2.zero;**/
           
        }
       
        else if(collision.tag == "BaseWall")
        {
          
            Destroy(gameObject);
        }
    }
}
