using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelinfo : MonoBehaviour
{
    public GameObject InfoPanel;
    // Start is called before the first frame update
    void Start()
    {
        InfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnInfoClicked()
    {
        InfoPanel.SetActive(true);
    }

  
    public void BtnKembaliClicked()
    {
        InfoPanel.SetActive(false);
    }
}
