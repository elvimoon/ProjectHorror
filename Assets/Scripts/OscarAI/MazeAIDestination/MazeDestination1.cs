using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDestination1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            this.gameObject.transform.position = new Vector3(36, 1.5f, -54);
        }
    }
}
