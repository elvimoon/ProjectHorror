using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEndSceneLoad : MonoBehaviour
{
    [SerializeField] private Transform player;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }
}
