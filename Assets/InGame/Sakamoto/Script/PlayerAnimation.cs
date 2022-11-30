using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnimation
{
    [SerializeField] Animator _anim;
    
    PlayerInput _input;

    public void Init(PlayerInput playerInput) 
    {
        _input = playerInput;
    }
    public void Update()
    {
        if (_input.MoveInput == Vector2.zero)
        {
            _anim.SetBool("Walk", false);
        }
        else
        {
            _anim.SetBool("Walk", true);
        }

        if (_input.Action)
        {
            _anim.SetBool("Punch", true);
        }
        else 
        {
            _anim.SetBool("Punch", false);
        }
        _anim.SetFloat("X", _input.LastMoveDir.x);
    }

    
}
