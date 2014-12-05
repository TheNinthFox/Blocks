using UnityEngine;
using System.Collections;
using Assets.Scripts.InputStates;

/**
 * Player Input class.
 * Input is divided into states, with each state returning its successor (or itself).
 * Each state encapsulates its own behavior and can be accessed via the IInputState
 * interface.
 *
 * Waiting -> Pressed -> Select or Move -> Waiting
 */
public class PlayerInput : MonoBehaviour
{
    private IInputState _inputState;

    void Awake()
    {
        _inputState = new WaitingState();
    }

    void Start()
    {
    }

    void Update()
    {
        _inputState = _inputState.processInput(gameObject);
    }


}
