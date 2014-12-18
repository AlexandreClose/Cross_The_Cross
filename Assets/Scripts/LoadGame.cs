using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {

    public int levelEnCours;

	// Use this for initialization
	void Start () {
        levelEnCours = Application.loadedLevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadGame(int level)
    {
        Application.LoadLevel(level);
    }

    public void loadCurrentGame()
    {
        Application.LoadLevel(levelEnCours);
    }


}
