using UnityEngine;
using System.Collections;

public class MoveRandomDir : MonoBehaviour {

    public float speedX;
    public float speedY;
    public Vector3 randomDirection;
    public bool isEnMouvement;

	// Use this for initialization
	void Start () {
        randomDirection = RandomVect2DUnitCircle(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnMouvement)
        {
            transform.position += new Vector3(randomDirection.x * speedX, randomDirection.y * speedY, 0.0f);
        }    
    }

    public static Vector3 RandomVect2DUnitCircle(float zCircle)
    {
        Vector2 randomPointOnCircle = Random.insideUnitCircle;
        randomPointOnCircle.Normalize();
        return new Vector3(randomPointOnCircle.x,randomPointOnCircle.y,zCircle);
    }
}
