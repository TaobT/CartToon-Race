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
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoadStartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }

    public void LoadLevel()
    {
        //Load level1
        UnityEngine.SceneManagement.SceneManager.LoadScene(Level1Name);
    }

    public bool LoadNextLevel()
    {
        if (!GameManager.Instance.Race1Completed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level1Name);
            return true;
        }
        else if(!GameManager.Instance.Race2Completed)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(Level2Name);
            return true;
        }
        //else if(!GameManager.Instance.Race3Completed)
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(Level3Name);
        //    return true;
        //}

        return false;
    }
}