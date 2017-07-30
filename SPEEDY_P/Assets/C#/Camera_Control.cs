using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

    GameObject camFollow;

    GameObject player;
    Rigidbody2D playerRb;

    public float offSetCamZ;

    public float smoothTime;

    Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {

        camFollow = GameObject.FindGameObjectWithTag("CameraFollow");
	}

    private void FixedUpdate()
    {
        if (playerRb != null)
        {
            camFollow.transform.position = playerRb.transform.position;
            Vector3 moveToo = camFollow.transform.TransformPoint(new Vector3(0, 0, -offSetCamZ));
            transform.position = Vector3.SmoothDamp(transform.position, moveToo, ref velocity, smoothTime);
        }
        
    }

    public void Update_Follow(GameObject newPlayer)
    {
        player = newPlayer;
        playerRb = newPlayer.GetComponent<Rigidbody2D>();

    }
}
