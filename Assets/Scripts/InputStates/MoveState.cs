using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    class MoveState : IInputState
    {

        public IInputState processInput(GameObject gameObject)
        {
            move(gameObject);

            return new WaitingState();
        }

        void move(GameObject gameObject)
        {
            CameraMovement cameraMovementComponent = gameObject.GetComponent<CameraMovement>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                cameraMovementComponent.Target = hit.point;
            }
        }
    }
}
