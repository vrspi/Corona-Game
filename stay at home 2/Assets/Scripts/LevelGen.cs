using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelGen : MonoBehaviour
{
    public TextMeshProUGUI sp;
    public TextMeshProUGUI level;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        sp.text = PlayerPrefs.GetInt("sp").ToString();
        level.text = PlayerPrefs.GetInt("Level").ToString();
        if(PlayerPrefs.GetInt("ft") == 1)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);


        }

    }

  
    public void startgame()
    {
        PlayerPrefs.SetInt("mawta", 0);

        SceneManager.LoadScene(1);

        PlayerPrefs.SetInt("i", 0);

    }
    public void accept()
    {
        PlayerPrefs.SetInt("ft",1);
        PlayerPrefs.SetInt("Level", 1);
        level.text = PlayerPrefs.GetInt("Level").ToString();
        panel.SetActive(false);


    }
}
