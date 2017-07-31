using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg_Control : MonoBehaviour {

    public int offsetX;
    public int offsetY;
    public int offsetAlt;
    public int pengCount;

    public GameObject pegOri;

    GameObject lastRef;

    Dictionary<GameObject, List<GameObject>> pegs = new Dictionary<GameObject, List<GameObject>>();

    void Start () {

        for (int i = 0; i < 4; i++)
        {
            Peg_Column();
        }
	}

    void Peg_Column()
    {
        GameObject refPeg = (GameObject)Instantiate(pegOri, transform.position, Quaternion.identity);
        pegs.Add(refPeg, new List<GameObject>());
        lastRef = refPeg;

        for (int i = 0; i < pengCount; i++)
        {
            if (i % 2 == 0)
            {
                Vector3 newPos = refPeg.transform.position + Vector3.down * i * offsetX;
                GameObject newPeg = (GameObject)Instantiate(pegOri, newPos, Quaternion.identity);
                pegs[refPeg].Add(newPeg);
            }
            else
            {
                Vector3 newPos = refPeg.transform.position + Vector3.down * i * offsetX;
                GameObject newPeg = (GameObject)Instantiate(pegOri, newPos, Quaternion.identity);
                pegs[refPeg].Add(newPeg);
            }
            
        }
    }
	
	void Update () {
		
	}
}
