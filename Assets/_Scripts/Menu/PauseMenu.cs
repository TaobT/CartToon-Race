using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Awake()
    {
        InputManager.OnPausePerformed += () => gameObject.SetActive(!gameObject.activeSelf);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        Debug.Log("PauseMenu Disabled");
    }

    public void Resume()
    {
        gameObject.SetActive(false);
    }

    public void Restart()
    {
        LevelLoader.Instance.ReloadLevel();
    }

    public void MainMenu()
    {
        LevelLoader.Instance.LoadStartScene();
    }
}
