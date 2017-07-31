using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

    Camera mainCam;
    Camera_Control camControl;

    GameObject player;

    public GameObject playerOri;
    public GameObject greenOri;

    public Transform greenSpawn;
    public Transform playerSpawn;

    List<GameObject> greens = new List<GameObject>();

    // Use this for initialization
    void Start () {

        if (mainCam == null)
        {
            mainCam = Camera.main;
            camControl = mainCam.GetComponent<Camera_Control>();
        }
        
        Spawn_Green(Vector3.zero);
        playerSpawn = greens[0].transform.GetChild(4);
        Spawn_Player(playerSpawn.position);
    }

    void Spawn_Green(Vector3 greenPos)
    {
        GameObject newGreen = (GameObject)Instantiate(greenOri, greenPos, Quaternion.identity);
        greens.Add(newGreen);
    }
    
    void Spawn_Player(Vector3 playerPos)
    {
        if (player != null)
        {
            Destroy(player);
        }
        GameObject newPlayer = (GameObject)Instantiate(playerOri, playerPos, Quaternion.identity);
        player = newPlayer;
    }

	void Update () {

        if (Input.GetKeyUp(KeyCode.A))
        {
            print(greenSpawn.position);
            Spawn_Green(greenSpawn.position);
        }
		
	}
}
