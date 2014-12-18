using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CoordonneeSourisDansRepereMonde : SingletonGeneric<CoordonneeSourisDansRepereMonde> {

    
    public List<Vector3> mousePos;
    public bool doigtSurEcran;
    public float timeForGetPos;
    public GameObject prefabTrainee;
    public GameObject prefabAlarme;
    public bool debutJeu;

    private GameObject alarme;

	// Use this for initialization
	void Start () {
    
    debutJeu = false;

    mousePos = new List<Vector3>();
    doigtSurEcran = false;
    StartCoroutine("getPos");

	}
	
	// Update is called once per frame
	void Update () {

        if (doigtSurEcran)
        {
            Vector3 position3DActuelle = Input.mousePosition;
            position3DActuelle.z = 9;
            position3DActuelle = Camera.main.ScreenToWorldPoint(position3DActuelle);
            GameObject trainee = Instantiate(prefabTrainee) as GameObject;
            trainee.transform.parent = GameObject.Find("0 - Trainees").transform;
            trainee.transform.position = position3DActuelle;
            Destroy(trainee, 1);
        }

        else if (!doigtSurEcran && alarme == null && debutJeu && RemplissageBatterie.Instance.enJeu)
        {
             alarme = Instantiate(prefabAlarme) as GameObject;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseDown = new Vector3();
            mouseDown = Input.mousePosition;
            mouseDown.z = 9;
            mouseDown = Camera.main.ScreenToWorldPoint(mouseDown);
            mousePos.Add(mouseDown);
            
            doigtSurEcran = true;
            debutJeu = true;
            GameObject empreinte = GameObject.Find("Empreinte") as GameObject;
            empreinte.GetComponent<Image>().enabled = false;

            GameObject poseDoigt = GameObject.Find("PoseDoigt") as GameObject;
            poseDoigt.GetComponent<Text>().enabled = false;

            if (mousePos.Count > 2)
            {
                mousePos.RemoveAt(0);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouseUp = new Vector3();
            mouseUp = Input.mousePosition;
            mouseUp.z = 9;
            mouseUp = Camera.main.ScreenToWorldPoint(mouseUp);
            mousePos.Add(mouseUp);
            doigtSurEcran = false;
            mousePos.Clear();
        }

       
        
	}
    IEnumerator getPos()
    {
        while (true)
        {
            if (doigtSurEcran)
            {
                Vector3 position3DActuelle = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9);
                position3DActuelle = Camera.main.ScreenToWorldPoint(position3DActuelle);
                mousePos.Add(position3DActuelle);
                
                
            }

            if (mousePos.Count > 2)
            {
                mousePos.RemoveAt(0);
            }
            yield return new WaitForSeconds(timeForGetPos);
        }
        
        
    }



}
