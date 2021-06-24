using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public float shootForce = 20f;
    Rigidbody2D rigidbody;
    BoxCollider2D collider;
    SpriteRenderer renderer;
    FireArrow sc;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        rigidbody.AddForce(transform.right * shootForce);
        renderer = GetComponent<SpriteRenderer>();
        sc = GetComponent<FireArrow>();
       
    }
    
    // Update is called once per frame
    void Update()
    {  
        transform.right = Vector3.Slerp(transform.right, rigidbody.velocity.normalized, Time.fixedDeltaTime*25);
      
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall" && tag == "Arrow")
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(rigidbody);
            Destroy(collider);
            Destroy(sc);
            Destroy(gameObject, 10);
            renderer.sortingOrder = 1;
          
        }
   
      
    }

}
