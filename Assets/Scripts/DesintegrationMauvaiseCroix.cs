using UnityEngine;
using System.Collections;

public class DesintegrationMauvaiseCroix : MonoBehaviour {

    private float desintegrationTime;

	// Use this for initialization
	void Start () {
        desintegrationTime = gameObject.GetComponent<ParticleSystem>().startLifetime;
        StartCoroutine("desintegrateAfterTime");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator desintegrateAfterTime()
    {
        yield return new WaitForSeconds(desintegrationTime);
        Destroy(gameObject);
    }
}
