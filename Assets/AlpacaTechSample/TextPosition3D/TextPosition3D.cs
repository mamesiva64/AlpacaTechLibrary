using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextPosition3D : MonoBehaviour
{
    //  追跡位置
    public Vector3 offset = Vector3.zero;
    public Vector3 targetPosition;
    public Transform target;

    private RectTransform rectTransform;

    // Use this for initialization
    void Start ()
    {
        rectTransform = GetComponent<RectTransform>();
	}

    void Update()
    {
        if (target)
        {
            targetPosition = target.position;
        }

        var pos = targetPosition;
        pos += Camera.main.transform.rotation * offset;
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, pos);
    }

    private void OnValidate()
    {
        rectTransform = GetComponent<RectTransform>();
        Update();
    }
}
