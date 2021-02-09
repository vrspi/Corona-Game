using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtManager : MonoBehaviour
{
    public TextMeshProUGUI texts;
    public TextMeshProUGUI levell, ps;
    // Start is called before the first frame update
    void Start()
    {
       
 ps.text = PlayerPrefs.GetInt("score").ToString();
        levell.text = PlayerPrefs.GetInt("Level").ToString();
        if (PlayerPrefs.GetInt("levelpassed") == 1)
        {
            texts.text = "Retry";
        }
        else
        {
            texts.text = "Next";

        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startgame(int i)
    {
        PlayerPrefs.SetInt("i", 0);
        PlayerPrefs.SetInt("levelpassed", 0);


        SceneManager.LoadScene(i);


    }
}
