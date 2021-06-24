using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowStretch : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] BowStates;
    public Transform Joint;
    public float[] points = { 0.0f, -0.3f, -0.6f, -1.2f, -1.5f };
    SpriteRenderer renderer;
    public Vector2[] positionsBowEnd1;
    public Vector2[] positionsBowEnd2;
    public Transform BowEnd1, BowEnd2;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Joint.localPosition.x >= -0.25f)
        {
            BowEnd1.localPosition = positionsBowEnd1[0];
            BowEnd2.localPosition = positionsBowEnd2[0];
            renderer.sprite = BowStates[0];
        }else if(Joint.localPosition.x < -0.25 && Joint.localPosition.x > -0.5f)
        {
            BowEnd1.localPosition = positionsBowEnd1[1];
            BowEnd2.localPosition = positionsBowEnd2[1];
            renderer.sprite = BowStates[1];
        }
        else if (Joint.localPosition.x < -0.5 && Joint.localPosition.x > -0.75f)
        {
            BowEnd1.localPosition = positionsBowEnd1[2];
            BowEnd2.localPosition = positionsBowEnd2[2];
            renderer.sprite = BowStates[2];
        }
        else if (Joint.localPosition.x < -0.75 && Joint.localPosition.x > -1.0f)
        {
            BowEnd1.localPosition = positionsBowEnd1[3];
            BowEnd2.localPosition = positionsBowEnd2[3];
            renderer.sprite = BowStates[3];
        }
        else if (Joint.localPosition.x < -1.0 && Joint.localPosition.x > -1.25f)
        {
            BowEnd1.localPosition = positionsBowEnd1[4];
            BowEnd2.localPosition = positionsBowEnd2[4];
            renderer.sprite = BowStates[4];
        }
        else //(Joint.localPosition.x < -1.25 && Joint.localPosition.x > -1.5f)
        {
            BowEnd1.localPosition = positionsBowEnd1[5];
            BowEnd2.localPosition = positionsBowEnd2[5];
            renderer.sprite = BowStates[5];
            //Joint.localPosition = new Vector2(-1.85f, 0);
        }
        
        
    }
}
