using UnityEngine;
using System.Collections;

public class CroixHasard : MonoBehaviour {

    public float tauxApparition;
    public Camera cameraJeu;
    public GameObject prefabetincelle1;
    public GameObject prefabetincelle2;
    

    public float tauxCroixFixe;
    public float tauxCroixRotation;
    public float tauxCroixMouvement;
    public float tauxCroixMouvementRotation;
    public float tauxCroixRouge;

    private float cooldown;

	// Use this for initialization
	void Start () {
     
        cooldown = 0.0f;
	
	}
	
	// Update is called once per frame
	void Update () {

        bool debutJeu = CoordonneeSourisDansRepereMonde.Instance.debutJeu;
        
        if (debutJeu)
        {
            if (cooldown <= 0)
            {
                creerCroix();
                cooldown = tauxApparition;
            }

            cooldown -= Time.deltaTime;
	    }
}

    public void creerCroixFixe(GameObject etincelle)
    {
            etincelle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            etincelle.GetComponent<RotationCroix>().isRotational = false;
            etincelle.GetComponent<MoveRandomDir>().isEnMouvement = false;
    }

    public void creerCroixEnRotation(GameObject etincelle)
    {
            etincelle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            etincelle.GetComponent<RotationCroix>().isRotational = true;
            etincelle.GetComponent<MoveRandomDir>().isEnMouvement = false;

    }

    public void creerCroixMouvement(GameObject etincelle)
    {
        etincelle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        etincelle.GetComponent<RotationCroix>().isRotational = false;
        etincelle.GetComponent<MoveRandomDir>().isEnMouvement = true;
    }

    public void creerCroixMouvementRotation(GameObject etincelle)
    {
       
        etincelle.transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        etincelle.GetComponent<RotationCroix>().isRotational = true;
        etincelle.GetComponent<MoveRandomDir>().isEnMouvement = true;
    }

    public void creerCroix()
    {
        //pour savoir si la croix est bonne ou mauvaise
        float tauxHasard = Random.Range(0.0f, 100.0f);
        float tauxStatutCroix = Random.Range(0.0f, 100.0f);
        float epaisseurBordure = 0.3f;

        float xMin = GameObject.Find("Bord_Gauche").transform.position.x+epaisseurBordure;
        float xMax = GameObject.Find("Bord_Droit").transform.position.x-epaisseurBordure;

        float yMin = GameObject.Find("Bord_Bas").transform.position.y+epaisseurBordure;
        float yMax = GameObject.Find("Bord_Haut").transform.position.y-epaisseurBordure;

        float xHasard = Random.Range(xMin, xMax);
        float yHasard = Random.Range(yMin, yMax);

 
        bool isBonneCroix;
        if (tauxStatutCroix < tauxCroixRouge)
        {
            isBonneCroix = false;
        }
        else
        {
            isBonneCroix = true;
        }

        GameObject newetincelle;
        if (isBonneCroix)
        {
            newetincelle = Instantiate(prefabetincelle1) as GameObject;
            newetincelle.transform.parent = GameObject.Find("1 - Etincelles").transform;
            newetincelle.GetComponent<TestCroix>().isBonneCroix = true;
        }
        else
        {
            newetincelle = Instantiate(prefabetincelle2) as GameObject;
            newetincelle.transform.parent = GameObject.Find("1 - Etincelles").transform;
            newetincelle.GetComponent<TestCroix>().isBonneCroix = false;
        }

        Vector3 pointImage = new Vector3(xHasard, yHasard, -1.0f);

        newetincelle.transform.position = pointImage;

        if (tauxHasard >= 0.0f && tauxHasard <= tauxCroixFixe)
        {

            creerCroixFixe(newetincelle);
        }
        if (tauxHasard > tauxCroixFixe && tauxHasard<=tauxCroixRotation)
        {
            creerCroixEnRotation(newetincelle);
        }
        if (tauxHasard > tauxCroixRotation && tauxHasard<=tauxCroixMouvement)
        {
            creerCroixMouvement(newetincelle);
        }
        if (tauxHasard > tauxCroixMouvement)
        {
            creerCroixMouvementRotation(newetincelle);
        }
    }
}
