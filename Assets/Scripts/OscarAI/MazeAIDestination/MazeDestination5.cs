using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDestination5 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            this.gameObject.transform.position = new Vector3(40f, 1.5f, -74f);
        }
    }
}
