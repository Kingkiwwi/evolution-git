using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manspwn : MonoBehaviour
{

	public int resolution;
    public Transform agent;
   
    public float corner;
    public float pos;
    


    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawn () 
    {
        //where agent spawns


        //clones the agent
         for (int i = 0; i < resolution; i++)
        {
          corner = Random.value;
          pos = Random.Range(-12,12);

            if (corner >= .75){
            Instantiate(agent, new Vector3(11f, 0.5f, pos), Quaternion.identity);    
            } 
             if (corner < .75 && corner >= .5){
            Instantiate(agent, new Vector3(-11F, 0.5f, pos), Quaternion.identity);    
            } 
             if (corner < .5 && corner >= .25){
            Instantiate(agent, new Vector3(pos, 0.5f, 11f), Quaternion.identity);    
            } 
             if (corner < .25){
            Instantiate(agent, new Vector3(pos, 0.5f, -11f), Quaternion.identity);    
            }
        }
    }
}

