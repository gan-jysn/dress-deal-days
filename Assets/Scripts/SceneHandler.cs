using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    public static SceneHandler Instance;

    [SerializeField] private bool hasDelay = false;
    [SerializeField] private float delay = 0f;

    private void Awake() {
        //Singleton
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    //Loads Scene given Scene Name
    public void LoadScene(string sceneName) {
        if (string.IsNullOrEmpty(sceneName))
            return;

        if (!hasDelay) {
            SceneManager.LoadScene(sceneName);
        } else if (hasDelay) {
            StartCoroutine(DelayLoad(sceneName));
        }
    }

    private IEnumerator DelayLoad(string sceneName) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApplication() {
        StartCoroutine(DelayQuit());
    }

    private IEnumerator DelayQuit() {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
