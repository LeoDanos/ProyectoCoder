using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPoints : MonoBehaviour
{
    public GameObject checkLabel1;
    public GameObject checkLabel2;
    public GameObject checkLabel3;

    public AudioSource checkSound;
    public AudioSource finishSound;

    private bool checkPoint1 = false;
    private bool checkPoint1Enter = false;

    private bool checkPoint2 = false;
    private bool checkPoint2Enter = false;

    private bool checkPoint3 = false;
    private bool checkPoint3Enter = false;

    private bool checkEnd = false;

    public GameObject gameOverMenu;
    public GameObject gameOverTxt;
    public GameObject winTxt;
    
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if ((col.transform.gameObject.name == "CP1") && !checkPoint1 && checkPoint1Enter)
            {          
                checkPoint1 = true;
                checkLabel1.GetComponent<Image>().color = Color.white;
                checkSound.Play();
                Debug.Log("Checkpoint 1");       
            }   
        
        if ((col.transform.gameObject.name == "CP2") && !checkPoint2 && checkPoint2Enter && checkPoint1)
            {          
                checkPoint2 = true;
                checkLabel2.GetComponent<Image>().color = Color.white;
                checkSound.Play();
                Debug.Log("Checkpoint 2");        
            }   

        if ((col.transform.gameObject.name == "CP3") && !checkPoint3 && checkPoint3Enter && checkPoint2)
            {          
                checkPoint3 = true;
                checkLabel3.GetComponent<Image>().color = Color.white;
                checkSound.Play();
                Debug.Log("Checkpoint 3");        
            }                    
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.transform.gameObject.name == "CP1E") && !checkPoint1)
            {          
                checkPoint1Enter = true;
                Debug.Log("Checkpoint 1 Enter");       
            }   
        
        if ((col.transform.gameObject.name == "CP2E") && !checkPoint2 && checkPoint1)
            {          
                checkPoint2Enter = true;
                Debug.Log("Checkpoint 2 Enter");        
            }   

        if ((col.transform.gameObject.name == "CP3E") && !checkPoint3 && checkPoint2)
            {          
                checkPoint3Enter = true;
                Debug.Log("Checkpoint 3 Enter");        
            }     
        
        
        if ((col.transform.gameObject.name == "End") && !checkEnd && checkPoint3)
        {          
                checkEnd = true;
                finishSound.Play();
                Time.timeScale = 0;
                gameOverTxt.SetActive(false);
                winTxt.SetActive(true);
                gameOverMenu.SetActive(true);
                Debug.Log("WIN");        
        }    
    }
}
