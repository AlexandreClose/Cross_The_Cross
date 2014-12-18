using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCroix : MonoBehaviour
{

    private Vector3 avantDernierPoint, dernierPoint ;
    public bool isBonneCroix;
    public float baisseDeBatterie;
    public float angleLimite;
    public GameObject prefabetincelle1;
    public Light prefabPointLight;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> mousePos = CoordonneeSourisDansRepereMonde.Instance.mousePos;
        
        if (mousePos.Count>=2)
        {
            avantDernierPoint = mousePos[mousePos.Count - 2];
            dernierPoint = mousePos[mousePos.Count - 1];
            float distance = Vector3.Distance(avantDernierPoint, dernierPoint);

            if (distance > 0.000001f)
            {
                Ray droiteCroix = new Ray(avantDernierPoint, dernierPoint - avantDernierPoint);
                Vector3 dir = dernierPoint - avantDernierPoint;
                dir.z = 0.0f;

                RaycastHit hit;


                if (collider.Raycast(droiteCroix, out hit, 100.0F))
                {
                    Debug.Log("test");
                    Vector3 pointCollision = hit.point;

                    float minXuser = Mathf.Min(new float[] { avantDernierPoint.x, dernierPoint.x });
                    float maxXuser = Mathf.Max(new float[] { avantDernierPoint.x, dernierPoint.x });
                    float minYuser = Mathf.Min(new float[] { avantDernierPoint.y, dernierPoint.y });
                    float maxYuser = Mathf.Max(new float[] { avantDernierPoint.y, dernierPoint.y });
                    if (pointCollision.x > minXuser && pointCollision.x < maxXuser && pointCollision.y > minYuser && pointCollision.y < maxYuser)
                    {
                        Vector3 directionPerpEtincelle = new Vector3(Mathf.Cos(transform.rotation.eulerAngles.z * (Mathf.PI / 180.0f)), -Mathf.Sin(transform.rotation.eulerAngles.z * (Mathf.PI / 180.0f)), 0.0f);

                        if (Vector3.Angle(dernierPoint - avantDernierPoint, directionPerpEtincelle) < angleLimite || Vector3.Angle(dernierPoint - avantDernierPoint, directionPerpEtincelle) > 180.0f - angleLimite)
                        {
                            float angleX = Vector3.Angle(dir, new Vector3(1.0f, 0.0f, 0.0f));
                            GameObject newetincelle = Instantiate(prefabetincelle1) as GameObject;
                            newetincelle.GetComponent<TestCroix>().enabled = false;
                            newetincelle.transform.position = transform.position;
                            newetincelle.GetComponent<MoveRandomDir>().isEnMouvement = false;
                            gameObject.GetComponent<MoveRandomDir>().isEnMouvement = false;

                            newetincelle.GetComponent<RotationCroix>().isRotational = false;
                            gameObject.GetComponent<RotationCroix>().isRotational = false;

                            if (dir.y > 0)
                                newetincelle.transform.rotation = Quaternion.AngleAxis(angleX - 90.0f, new Vector3(0.0f, 0.0f, 1.0f)) * Quaternion.AngleAxis(180.0f, new Vector3(0.0f, 1.0f, 0.0f));
                            else
                                newetincelle.transform.rotation = Quaternion.AngleAxis(90.0f - angleX, new Vector3(0.0f, 0.0f, 1.0f)) * Quaternion.AngleAxis(180.0f, new Vector3(0.0f, 1.0f, 0.0f));
                            


                            if (isBonneCroix)
                            {
                                Debug.Log("tagadatsoitsoin");
                                GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroixFaites += 1.0f;

                                Light newSpotLight = Instantiate(prefabPointLight) as Light;
                                newSpotLight.transform.parent = GameObject.Find("0 - Lumieres").transform;
                                newSpotLight.spotAngle = (GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroixFaites / GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroix100) * 120;
                                newSpotLight.transform.position = newetincelle.transform.position;
                                newSpotLight.transform.position = new Vector3(newSpotLight.transform.position.x, newSpotLight.transform.position.y, -5.0f);
                                GestionMusique.Instance.sonBonneCroix();
                                Destroy(newSpotLight, 1.0f);
                                Destroy(this);
                            }
                            else
                            {
                                GameObject.Find("Batterie").GetComponent<RemplissageBatterie>().nombreCroixFaites -= baisseDeBatterie;
                                GestionMusique.Instance.sonMauvaiseCroix();
                                Destroy(this);
                            }


                            Destroy(gameObject, 1.0f);
                            Destroy(newetincelle, 1.0f);
                        }
                    }
                }
            }
            
            
        }
    }

    private List<Vector3> recupereTableauPointsCollision(Vector3 pointDepart, Vector3 pointArrive)
    {
        List<Vector3> tableauPointsCollision = new List<Vector3>();

        Vector3 vecteurDirecteur = pointArrive - pointDepart;
        vecteurDirecteur.z = 0.0f;
        bool g = true;
        while(g){
        Ray droiteCroix = new Ray(pointDepart, vecteurDirecteur);
        RaycastHit hit;
        collider.Raycast(droiteCroix, out hit, 100.0F);
        tableauPointsCollision.Add(hit.point);
        pointDepart = hit.point;
        }

        return tableauPointsCollision;
    }
}


