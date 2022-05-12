using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpGoal : MonoBehaviour
{
    public Text counter;
    public GameObject[] pickups;



    public int count;

    // Start is called before the first frame update
    void Start()
    {
        pickups = GameObject.FindGameObjectsWithTag("Pick Up");

        count = pickups.Length;
        counter.text = "Goal: " + count;
    }

    // Update is called once per frame
    void Update()
    {



    }
}

