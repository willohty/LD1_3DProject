using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Text indicator;
    public bool showIndicator = false;

    private int showForSeconds = 3;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (showIndicator)
        {
            indicator.text = "-5 seconds";
        }
        else if (!showIndicator)
        {
            indicator.text = "";
        }
    }

    public void addedToTimer()
    {
        showIndicator = true;
        StartCoroutine(IndicatorShowTimer());
    }


    IEnumerator IndicatorShowTimer()
    {
        yield return new WaitForSeconds(showForSeconds);
        showIndicator = false;
        print("indicator timer is out");
    }

}
