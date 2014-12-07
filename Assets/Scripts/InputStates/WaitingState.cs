using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    class WaitingState : IInputState
    {
        public IInputState processInput(GameObject gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                return new PressedState();
            }

            float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheel != 0)
            {
                return new ZoomState(scrollWheel);
            }

            return this;
        }
    }
}
