using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    public bool isEscapeToExit;
    GameObject panelCarabermain;


    // Start is called before the first frame update
    void Start()
    {
        panelCarabermain = GameObject.Find("PanelCarabermain");
        panelCarabermain.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                KembaliKeMenu();
            }
        }
    }
   
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void BtnPlayClicked()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void BtnMulaimainClicked()
    {
        panelCarabermain.SetActive(false);
    }

}
