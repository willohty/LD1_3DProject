using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;

    public void loadLevel1()
    {
        SceneManager.LoadScene("Rollaball-Level1");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("Rollaball-Level2");
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene("Rollaball-Level3");
    }
}
