using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoremanager : MonoBehaviour
{
    private Vector3 target;
    private bool AtHome = false;
    public Vector3 FirstTr;
    private bool Clicked = false;
    public int x = 0;
    public float speed = 1.0f;
    public TextMeshProUGUI sp;
    public TextMeshProUGUI death;
    private int pd;
    private int ps;

    //private int pd = PlayerPrefs.GetInt("Level") * 5;

    // Start is called before the first frame update
    void Start()
    {
        FirstTr = transform.position;

        ps = PlayerPrefs.GetInt("Level") * 10;
        pd = PlayerPrefs.GetInt("Level") * 5;
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("mawta", 0);

    }

    // Update is called once per frame
    void Update()
    {
        sp.text = PlayerPrefs.GetInt("score") + "/" + ps;
        death.text = PlayerPrefs.GetInt("mawta") + "/" + pd;
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.tag == "Player")
                {
                    gameObject.tag = "Finish";
                    Clicked = true;
                   
                    if (GetComponent<BoxCollider>().enabled == true)
                    {
                        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
                        PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
                    } GetComponent<BoxCollider>().enabled = false;
                    GetComponent<movement>().enabled = false;
                    SoundManagerScript.PlaySound("byby");
                }


            }
        }

        if (PlayerPrefs.GetInt("score") == ps)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
            PlayerPrefs.SetInt("mawta", 0);

            SceneManager.LoadScene(2);


        }
        if (PlayerPrefs.GetInt("mawta") == pd)
        {
            PlayerPrefs.SetInt("mawta", 0);
            PlayerPrefs.SetInt("levelpassed", 1);

            SceneManager.LoadScene(2);


            SceneManager.LoadScene(2);


        }
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

                }
                if (transform.position == target)
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

    }


