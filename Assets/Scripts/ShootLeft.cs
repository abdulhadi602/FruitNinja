using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeft : MonoBehaviour
{
    private float shootForce;
    private Vector2 shootingDir;
    Rigidbody2D rigidbody;
    int rotationSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        shootForce = Random.Range(5, 8);
        shootingDir = new Vector2(Random.Range(-0.6f,-0.9f), 0.6f);
        rigidbody.AddForce(shootingDir * shootForce * 100);
        rotationSpeed = Random.Range(100, 350);
        Destroy(gameObject, 2);
    }
    private void Update()
    {
        transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed, Space.World);
    }
  
}
