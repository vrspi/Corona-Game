using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapdetect : MonoBehaviour
{
    private Vector3 target;
    private bool AtHome = false;
    public Vector3 FirstTr;
    private bool Clicked = false;
    public int x = 0;
    public float speed = 1.0f;
    public ParticleSystem pa;
  void Start()
    {
        pa.Stop();
        FirstTr = transform.position;
        
    }
    void FixedUpdate()
    {
        if (Clicked)
        {
          float step = speed * Time.deltaTime; // calculate distance to move
            if (x == 0)
            {
        target = new Vector3(0.2f, 0.6f, FirstTr.z);
                x++;
            }

        if (transform.position == target)
        {
            
            target = FirstTr;
            if (transform.position == target)
            {
                AtHome = true;
            }
            if (AtHome)
            {
                Destroy(this.gameObject);

            }  if (transform.position == target)
        {
            AtHome = true;
        }
        if (AtHome)
        {
                    SoundManagerScript.PlaySound("safe");
                    Destroy(this.gameObject);

        }
        }
        
        transform.LookAt(target);

            transform.position = Vector3.MoveTowards(transform.position, target, step);

        }

    }
    void OnMouseDown()
    {
        gameObject.tag = "Finish";
        Clicked = true;
        pa.Play();
       if(GetComponent<BoxCollider>().enabled == true)
        {
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
        PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
        }        GetComponent<BoxCollider>().enabled = false;

             GetComponent<movement>().enabled = false;
        SoundManagerScript.PlaySound("byby");
    }
}
