using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeDemo : MonoBehaviour
{
    [SerializeField] float time = 1f;
    [SerializeField] float power = 0.1f;
    [SerializeField] bool is3D = true;

    public void Demo()
    {
        AlpacaTech.CameraShake.Shake(time, power, is3D);
    }


}
