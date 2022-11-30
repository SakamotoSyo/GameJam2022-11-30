using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

[Serializable]
public class PlayerDamage
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _knockBackPower;
    [Header("�m�b�N�o�b�N���痧������܂ł̎���")]
    [SerializeField] private float _knockBackTime;

    private PlayerInput _playerInput;

    public void Init(PlayerInput input) 
    {
        _playerInput = input;
    }

    /// <summary>
    /// �_���[�W���󂯂�ƃm�b�N�o�b�N����֐�
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public async UniTask AddDamage(float time) 
    {
        _playerInput.InputBlock();
        Debug.Log(_playerInput.LastMoveDir);
        _rb.AddForce(_playerInput.LastMoveDir * -1 * _knockBackPower, ForceMode2D.Impulse);
        await UniTask.Delay(TimeSpan.FromSeconds(time));
        _playerInput.InputBlock();
    }

}
