using Cainos.PixelArtTopDown_Basic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class TreeController : MonoBehaviour
{
    [SerializeField]
    private int _appleCount = 3;

    [SerializeField]
    private GameObject _apple;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private Trigger _trigger;

    private void Awake()
    {
        _trigger.SetAction(ShakeIn, ShakeOut);
    }

    private void ShakeIn(GameObject go)
    {
        ShakeSwitch(go, true);
    }

    private void ShakeOut(GameObject go)
    {
        ShakeSwitch(go, false);
    }

    private void ShakeSwitch(GameObject go, bool flag)
    {
        if (go.CompareTag("Player"))
        {
            var comp = go.GetComponent<TopDownCharacterController>();
            if (comp != null)
            {
                comp.IsShackable = flag;
                if (flag)
                {
                    comp.Shaked += GetApple;
                }
                else
                {
                    comp.Shaked -= GetApple;
                }
            }
        }
    }

    private void GetApple()
    {
        if (_appleCount > 0)
        {
            var go = Instantiate(_apple, _spawnPoint);
            var pos = go.transform.position;
            pos.x += UnityEngine.Random.Range(-2F, 2F);
            pos.y += UnityEngine.Random.Range(-2F, 2F);
            go.transform.position = pos;
            _appleCount--;
        }
    }
}
