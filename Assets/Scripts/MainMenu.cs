using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void PlayGame()
    {
        StartCoroutine(LoadSceneAfterDelay1());
    }
    public void PlayTutorial()
    {
        StartCoroutine(LoadSceneAfterDelay2());
    }

    public void QuitGame()
    {
        StartCoroutine(LoadSceneAfterDelay3());
    }

    public void MenuLoad()
    {
        StartCoroutine(LoadSceneAfterDelay4());
    }

    IEnumerator LoadSceneAfterDelay1()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    IEnumerator LoadSceneAfterDelay2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator LoadSceneAfterDelay3()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Quit!");
        Application.Quit();
    }

    IEnumerator LoadSceneAfterDelay4()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

}
