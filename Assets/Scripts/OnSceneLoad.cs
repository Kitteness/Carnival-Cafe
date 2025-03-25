using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour
{
    public UnityEvent OnLoad;

    public void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
    }
}
