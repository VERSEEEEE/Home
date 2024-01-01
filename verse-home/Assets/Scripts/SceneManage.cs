using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.CompilerServices;
using TMPro;

public class SceneManage : MonoBehaviour
{
    public CanvasGroup Fade_img;
    public GameObject Loading;
    public TMP_Text Loading_text;   // �ۼ�Ʈ ǥ���� �ؽ�Ʈ
    float fadeDuration = 2;     // �����Ǵ� �ð�

    public static SceneManage Instance
    {
        get
        {
            return instance;
        }
    }
    private static SceneManage instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;  // �̺�Ʈ�� �߰�
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  // �̺�Ʈ���� ���� X
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Fade_img.DOFade(0, fadeDuration)
            .OnStart(() =>
            {
                Loading.SetActive(false);
            })
            .OnComplete(() =>
            {
                Fade_img.blocksRaycasts = false;
            });
    }

    public void ChangeScene(string sceneName)   // �ܺο��� ��ȯ�� �� �̸� �ޱ�
    {
        Fade_img.DOFade(1, fadeDuration)
            .OnStart(() =>
            {
                Fade_img.blocksRaycasts = true; // �Ʒ� ����ĳ��Ʈ ����
            })
            .OnComplete(() =>
            {
                // �ε� ȭ�� ���� Scene Load ����
                StartCoroutine("LoadScene", sceneName); // Scene Load �ڷ�ƾ ����
            });
    }

    IEnumerator LoadScene(string sceneName)
    {
        Loading.SetActive(true);    // �ε� ȭ���� ���
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; // �ۼ�Ʈ �����̿�

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true;  // Scene ��ȯ �غ� �Ϸ�
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            Loading_text.text = percentage.ToString("0") + "%"; // �ε� �ۼ�Ʈ ǥ��
        }
    }
}