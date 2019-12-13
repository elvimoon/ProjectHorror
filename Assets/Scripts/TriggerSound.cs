using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{

    public AudioSource spookySource;
    public AudioClip spooky;
    bool played;
    void Start()
    {
        spookySource = GetComponent<AudioSource>();
        played = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && played == false)
        {
            spookySource.PlayOneShot(spooky);
            played = true;
        }
    }
}
