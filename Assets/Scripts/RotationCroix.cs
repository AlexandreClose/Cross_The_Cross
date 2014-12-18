using UnityEngine;
using System.Collections;

public class RotationCroix : MonoBehaviour {

    public bool isRotational;
    public float rotationalSpeed; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isRotational)
        {
            transform.Rotate(0.0f, 0.0f, rotationalSpeed*Time.deltaTime);
        }

	}
}
