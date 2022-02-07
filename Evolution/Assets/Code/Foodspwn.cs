using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foodspwn : MonoBehaviour
{
    public GameObject Fruit;
    private float timer = 0;
    private float timeg = 0;
    public float amount = 0;
    public float TimeTillSpwn = 0.75f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimeTillSpwn && timeg <= amount)
        {
            timeg++;
            spwn();
            timer = 0;
                
                
        }
        
    }
    void spwn () {
            
        var destination = new Vector3(Random.Range(10.0f, -10.0f), 0.5f, Random.Range(10.0f, -10.0f));
        Instantiate(Fruit, destination, Quaternion.identity);
        timer = 0;

    }
}
   