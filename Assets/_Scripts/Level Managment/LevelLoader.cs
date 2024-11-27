using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    [SerializeField] private string Level1Name;
    [SerializeField] private string Level2Name;
    [SerializeField] private string Level3Name;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }

    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Level1Name);
    }

    public void LoadLevel(int index)
    {
        if (index < 1 || index > 3) return;
        switch (index)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene(Level1Name);
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene(Level2Name);
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene(Level3Name);
                break;
        }
    }

    public bool LoadNextLevel()
    {
        if (!GameManager.Instance.Race1Completed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level1Name);
            return true;
        }
        else if (!GameManager.Instance.Race2Completed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level2Name);
            return true;
        }
        else if (!GameManager.Instance.Race3Completed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level3Name);
            return true;
        }

        return false;
    }

    public void ReloadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}