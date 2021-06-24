using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcFire : MonoBehaviour
{
    public AnimationCurve curve;
    public Transform target;

    private Vector3 start;
    private Coroutine coroutine;

    private void Awake()
    {
        start = transform.position;
    }

    private void Update()
    {
        
    }

   
}
