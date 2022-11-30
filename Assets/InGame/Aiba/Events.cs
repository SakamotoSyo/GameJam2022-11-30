using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField] GameManager _gm;


    [SerializeField] GameObject _lightDown1;
    [SerializeField] GameObject _lightDown2;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator LightDown2()
    {
        _lightDown2.SetActive(true);
        yield return new WaitForSeconds(5);
        _lightDown2.SetActive(true);
    }

    IEnumerator LightDown1()
    {
        _lightDown1.SetActive(true);
        yield return new WaitForSeconds(5);
        _lightDown1.SetActive(true);
    }

}
