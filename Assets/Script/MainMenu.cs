using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fade;
    public float delayBeforeSceneChange = 2.0f; // Durasi jeda sebelum mengganti scene

    public void Play()
    {
        fade.GetComponent<Animator>().SetBool("fade", true);
        StartCoroutine(LoadSceneAfterDelay("Main Scene Jeje"));
    }

    // Coroutine untuk mengganti scene setelah jeda
    IEnumerator LoadSceneAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSceneChange);
        SceneManager.LoadScene(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
