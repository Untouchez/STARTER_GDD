using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public string gameScene;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void StartSecondQuest()
    {
        FindObjectOfType<Player>().quest = null;
        FindObjectOfType<QuestCanvas>().questUI.SetActive(false);
    }


}
