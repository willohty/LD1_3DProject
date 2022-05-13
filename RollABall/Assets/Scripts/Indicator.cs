using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Text timeChangeIndicator;
    public bool showTimeChangeIndicator = false;

    public Text boostIndicator;
    public bool showBoostIndicator = false;

    private int showTimeChangeForSeconds = 3;
    private float showBoostForSeconds = 1.5f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (showTimeChangeIndicator)
        {
            timeChangeIndicator.text = "-5 seconds";
        }
        else if (!showTimeChangeIndicator)
        {
            timeChangeIndicator.text = "";
        }

        if (showBoostIndicator)
        {
            boostIndicator.text = "you're fast!";
        }
        else if (!showBoostIndicator)
        {
            boostIndicator.text = "";
        }
    }

    public void showTimeChangeToPlayer()
    {
        showTimeChangeIndicator = true;
        StartCoroutine(TimeShowingTimeIndicator());
    }

    public void showBoostingToPlayer()
    {
        showBoostIndicator = true;
        StartCoroutine(TimeShowingBoostIndicator());
    }


    IEnumerator TimeShowingTimeIndicator()
    {
        yield return new WaitForSeconds(showTimeChangeForSeconds);
        showTimeChangeIndicator = false;
    }

    IEnumerator TimeShowingBoostIndicator()
    {
        yield return new WaitForSeconds(showBoostForSeconds);
        showBoostIndicator = false;
    }

}
