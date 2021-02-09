using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public NavMeshAgent agent;
    private Vector3 target;
    private bool isIn=false;
    public float speed = 1.0f;
    public static int ID = 1;
    public List<Vector3> FirstTr = new List<Vector3>();
   
    void Start()
    {
        FirstTr.Add(transform.position);
        float step = speed * Time.deltaTime; // calculate distance to move
        target = new Vector3(0.2f, 0.6f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        if(transform.position == target)
        {
            FirstTr.Add(transform.position);

            isIn = true;
        }
    }

    void FixedUpdate()
    {// if(GameObject.Find("character (Clone)/metarig.002"))
     //    {
     //        GameObject.Find("character (Clone)/metarig.002").GetComponent<Transform>().rotation = Quaternion.Euler(-90f, 0f, 0f);
     //    }
        if(transform.position == target)
        {
            isIn = true;
        }
        if (isIn)
        {
            float x = Random.Range(-1.5f, 1.87f);
            float z = Random.Range(-5.69f, 25f);
            target = new Vector3(x, 0.6f, z);
            isIn = false;

        }
        transform.LookAt(target);
        //if(transform.rotation.z == 0 && transform.rotation.y == 0)
        //transform.position -= new Vector3(0.03f, 0f, 0f);
        //else
        //{
        float step = speed * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards(transform.position, target, step);


        //}
    }

}
