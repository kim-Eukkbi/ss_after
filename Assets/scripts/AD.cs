using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AD : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd screenAd;
    private RewardedAd rewardedAd;
    public void Start()
    {
    #if UNITY_ANDROID
        string appId = "ca-app-pub-7937364463261467~3963157556";
    #else
        string appId = "unexpected_platform";
    #endif

        MobileAds.Initialize((initStatue) => { 
            RequestBanner();
            //RequestReward();
        });
        //InitAd();
        //Invoke("ShowScnAd", 15f);
    }

    // ---------------------------------------배너 광고
    private void RequestBanner()
    {
    #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7937364463261467/4476278976";
    #else
        string appid = "unexpected_platform";
    #endif

        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().AddTestDevice("86AA1E83FBB52F2B662F206FE0C08735").Build();

        this.bannerView.LoadAd(request);
    }
    // ---------------------------------------배너 광고

    // ---------------------------------------리워드 광고
    public void RequestReward()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917"; // 테스트 리워드광고 ID
        #else
            string appid = "unexpected_platform";
        #endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().AddTestDevice("86AA1E83FBB52F2B662F206FE0C08735").Build();

        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("리워드 광고 로드됨");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        /*        Debug.Log(
                     "이 광고를 보고 이러한 보상을 얻었슴니다 : "
                         + amount.ToString() + " " + type);*/
        GameManager.instance.gameInfo.wisp += 30;
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.RequestReward();
    }

    public void ShowRewardAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
    // ---------------------------------------리워드 광고

    // ---------------------------------------전면 광고
    private void InitAd()
    {
        screenAd = new InterstitialAd("ca-app-pub-7937364463261467/3361813322");

        AdRequest request = new AdRequest.Builder().Build();

        screenAd.LoadAd(request);
        screenAd.OnAdClosed += (sender, e) => Debug.Log("광고 닫힘");
        screenAd.OnAdLoaded += (sender, e) => Debug.Log("광고가 로드됨");
    }

    public void ShowScnAd()
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
    // ---------------------------------------전면 광고
}