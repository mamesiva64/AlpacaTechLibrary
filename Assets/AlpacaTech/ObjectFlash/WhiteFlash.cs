using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1F白く光る
/// </summary>
public class WhiteFlash : MonoBehaviour {

    public Material matWhite;
    Material matOriginal;
    public Renderer renderer;

    // Use this for initialization
    void Start()
    {
        if (!renderer)
        {
            renderer = GetComponent<Renderer>();
        }

        if (renderer)
        {
            matOriginal = renderer.material;
        }

    }

    int time = 0;
    public void setWhite()
    {
        time = 1;
        renderer.material = matWhite;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (time <= 0)
        {
            renderer.material = matOriginal;
        }
        else
        {

        }
        time--;
	}
}
