using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Script : MonoBehaviour {

    public Surface_Creator surfaceOri;

    Vector3 surfaceSpawnPos;
    Vector3 surfaceTopRef;
    Vector3 surfaceLeftRef;

    // Use this for initialization
    void Start () {

        surfaceSpawnPos = transform.GetChild(1).position;
        surfaceTopRef = transform.GetChild(2).position;
        surfaceLeftRef = transform.GetChild(3).position;
        Spawn_Surface();
	}

    void Spawn_Surface()
    {
        Surface_Creator newSurface = (Surface_Creator)Instantiate(surfaceOri, surfaceSpawnPos, Quaternion.identity);
        newSurface.greenHeight = surfaceTopRef.y - surfaceSpawnPos.y;
        newSurface.greenWidth = surfaceSpawnPos.x - surfaceLeftRef.x;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
