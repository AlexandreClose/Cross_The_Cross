using UnityEngine;
using System.Collections;

public class AdaptResolution : MonoBehaviour
{

    public GameObject prefab;
    public Camera gameCamera;
    public GameObject tableau;
    public GameObject batterie;

    // Use this for initialization
    void Start()
    {

        float largeurCamera = Screen.width;
        float hauteurCamera = Screen.height;

        var height = gameCamera.orthographicSize * 2.0;
        var width = height * Screen.width / Screen.height;
        GameObject tableau = GameObject.Find("Tableau");
        tableau.transform.Rotate(new Vector3(0.0f,0.0f,-90.0f));
    
        GameObject bordHaut = Instantiate(prefab) as GameObject;
        bordHaut.transform.parent = GameObject.Find("2 - BordsEcran").transform;
        bordHaut.name = "Bord_Haut";
        Vector3 pointHaut = Camera.main.ScreenToWorldPoint(new Vector3(largeurCamera * 0.5f, hauteurCamera, 9.0f));
        bordHaut.transform.position = pointHaut;
        bordHaut.transform.Rotate(Vector3.forward, 90.0f);
        bordHaut.transform.localScale = new Vector3(0.1f, (float)width, 0.1f);

        GameObject bordBas = Instantiate(prefab) as GameObject;
        bordBas.transform.parent = GameObject.Find("2 - BordsEcran").transform;
        bordBas.name = "Bord_Bas";
        Vector3 pointBas = Camera.main.ScreenToWorldPoint(new Vector3(largeurCamera * 0.5f, 0.0f, 9.0f));
        bordBas.transform.position = pointBas;
        bordBas.transform.Rotate(Vector3.forward, 90.0f);
        bordBas.transform.localScale = new Vector3(0.1f, (float)width, 0.1f);

        GameObject bordGauche = Instantiate(prefab) as GameObject;
        bordGauche.name = "Bord_Gauche";
        bordGauche.transform.parent = GameObject.Find("2 - BordsEcran").transform;
        Vector3 pointGauche = Camera.main.ScreenToWorldPoint(new Vector3(largeurCamera*0.1f, hauteurCamera * 0.5f, 9.0f));
        bordGauche.transform.position = pointGauche;
        bordGauche.transform.localScale = new Vector3(0.1f, (float)height, 0.1f);

        GameObject bordDroit = Instantiate(prefab) as GameObject;
        bordDroit.transform.parent = GameObject.Find("2 - BordsEcran").transform;
        bordDroit.name = "Bord_Droit";
        Vector3 pointDroit = Camera.main.ScreenToWorldPoint(new Vector3(largeurCamera, hauteurCamera * 0.5f, 9.0f));
        bordDroit.transform.position = pointDroit;
        bordDroit.transform.localScale = new Vector3(0.1f, (float)height, 0.1f);


    }

    // Update is called once per frame
    void Update()
    {

    }
}
