using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerPhotographed
{
    [SerializeField] GameManager _gameManager;

    private PlayerInput _input;

    public void Init(PlayerInput input) 
    {
        _input = input;
    }

    public void Photographed() 
    {
        _gameManager.GetPoint(_input.PlayerNum);
    }
}
