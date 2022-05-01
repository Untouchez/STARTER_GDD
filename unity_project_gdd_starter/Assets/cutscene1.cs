using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cutscene1 : MonoBehaviour
{
    public Player player;
    public CinemachineFreeLook cam;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cutscenePlaying()
    {
        print("doneplaying");
        player.inCutscene = false;
        cam.Priority = 20;
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Player>().enabled = true;
    }
}
