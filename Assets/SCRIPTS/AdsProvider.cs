using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class AdsProvider : MonoBehaviour
{
    
   
    public static void ShowAdsButton(int ID)
    {
        YandexGame.RewVideoShow(ID);
    }
    
    public static void ShowFullScreenAds()
    {
        YandexGame.FullscreenShow();
    }
}
