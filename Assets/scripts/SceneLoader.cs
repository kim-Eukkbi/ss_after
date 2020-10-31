using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    protected static SceneLoader instance;

    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SceneLoader>();

                if (obj != null)
                {
                    instance = obj;
                }

                else
                {
                    instance = Create();
                }
            }

            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    [SerializeField]
    private CanvasGroup sceneLoaderCanvasGroup;
    private AsyncOperation op;

    private string loadSceneName;

    public static SceneLoader Create()
    {
        var SceneLoaderPrefab = Resources.Load<SceneLoader>("SceneLoader");
        return Instantiate(SceneLoaderPrefab);
    }

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd; // 델리게이트 체인
        loadSceneName = sceneName;

        Load(sceneName);
    }

    private void Load(string sceneName)
    {
        op = SceneManager.LoadSceneAsync(sceneName);

        op.allowSceneActivation = false;

        Fade(true);
    }

    private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == loadSceneName)
        {
            Fade(false);
            SceneManager.sceneLoaded -= LoadSceneEnd; // 델리게이트 체인해체
        }
    }
    
    private void Fade(bool isFadeIn)
    {
        sceneLoaderCanvasGroup.DOFade(isFadeIn ? 1 : 0, 2f).OnComplete(() => {
            if (!isFadeIn) { gameObject.SetActive(false); }
            else op.allowSceneActivation = true;
        });
    }
}
