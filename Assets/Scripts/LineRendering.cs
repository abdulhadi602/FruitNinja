using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendering : MonoBehaviour
{
    // Start is called before the first frame update
    LineRenderer render;
    public Transform BowEnd1, BowEnd2, Joint;

    void Start()
    {
        render = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        render.SetPosition(0,BowEnd1.localPosition);
        render.SetPosition(1, Joint.localPosition);
        render.SetPosition(2, BowEnd2.localPosition);
    }
}
