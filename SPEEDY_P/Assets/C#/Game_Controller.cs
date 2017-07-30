using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

    Camera mainCam;
    Camera_Control camControl;

    public GameObject playerOri;
    public GameObject greenOri;

    // Use this for initialization
    void Start () {

        if (mainCam == null)
        {
            mainCam = Camera.main;
            camControl = mainCam.GetComponent<Camera_Control>();
        }

        Spawn_Green(Vector3.zero);

    }

    void Spawn_Green(Vector3 greenPos)
    {
        GameObject newGreen = (GameObject)Instantiate(greenOri, greenPos, Quaternion.identity);
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
