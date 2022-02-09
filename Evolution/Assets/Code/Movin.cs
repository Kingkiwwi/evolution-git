using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using TMPro;



public class Movin : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform spot;
    private Vector3 destination = new Vector3(0,0,0);
    private Vector3 destinationToo = Vector3.zero;


    public float energy;
    //timer stuffsa
    private float timer = 0;
    private float timerCheck = 0;

    public float TimeTillSpwn = 5f;
    public float pos;

    public float food;
    public GameObject agent1;

    //for more clones
    private float corner1;
    private float pos1;
    public bool live;

    //how many mans counter
    public float people;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        people = GameObject.FindGameObjectsWithTag("Player").Length;
         food = 0;
        population();
    }

       // Update is called once per frame
    void Update()
    {
         if (energy >= 3){
            randoSpot();
        }      
        if (energy <= 2){
            spawn();
        }   
        timer += Time.deltaTime;
        if (timer >= TimeTillSpwn && energy > 0)
        {
            timer = 0;
            moving();
            energy--;
                
        }
        if (energy == 0){
            parent();
        }
        
        if (live == true){
            reset();
        }

         people = GameObject.FindGameObjectsWithTag("Player").Length;
         population();
       
    }

     void randoSpot(){
        var destination = new Vector3(Random.Range(-11f,11f), 0.5f, Random.Range(-11f,11f));
        if (energy <= 3){
            spawn();
        }        
        spot.position = destination;
        
    }

    void moving(){
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(spot.position);
    }

    void spawn () 
    {
        var corner = Random.value;
        pos = Random.Range(-11.5f,11.5f);
        

            if (corner >= .75){
           var destination = new Vector3(11f, 0.5f, pos);
           spot.position = destination;
               
            } 
             if (corner < .75 && corner >= .5){
           var destination = new Vector3(-11F, 0.5f, pos);    
           spot.position = destination;    
           
            } 
             if (corner < .5 && corner >= .25){
          var  destination = new Vector3(pos, 0.5f, 11f);    
            spot.position = destination; 
              

            } 
             if (corner < .25){
             var destination = new Vector3(pos, 0.5f, -11f);    
             spot.position = destination;    
             
        }

         
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("I hit stuff");
        if(other.gameObject.CompareTag ("food")) {
            food = food + 1;
            other.gameObject.SetActive (false);
        }
    }

    void parent(){ 
       timerCheck += Time.deltaTime;
       if (timerCheck >= 8 && live == false)
        {
            //if no food
          if (food == 0){
                people = people - 1;
                population();
                agent1.SetActive(false);
            }
        if (food == 1){
             live = true;    
             food = 0;      
            }
            //mucho food
         if (food >= 2){
             live = true;
             egg();    
             reset();  
             food = 0;      
            }
        }
    }

    void egg () 
    {
        //clones the agent
          corner1 = Random.value;
          people = people + 1;
          pos1 = Random.Range(-11.5f,11.5f);

            if (corner1 >= .75){
            Instantiate(agent, new Vector3(11f, 0.5f, pos1), Quaternion.identity);  
            } 
             if (corner1 < .75 && corner1 >= .5){
            Instantiate(agent, new Vector3(-11F, 0.5f, pos1), Quaternion.identity);  
            } 
             if (corner1 < .5 && corner1 >= .25){
            Instantiate(agent, new Vector3(pos1, 0.5f, 11f), Quaternion.identity);    
            } 
             if (corner1 > .25){
            Instantiate(agent, new Vector3(pos1, 0.5f, -11f), Quaternion.identity);    
            }
    }    

    void reset()
    {
        live = false;
        energy = 4;
    }
    void population()
    {
        countText.text = "population: " + people.ToString();
    }

}
