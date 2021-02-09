using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI cont;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutineA());
        cont.enabled = true;
    }

    
    IEnumerator coroutineA()
    {
        int i = 3;
      
        while (i >= 1)
        {  cont.text = i.ToString();
        i--;
            yield return new WaitForSeconds(1.0f);

        }
        cont.fontSize = 900;
            cont.text = "GOO!!";
        SoundManagerScript.PlaySound("go");
        yield return new WaitForSeconds(1.0f);

            cont.enabled = false;

        
    }
}
