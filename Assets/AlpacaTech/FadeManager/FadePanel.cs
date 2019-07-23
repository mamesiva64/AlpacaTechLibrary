using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FadePanel : MonoBehaviour
{
    [SerializeField] private bool fadeInOnAwake = true;
    [SerializeField] private float fadeTime = 0.5f;
    public AnimationCurve fadeCurve;
//    private Image image;
    private RawImage image;
    private static FadePanel Instance;

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        Instance = this;
        image = GetComponent<RawImage>();

        this.gameObject.SetActive(true);
        if(fadeInOnAwake)
        {
            FadeIn(fadeTime);
        }
    }

    /// <summary>
    /// 色設定
    /// </summary>
    /// <param name="color"></param>
    public static void SetColor(Color color)
    {
        Instance.image.color = color;
    }

    /// <summary>
    /// シーン切り替え
    /// </summary>
    /// <param name="time"></param>
    /// <param name="scene"></param>
    public static void LoadScene(string scene, float time)
    {
        Instance.RunFade(true, time, scene);
    }

    /// <summary>
    /// Fades the out.
    /// </summary>
    /// <param name="time">Time.</param>
    public static void FadeOut(float time)
    {
        Instance.RunFade(true, time);
    }

    /// <summary>
    /// Fades the in.
    /// </summary>
    /// <param name="time">Time.</param>
    public static void FadeIn(float time)
    {
        Instance.RunFade(false, time);
    }

    /// <summary>
    /// Ises the fadre.
    /// </summary>
    /// <returns><c>true</c>, if fadre was ised, <c>false</c> otherwise.</returns>
    public static bool IsFadre()
    {
        return Instance.isFade;
    }


    /// <summary>
    /// The is fade.
    /// </summary>
    private bool isFade = false;

    /// <summary>
    /// Runs the fade.
    /// </summary>
    /// <param name="fadeout">If set to <c>true</c> fadeout.</param>
    /// <param name="time">Time.</param>
    /// <param name="scene">Scene.</param>
    private void RunFade(bool fadeout, float time, string scene = "")
    {
        if (!isFade)
        {
            isFade = true;
            StartCoroutine(coFade(fadeout, time, scene));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="fadeOut"></param>
    /// <param name="time"></param>
    /// <param name="scene"></param>
    /// <returns></returns>
    private IEnumerator coFade(bool fadeOut,float time,string scene)
    {
        if(fadeOut)
        {
            //  ブラックアウト
            var endColor = image.color;
            endColor.a = 1;

            var beginColor = image.color;
            beginColor.a = 0;

            image.color = beginColor;
            image.DOColor(endColor,time);
            image.enabled = true;
            yield return new WaitForSeconds(time);
            if(scene.Length!=0)
            {
                SceneManager.LoadScene(scene);
            }
        }
        else
        {
            //  ブラックイン
            var endColor = image.color;
            endColor.a = 0;

            var beginColor = image.color;
            beginColor.a = 1;

            image.enabled = true;
            image.color = beginColor;
            image.DOColor(endColor, time);
            yield return new WaitForSeconds(time);
            image.enabled = false;
        }
        isFade = false;
        yield break;
    }

}
