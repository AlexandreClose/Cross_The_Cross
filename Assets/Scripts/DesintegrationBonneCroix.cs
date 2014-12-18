using UnityEngine;
using System.Collections;

public class DesintegrationBonneCroix : MonoBehaviour {

    private float desintegrationTime;
    public int baisseDeBatterie;
    public GameObject prefabExplosionQuandTempsEcoule;

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
        GameObject expl = Instantiate(prefabExplosionQuandTempsEcoule) as GameObject;
        expl.transform.position = gameObject.transform.position;
        GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroixFaites -= baisseDeBatterie;
        Destroy(gameObject);
        Destroy(this);
    }
}
