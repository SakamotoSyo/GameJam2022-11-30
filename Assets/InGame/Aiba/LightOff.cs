using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    [SerializeField] GameObject _oj;
    public void Off()
    {
        _oj.SetActive(false);
    }
}
