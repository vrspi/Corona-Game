using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMv1 : MonoBehaviour
{
    
    public Rigidbody rb;
    [SerializeField] private float vitesse = 3f;
    private Vector2 LastmousePos;

    // Start is called before the first frame update

    void Update()
         
    {
        float moveX = Input.GetAxis("Vertical");
        transform.position += new Vector3(0f, 0f, moveX * 6 * Time.deltaTime);
        Touch touch = Input.GetTouch(0);
        Vector2 deltapos = Vector2.zero;
        if (Input.touchCount > 0)
        {
           
            Vector2 Currentmousepos = touch.position;

            if (LastmousePos == Vector2.zero)
            {
                LastmousePos = Currentmousepos;

            }
            deltapos = Currentmousepos - LastmousePos;
            LastmousePos = Currentmousepos;

            Vector3 force = new Vector3(0f, 0, deltapos.y) * vitesse;
                           
                             rb.AddForce(force);

                              
          
        }
       

        if (touch.phase == TouchPhase.Ended)
            {
                LastmousePos = Vector2.zero;
            }

        if (transform.position.z > 11.6f)
        {
            Vector3 force = new Vector3(0f, 0, -5) * vitesse;

            rb.AddForce(force);
        }
        if (transform.position.z < -7.62f)
        {
            Vector3 force = new Vector3(0f, 0, 5) * vitesse;

            rb.AddForce(force);
        }
    }
            



    }

