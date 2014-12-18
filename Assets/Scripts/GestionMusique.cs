using UnityEngine;
using System.Collections;


public class GestionMusique : SingletonGeneric<GestionMusique>
{
    public AudioClip bonneCroix;
    public AudioClip mauvaiseCroix;

    public void sonBonneCroix()
    {
        MakeSound(bonneCroix);
    }

    public void sonMauvaiseCroix()
    {
        MakeSound(mauvaiseCroix);
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
