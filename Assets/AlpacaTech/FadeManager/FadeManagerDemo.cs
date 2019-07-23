using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManagerDemo : MonoBehaviour
{
    public void OnFadeOut()
    {
        FadePanel.FadeOut(1);
    }

    public void OnFadeIn()
    {
        FadePanel.FadeIn(1);
    }

}
