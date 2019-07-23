using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualPadTest : MonoBehaviour {

    public GameObject shot;

    public VirtualPad pad;
    public VirtualButton buttonA;
    public VirtualButton buttonB;

    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position += pad.axis * Time.deltaTime * speed;

        if (buttonA.press)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
        }
	}
}
