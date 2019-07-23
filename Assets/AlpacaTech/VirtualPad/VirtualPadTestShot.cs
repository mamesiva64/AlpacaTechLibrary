using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPadTestShot : MonoBehaviour {

    public float speed = 20;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
        var pos = this.gameObject.transform.position;
        pos.x += Time.deltaTime * speed;
        this.gameObject.transform.position = pos;

    }
}
