using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    class ZoomState : IInputState
    {
        private float _direction;
        private float _power;

        public ZoomState(float direction)
        {
            _direction = direction;
            _power = 30.0f;
        }

        public IInputState processInput(GameObject gameObject)
        {
            zoom(gameObject);

            return new WaitingState();
        }

        void zoom(GameObject gameObject)
        {
            CameraMovement cameraMovementComponent = gameObject.GetComponent<CameraMovement>();
            Vector3 target = gameObject.transform.position;
            target.z += _direction * _power;
            // @TODO: Cap zoom depth & make click-move-area stay put on z-axis

            cameraMovementComponent.ZoomTarget = target;
        }
    }
}
