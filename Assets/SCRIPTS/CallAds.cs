using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallAds : MonoBehaviour
{

    public float AdsTimer = 10f;
    private float Timer = 0f;

    public CameraDrag cameraDrag;
    
   

    public Text adsTimerText;
    public GameObject adsTimerPanel;

    private bool isDelay = false;

    private bool isBoosted = false;

    

    
    public void AdsButton()
    {
         if (isBoosted ==false)
        AdsProvider.ShowAdsButton(1);
    }

     public void AddReward()

    {   
    
       
    }
        
    

    private void Update() 
    {
        Timer += Time.unscaledDeltaTime;

       

        if (Timer >= AdsTimer - 3)
        {  
            //Time.timeScale = 0f;
            //wallImage.SetActive(true);
            //adsTimerPanel.SetActive(true);
            //adsTimerText.text = $"До показа рекламы: {AdsTimer - Timer} сек.";
            if (isDelay == false)
            {
                 StartCoroutine("AdsTextDelay");
            }
             
             if (Timer>= AdsTimer)
            {
        
                Timer = 0f;
            }
        }
        
       
    }

    IEnumerator AdsTextDelay()
    {
        Time.timeScale = 0f;
        isDelay = true;
        cameraDrag.enabled = false;
        
        
        adsTimerPanel.SetActive(true);
        adsTimerText.text = "До показа рекламы: 3 сек.";
        yield return new WaitForSecondsRealtime(1f);
        adsTimerText.text = "До показа рекламы: 2 сек.";
        yield return new WaitForSecondsRealtime(1f);
        adsTimerText.text = "До показа рекламы: 1 сек.";
        yield return new WaitForSecondsRealtime(1f);
         AdsProvider.ShowFullScreenAds();
         adsTimerPanel.SetActive(false);
         isDelay = false;
         cameraDrag.enabled = true;
         
         
         
         Time.timeScale = 1f;
         

    }

    

   

}
