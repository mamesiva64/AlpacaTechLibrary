using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlpacaTech
{
    /// <summary>
    /// 
    /// AxisのDown/Press/Up
    /// ButtonのDown/Press/Up
    /// ButtonのRepeat
    /// 
    /// </summary>
    public class JoystickManager
    {
        public static JoystickManager instance = new JoystickManager();
        public JoystickInput[] axis = new JoystickInput[2];
        public JoystickButton[] buttons = new JoystickButton[8];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stick">0...left/1...right</param>
        /// <returns></returns>
        public static Vector2 GetAxis(int stick)
        {
            return instance.axis[stick].Axis;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool GetButtonDown(int id)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool GetButton(int id)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool GetButtonRepat(int id)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool GetButtonUp(int id)
        {
            return false;
        }

    }
}