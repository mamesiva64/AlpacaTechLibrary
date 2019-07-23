using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRender : MonoBehaviour {

    public float time = 10;
    public Vector3 size = new Vector3(1,1,1);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }


    Vector3 shakeVector = new Vector3();
    /// <summary>
    /// 描画前に呼ばれる
    /// </summary>
    void OnPreRender()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            shakeVector.x = Random.Range(-size.x, +size.x);
            shakeVector.y = Random.Range(-size.y, +size.y);
            shakeVector.z = Random.Range(-size.z, +size.z);
        }
        else
        {
            shakeVector.x = 0;
            shakeVector.y = 0;
            shakeVector.z = 0;
        }
        gameObject.transform.position += shakeVector;
    }

    /// <summary>
    /// 描画後に呼ばれる
    /// </summary>
    void OnPostRender()
    {
        gameObject.transform.position -= shakeVector;
    }

}
