using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.InputStates
{
    interface IInputState
    {
        IInputState processInput(GameObject gameObject);
    }
}
