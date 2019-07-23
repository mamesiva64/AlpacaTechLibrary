using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualButton : MonoBehaviour {

    public bool rapid = false;
    public float scope = 50;

    public bool press = false;
    public bool down = false;
    public bool up = false;

    Image image;
    public Sprite spriteBase;
    public Sprite spritePressed;


    // Use this for initialization
    void Start () {

        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var pos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            var sub = pos - this.gameObject.transform.position;
            if(sub.magnitude<scope)
            {
                image.sprite = spritePressed;
                press = true;
            }


        }
        else
        if (Input.GetMouseButtonUp(0))
        {
            image.sprite = spriteBase;
            press = false;
        }

    }
}
