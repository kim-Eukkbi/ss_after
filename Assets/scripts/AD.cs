using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AD : MonoBehaviour
{
    BannerView bannerView;
    private InterstitialAd screenAd;
    public void Start()
    {
        #if UNITY_ANDROID
            string appid = "ca-app-pub-7937364463261467~3963157556";
        #else
            string appid = "unexpected_platform";
        #endif

        MobileAds.Initialize((initStatue) => { RequestBanner(); });
        InitAd();
        Invoke("Show", 15f);
    }
  
    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitld = "ca-app-pub-7937364463261467/4476278976";
        #else
            string appid = "unexpected_platform";
        #endif

        this.bannerView = new BannerView(adUnitld, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().AddTestDevice("86AA1E83FBB52F2B662F206FE0C08735").Build();

        this.bannerView.LoadAd(request);
    }

    private void InitAd()
    {
        screenAd = new InterstitialAd("ca-app-pub-7937364463261467/3361813322");

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
        screenAd.OnAdClosed += (sender, e) => Debug.Log("광고 닫힘");
        screenAd.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
    }

    public void Show()
    {
        StartCoroutine("ShowScrrenAd");
    }
    private IEnumerator ShowScrrenAd()
    {
        while(!screenAd.IsLoaded())
        {
            yield return null;
        }

        screenAd.Show();
    }
}