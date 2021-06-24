using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    private float Timer;
    public float Starting_Timer = 5f;
    public GameObject Fruit;
    private int fruitRandomizer;
    public Vector2 startPos;
    public GameObject[] Fruits;
    void Start()
    {
        startPos = transform.position;

        fruitRandomizer = Random.Range(0, Fruits.Length - 1);
        Fruit = GameObject.Instantiate(Fruits[fruitRandomizer], startPos, Quaternion.identity);
        Timer = Starting_Timer;
        
}

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.fixedDeltaTime;
        if (Timer <= 0)
        {
            fruitRandomizer = Random.Range(0, Fruits.Length - 1);
            Fruit = GameObject.Instantiate(Fruits[fruitRandomizer], startPos, Quaternion.identity);
           
            if (Starting_Timer > 0.75f)
            {
                Starting_Timer -= 0.25f;
            }
            Timer = Starting_Timer;
        }
     }
}
