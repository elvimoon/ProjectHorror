using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationChange : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            xPos = Random.Range(17, 34);
            zPos = Random.Range(-45, -30);
            this.gameObject.transform.position = new Vector3(xPos, 1.5f, zPos);
        }
    }
}
