using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPosition3DTest : MonoBehaviour {

    [SerializeField] Canvas canvas;
    [SerializeField] GameObject prefab;

	// Use this for initialization
	void Start ()
    {
		
	}


    Vector3 mousePositionBack;
	
	// Update is called once per frame
	void Update ()
    {
        var ix = Input.GetAxis("Horizontal");
        var iy = Input.GetAxis("Vertical");

        this.transform.position += new Vector3(ix, iy, 0) * Time.deltaTime * 3.0f;
        if (Input.GetMouseButtonDown(0))
        {
            var obj = Instantiate(prefab, canvas.transform);
            var tp3 = obj.GetComponent<TextPosition3D>();
            tp3.targetPosition = this.gameObject.transform.position;
            Destroy(obj, 1f);
        }


        var mousePosition = Input.mousePosition;
        if(Input.GetMouseButton(1))
        {
            var sub = mousePositionBack - mousePosition;
            Camera.main.transform.position += sub * 0.1f;

        }


        mousePositionBack = mousePosition;
	}
}
