using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumSpawner : MonoBehaviour
{
    public GameObject Characters;
    public GameObject Enemy;
    public Vector3[] Places;
    public int startSpawnTime = 5;
    public int spawnTime=5;
    private int numberCo = -1;


    // Use this for initialization
    void Start()
    {   
        InvokeRepeating("Spawn", startSpawnTime, spawnTime);
    }

   

    void Spawn()
    {
        for(int i =0; i <= PlayerPrefs.GetInt("Level"); i++)
        {
            int x = Random.Range(0, 8);
        if(x==0 || x==1 || x==2 || x == 3)
        {
            Instantiate(Characters,Places[x], Quaternion.Euler(0,90, 0));


        }
        else
        {
            Instantiate(Characters, Places[x], Quaternion.Euler(0, -90, 0));


        }
            
        }
        
        if (numberCo < PlayerPrefs.GetInt("Level"))
        {
            Instantiate(Enemy, Places[8], Quaternion.Euler(0, 0, 0));
            numberCo++;

        }


    }
}
