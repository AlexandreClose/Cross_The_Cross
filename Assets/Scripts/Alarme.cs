using UnityEngine;
using System.Collections;

public class Alarme : SingletonGeneric<Alarme> {

    public float longueurCycleAlarme;
    public Color blanche = Color.white;
    public Color rouge = new Color(200, 0, 0);
    private Color couleurIntermediaire;
    private bool blancVersRouge;
    private float tempsDuCycle;
    public float perteBatterieParSeconde;
    public float baisseDeBatterie;

	// Use this for initialization
	void Start () {
        gameObject.name = "Alarme";
        blancVersRouge = true;
        StartCoroutine("perteBatterie");
        light.color = blanche;
        tempsDuCycle = 0.0f;
        GameObject.Find("Musique_alarme").GetComponent<AudioSource>().Play();
        GameObject.Find("Tableau").GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        bool debutJeu = CoordonneeSourisDansRepereMonde.Instance.debutJeu;

        if (debutJeu)
        {
            bool doigtSurEcran = CoordonneeSourisDansRepereMonde.Instance.doigtSurEcran;
            if (!doigtSurEcran)
            {
                tempsDuCycle += Time.deltaTime;
                float ratioTempsCycle = (float)(tempsDuCycle / longueurCycleAlarme);
                Debug.Log(ratioTempsCycle);
                if (ratioTempsCycle >= 1.0f)
                {
                    tempsDuCycle = 0.0f;
                    ratioTempsCycle = 0.0f;
                    if (blancVersRouge)
                    {
                        blancVersRouge = false;
                    }
                    else
                    {
                        blancVersRouge = true;
                    }
                }
                if (blancVersRouge)
                {
                    colorblancVersRouge(ratioTempsCycle);
                }
                else
                {
                    colorRougeVersBlanche(ratioTempsCycle);
                }
            }
            else
            {
                Destroy(gameObject);
                GameObject.Find("Musique_alarme").GetComponent<AudioSource>().Stop();
                GameObject.Find("Tableau").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    IEnumerator perteBatterie()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroixFaites -= baisseDeBatterie;
        StartCoroutine("perteBatterie");
    }

    private void colorblancVersRouge(float ratio)
    {

        couleurIntermediaire = Color.Lerp(blanche, rouge, ratio);
        light.color = couleurIntermediaire;
    }
    private void colorRougeVersBlanche(float ratio)
    {
        couleurIntermediaire = Color.Lerp(rouge, blanche, ratio);
        light.color = couleurIntermediaire;
    }

}
