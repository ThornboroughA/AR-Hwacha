using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool eng, info;
    public GameObject infoPanel, infoButton,
                        korText, engText;
    void Start()
    {
        eng = true;
        info = false;
        infoPanel.SetActive(info);
        infoButton.SetActive(true);
        
    }


    public void Info_X_Button() {
        info = !info;
        if (info) {
            infoButton.SetActive(false);
            infoPanel.SetActive(true);
            if (eng)
            {
                korText.SetActive(false);
                engText.SetActive(true);
                
            }
            else {
                engText.SetActive(false);
                korText.SetActive(true);
            }
        }
        else { 
            infoButton.SetActive(true);
            infoPanel.SetActive(false);
        }
    }
    public void Eng_Button() {
        if (!eng) {
            eng = true;
            korText.SetActive(false);
            engText.SetActive(true);
           
        }
    }
    public void Kor_Button() {
        if (eng) { 
            eng = false;
            engText.SetActive(false);
            korText.SetActive(true);
        }
        
    }
}
