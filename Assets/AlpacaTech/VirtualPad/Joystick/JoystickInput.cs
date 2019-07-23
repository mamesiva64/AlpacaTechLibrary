using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AlpacaTech
{
    public class JoystickInput : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public enum StartArea
        {
            Fill,
            Left,
            Rigth,
        };

        /// <summary>
        /// 
        /// </summary>
        public enum MoveScope
        {
            Circle,
            Rect
        };

        [SerializeField] StartArea startArea = StartArea.Fill;
        [SerializeField] Image imageBase;
        [SerializeField] Image imageHat;

        private Vector3 startPosition = Vector3.zero;
        private int fingerId = -999;

        public float InputScope = 100.0f;

        public Vector3 Axis = Vector2.zero;
        public bool Press = false;

        public string AxisX = "";
        public string AxisY = "";

        /// <summary>
        /// 
        /// </summary>
        void Awake()
        {
            ImageShow(false);
            switch (startArea)
            {
                case StartArea.Fill:
                case StartArea.Left:
                    JoystickManager.instance.axis[0] = this;
                    break;
                case StartArea.Rigth:
                    JoystickManager.instance.axis[1] = this;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="show"></param>
        void ImageShow(bool show)
        {
            imageBase.enabled = show;
            imageHat.enabled = show;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        void OnTouchDown(int id)
        {
            if (Press)
            {
                return;
            }

            var pos = Input.mousePosition;
            switch (startArea)
            {
                case StartArea.Fill:
                    break;
                case StartArea.Left:
                    if (pos.x > (float)Screen.width/2)
                    {
                        return;
                    }
                    break;
                case StartArea.Rigth:
                    if (pos.x < (float)Screen.width/2)
                    {
                        return;
                    }
                    break;
            }

            ImageShow(true);
            imageHat.transform.position = pos;
            imageBase.transform.position = pos;
            Press = true;
            Axis = Vector3.zero;
            startPosition = pos;
            fingerId = id;
        }

        void OnTouchPress(int id, Vector3 pos)
        {
            if (fingerId != id)
            {
                return;
            }
#if true
            //  Circle
            var delta = pos - startPosition;
            var len = delta.magnitude;
            len = Mathf.Min(len, InputScope);
            delta = delta.normalized * len;
            imageHat.transform.position = startPosition + delta;
            Axis = delta / InputScope;
#else
            //  Rect
            pos.x = Mathf.Clamp(pos.x, startPosition.x - inputScope, startPosition.x + inputScope);
            pos.y = Mathf.Clamp(pos.y, startPosition.y - inputScope, startPosition.y + inputScope);

            imageHat.transform.position = pos;
            Axis.x = (pos.x - startPosition.x)/inputScope;
            Axis.y = (pos.y - startPosition.y)/inputScope;
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pos"></param>
        void OnTouchUp(int id, Vector3 pos)
        {
            if (fingerId != id)
            {
                return;
            }

            Press = false;
            Axis = Vector3.zero;
            imageHat.transform.position = startPosition;
            ImageShow(false);
        }


        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            var touches = Input.touches;

            //  Key
            try
            {
                var ix = Input.GetAxis(AxisX);
                var iy = Input.GetAxis(AxisY);
                Axis.x = ix;
                Axis.y = iy;
            }
            catch
            {

            }

            //  Touch
            foreach (var touch in touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        OnTouchDown(touch.fingerId);
                        break;
                    case TouchPhase.Stationary:
                    case TouchPhase.Moved:
                        OnTouchPress(touch.fingerId, touch.position);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        OnTouchUp(touch.fingerId, touch.position);
                        break;
                }
            }

            //  Mouse
            if (Input.GetMouseButtonDown(0))
            {
                OnTouchDown(-1);
            }
            if (Input.GetMouseButton(0))
            {
                OnTouchPress(-1, Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                OnTouchUp(-1, Input.mousePosition);
            }
           
        }
    }
}