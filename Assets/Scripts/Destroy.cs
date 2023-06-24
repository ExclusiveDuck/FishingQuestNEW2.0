using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // destroying Gameobject (fish) 2.5 seconds after catching it.
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

}


