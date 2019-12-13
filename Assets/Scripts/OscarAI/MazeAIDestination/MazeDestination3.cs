using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDestination3 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            this.gameObject.transform.position = new Vector3(12f, 1.5f, -50f);
        }
    }
}
