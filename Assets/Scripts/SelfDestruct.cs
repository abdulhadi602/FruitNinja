using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
   public void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
}
