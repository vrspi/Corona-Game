using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    private Vector3 target;
    public float speed = 6.0f;
    private GameObject CloseTarget;
    private List<GameObject> ListTar = new List<GameObject>();
    private float distance;
    public bool IsIt = false;
    // Start is called before the first frame update
    void Start()
    {

        GameObject Tar = GameObject.FindGameObjectWithTag("Player");
        distance = 100;
        target = Tar.transform.position;

    }
    // Update is called once per frame
    void Update()
    { if(Random.Range(1,1000)==3)
            SoundManagerScript.PlaySound("co");


        float step = speed * Time.deltaTime; // calculate distance to move

            ListTar.AddRange(GameObject.FindGameObjectsWithTag("Player"));
       
        foreach (var x in ListTar)
        {

            if (x != null && x.tag == "Player")
            {
                float newDist = Vector3.Distance(x.transform.position, transform.position);

                if (newDist <= distance)
                {
                    distance = newDist;
                    if(x.transform.position.x > -1.43f && x.transform.position.x < 1.93f)
                    {
                    target = new Vector3(x.transform.position.x, x.transform.position.y, x.transform.position.z);
                    IsIt = true;
                    }
                    else
                    {
                        IsIt = false;

                    }

                    ListTar.Clear();

                    break;
                }


            }
           
                if (!IsIt)
                {
                    float f = Random.Range(-1.5f, 1.87f);
                    float z = Random.Range(-5.69f, 25f);
                    target = new Vector3(f, 0.6f, z);
                    distance = Vector3.Distance(x.transform.position, target);
                }


            

        }
        //if (transform.position == target)
        //{
        //    if (!IsIt)
        //    {

        //        float x = Random.Range(-1.5f, 1.87f);
        //        float z = Random.Range(-5.69f, 25f);
        //        target = new Vector3(x, 0.6f, z);
        //        IsIt = false;
        //    }
        //}
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
          Destroy(collision.gameObject);
             distance = 1000;
            IsIt = false;

            PlayerPrefs.SetInt("mawta", PlayerPrefs.GetInt("mawta")+1);

        }
        //if(collision.gameObject.tag == "Corona")
        //{
        //    if (!IsIt)
        //    {

        //        float x = Random.Range(-1.5f, 1.87f);
        //        float z = Random.Range(-5.69f, 25f);
        //        target = new Vector3(x, 0.6f, z);
        //        IsIt = false;

        //        float step = speed * Time.deltaTime; // calculate distance to move
        //        transform.LookAt(target);
        //        transform.position = Vector3.MoveTowards(transform.position, target, step);

        //    }

        //}
    }
}

  

