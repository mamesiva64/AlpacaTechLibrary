using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualPad : MonoBehaviour {

    static public VirtualPad instance;
    public Image imageHat;
    public Image imageBase;
    Vector3 startPosition = Vector3.zero;

    public bool fix = false;
    public float inputScope = 100.0f;

    public Vector3 axis = Vector3.zero;
    public bool press = false;

	// Use this for initialization
	void Start ()
    {
        instance = this;
        if(!fix)
        {
            imageBase.enabled = false;
            imageHat.enabled = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                return;
            }
//          if (EventSystem.current.IsPointerOverGameObject())
//          {
//          return;
//          }
            var pos = Input.mousePosition;
            startPosition = pos;
            axis = Vector3.zero;

            imageBase.enabled = true;
            imageHat.enabled = true;

            imageHat.transform.position = pos;
            imageBase.transform.position = pos;

            press = true;
        }

        if (!press)
        {
            axis.x = Input.GetAxis("Horizontal");
            axis.y = Input.GetAxis("Vertical");
            return;
        }

        if (Input.GetMouseButton(0))
        {
            var pos = Input.mousePosition;
#if true
            //  Circle
            var delta = pos - startPosition;
            var len = delta.magnitude;
            len = Mathf.Min(len, inputScope);
            delta = delta.normalized* len;
            imageHat.transform.position = startPosition + delta;
            axis = delta / inputScope;
#else
            //  Rect
            pos.x = Mathf.Clamp(pos.x, startPosition.x - inputScope, startPosition.x + inputScope);
            pos.y = Mathf.Clamp(pos.y, startPosition.y - inputScope, startPosition.y + inputScope);

            imageHat.transform.position = pos;
            axis.x = (pos.x - startPosition.x)/inputScope;
            axis.y = (pos.y - startPosition.y)/inputScope;
#endif
        }

        if (Input.GetMouseButtonUp(0))
        {
            var pos = Input.mousePosition;
            press = false;
            axis = Vector3.zero;

            var p2 = new Vector2(pos.x, pos.y);


            imageHat.transform.position = startPosition;

            if(!fix)
            {
                imageBase.enabled = false;
                imageHat.enabled = false;
            }
        }

//      Debug.Log(axis.x.ToString() + "," + axis.y.ToString());
	}
}
