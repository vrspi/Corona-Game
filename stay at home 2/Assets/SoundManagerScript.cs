using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip byby, co, safe,go;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        byby = Resources.Load<AudioClip>("by");
        co = Resources.Load<AudioClip>("coro");
        safe = Resources.Load<AudioClip>("safe");
        audiosrc = GetComponent<AudioSource>();
        go = Resources.Load<AudioClip>("go");

    }

    // Update is called once per frame
    void Update()
    {


        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "byby":
                audiosrc.PlayOneShot(byby);
                break;
            case "co":
                audiosrc.PlayOneShot(co);
                break;
            case "safe":
                audiosrc.PlayOneShot(safe);
                break;
            case "go":
                audiosrc.PlayOneShot(go);
                break;
        }
    }


}
