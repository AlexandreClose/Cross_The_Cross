using UnityEngine;
using System.Collections;

public class Rebonds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Vector3 vecteurDirection = other.gameObject.GetComponent<MoveRandomDir>().randomDirection;
        if(gameObject.name == "Bord_Gauche"){
            vecteurDirection.x = -vecteurDirection.x;
        }
        if(gameObject.name == "Bord_Haut"){
            vecteurDirection.y = -vecteurDirection.y;
        }
        if(gameObject.name == "Bord_Droit"){
            vecteurDirection.x = -vecteurDirection.x;
        }
        if(gameObject.name == "Bord_Bas"){
            vecteurDirection.y = -vecteurDirection.y;
        }
        other.gameObject.GetComponent<MoveRandomDir>().randomDirection = vecteurDirection;
    }

    void OnTriggerStay(Collider other)
    {
        Vector3 vecteurDirection = other.gameObject.GetComponent<MoveRandomDir>().randomDirection;
        if (gameObject.name == "Bord_Gauche")
        {
            vecteurDirection.x = -vecteurDirection.x;
        }
        if (gameObject.name == "Bord_Haut")
        {
            vecteurDirection.y = -vecteurDirection.y;
        }
        if (gameObject.name == "Bord_Droit")
        {
            vecteurDirection.x = -vecteurDirection.x;
        }
        if (gameObject.name == "Bord_Bas")
        {
            vecteurDirection.y = -vecteurDirection.y;
        }
        other.gameObject.GetComponent<MoveRandomDir>().randomDirection = vecteurDirection;
    }
}
