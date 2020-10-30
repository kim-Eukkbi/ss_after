using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AD : MonoBehaviour
{
    BannerView bannerView;

    public void Start()
    {
#if UNITY_ANDROID
        string appid = "ca-app-pub-7937364463261467~3963157556";
#elif UNITY_IPHONE
            string appid = "ca-app-pub-3940256099942544~1458002511";
#else
            string appid = "unexpected_platform";
#endif

        MobileAds.Initialize((initStatue) => { RequestBanner(); });
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitld = "ca-app-pub-7937364463261467/4476278976";
#elif UNITY_IPHONE
            string appid = "ca-app-pub-3940256099942544/2934735716";
#else
            string appid = "unexpected_platform";
#endif

        this.bannerView = new BannerView(adUnitld, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().AddTestDevice("86AA1E83FBB52F2B662F206FE0C08735").Build();

        this.bannerView.LoadAd(request);
    }
}