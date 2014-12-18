using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RemplissageBatterie : SingletonGeneric<RemplissageBatterie> {

    public Sprite[] batteriesSprites;
    public float nombreCroix100;
    public float nombreCroixFaites;
    public bool enJeu;



	// Use this for initialization

    void Awake()
    {
        // load all frames in fruitsSprites array
        batteriesSprites = Resources.LoadAll<Sprite>("Batterie");
    } 
	void Start () {
        gameObject.GetComponent<Image>().sprite = batteriesSprites[0];
        nombreCroixFaites = 0.0f;
        enJeu = true;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("PourcentageBatterie").GetComponent<Text>().text = nombreCroixFaites / nombreCroix100 * 100 + " %";
        if (nombreCroixFaites / nombreCroix100 * 100 < -20.0f)
        {
            
            enJeu = false;
            GameObject.Find("8 - EcranJeu").GetComponent<Canvas>().enabled = false;
            GameObject.Find("7 - EcranPerdu").GetComponent<Canvas>().enabled = true;
            GameObject.Find("Tableau").GetComponent<SpriteRenderer>().enabled = false;
            GameObject[] tabObjets = GameObject.FindGameObjectsWithTag("etincelle");
            foreach (GameObject etincelle in tabObjets){
                Destroy(etincelle);
            }

            GameObject alarme = GameObject.Find("Alarme");
            Destroy(alarme);
            GameObject.Find("Musique_alarme").GetComponent<AudioSource>().Stop();
        }

        if (nombreCroixFaites < nombreCroix100 * 0.25f)
        {
            gameObject.GetComponent<Image>().sprite = batteriesSprites[0];
        }
        else if (nombreCroixFaites < nombreCroix100*0.5f)
        {
            gameObject.GetComponent<Image>().sprite = batteriesSprites[1];
        }
        else if (nombreCroixFaites < nombreCroix100 * 0.75f)
        {
            gameObject.GetComponent<Image>().sprite = batteriesSprites[2];
        }
        else if (nombreCroixFaites < nombreCroix100 )
        {
            gameObject.GetComponent<Image>().sprite = batteriesSprites[3];
        }
        else if (nombreCroixFaites == nombreCroix100)
        {
            gameObject.GetComponent<Image>().sprite = batteriesSprites[4];
        }
	}
}
