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
    public int currentQuest = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void StartQuest()
    {
        if (currentQuest == 0)
        {
            FindObjectOfType<QuestManager>().quest1.SetActive(true);
        }
    }

    public void StartSecondQuest()
    {
        Player player = FindObjectOfType<Player>();
        player.quest = null;
        FindObjectOfType<QuestCanvas>().questUI.SetActive(false);
    }


}
