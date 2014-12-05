using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    class PressedState : IInputState
    {
        private float _timer;
        private float _threshold;

        public PressedState()
        {
            _timer = 0.0f;
            _threshold = 0.25f;
        }

        public IInputState processInput(GameObject gameObject)
        {
            if (Input.GetMouseButton(0))
            {
                _timer += Time.deltaTime;

                if (_timer >= _threshold)
                {
                    return new SelectState();
                }
            }
            else
            {
                return new MoveState();
            }

            return this;
        }
    }
}
