using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    class SelectState : IInputState
    {
        private GameObject _selectedObject;
        private Color _originalColor;

        public SelectState()
        {
            _selectedObject = null;
            _originalColor = Color.white;
        }

        public IInputState processInput(GameObject gameObject)
        {
            // Deselect in case the mouse has moved to another object
            if(_selectedObject != null)
            {
                deselect();
            }

            // Try to select the new gameobject
            select();

            // Check if we need to change the state
            if (Input.GetMouseButtonUp(0))
            {
                if (_selectedObject != null)
                {
                    deselect();
                }

                return new WaitingState();
            }

            return this;
        }

        void select()
        {
            int layerMask = 1 << 8;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                _selectedObject = hit.transform.gameObject;
                _originalColor = _selectedObject.renderer.material.color;
                _selectedObject.renderer.material.color = Color.red;

            }
        }

        void deselect()
        {
            _selectedObject.renderer.material.color = _originalColor;
            _selectedObject = null;
        }
    }
}
