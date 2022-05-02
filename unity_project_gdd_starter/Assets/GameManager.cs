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

    public GameObject questReward;
    public bool hasKey;
    public Key key; 

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
        if (currentQuest == 1)
        {
            FindObjectOfType<QuestManager>().quest2.SetActive(true);
        }

        currentQuest += 1;
    }

    public void EndQuest()
    {
        Player player = FindObjectOfType<Player>();
        player.quest = null;
        //FindObjectOfType<QuestCanvas>().questUI.SetActive(false);

        if (currentQuest == 2)
        {
            for (int i = 0; i < 30; i++)
            {
                Instantiate(questReward, FindObjectOfType<QuestManager>().spawnLocation.transform.position, Quaternion.identity);
            }
        }
    }

    public void StartKeyQuest()
    {
        key.gameObject.SetActive(true);
    }


}
