using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AlpacaTech
{
    /// <summary>
    /// Camera shake.
    /// 
    /// How To Use.
    ///     AlpacaTech.CameraSHake.Shake(0.2f,0.1f,false);
    /// 
    /// </summary>
    public class CameraShake : MonoBehaviour
    {
        static private CameraShake Instance;
        private float time = 0.2f;
        private Vector3 size = new Vector3(1f, 1f, 1f);

        /// <summary>
        /// Cameras the shake.
        /// </summary>
        /// <param name="time">Time.</param>
        /// <param name="power">Power.</param>
        static public void Shake(float time,float power ,bool is3D )
        {
            if(Instance == null)
            {
                Instance = Camera.main.GetComponent<CameraShake>();
                if (Instance == null)
                {
                    Instance = Camera.main.gameObject.AddComponent<CameraShake>();
                }
            }
            Instance.time = time;
            Instance.size = is3D ? Vector3.one * power : new Vector3(1,1,0) * power;
        }

        /// <summary>
        /// Stop this instance.
        /// </summary>
        static public void Stop()
        {
            Instance.time = 0;        
        }

        /// <summary>
        /// The shake position.
        /// </summary>
        private Vector3 shakePosition = new Vector3();

        /// <summary>
        /// 描画前に呼ばれる
        /// </summary>
        private void OnPreRender()
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                shakePosition.x = Random.Range(-size.x, +size.x);
                shakePosition.y = Random.Range(-size.y, +size.y);
                shakePosition.z = Random.Range(-size.z, +size.z);
            }
            else
            {
                shakePosition = Vector3.zero;
            }
            gameObject.transform.position += shakePosition;
        }

        /// <summary>
        /// 描画後に呼ばれる
        /// </summary>
        private void OnPostRender()
        {
            gameObject.transform.position -= shakePosition;
        }

    }

}
