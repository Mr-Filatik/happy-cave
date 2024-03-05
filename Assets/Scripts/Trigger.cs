using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Action<GameObject> _actionIn;
    private Action<GameObject> _actionOut;

    public void SetAction(Action<GameObject> actionIn, Action<GameObject> actionOut)
    {
        _actionIn = actionIn;
        _actionOut = actionOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _actionIn?.Invoke(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _actionOut?.Invoke(collision.gameObject);
    }
}
