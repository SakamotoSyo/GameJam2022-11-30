using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

[Serializable]
public class PlayerDamage
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _knockBackPower;
    [Header("�m�b�N�o�b�N���痧������܂ł̎���")]
    [SerializeField] private float _knockBackTime;


    /// <summary>
    /// �_���[�W���󂯂�ƃm�b�N�o�b�N����֐�
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public async UniTask AddDamage(float time) 
    {
        _playerInput.InputBlock();
        _rb.AddForce(_playerInput.LastMoveDir * -1 * _knockBackPower, ForceMode2D.Impulse);
        await UniTask.Delay(TimeSpan.FromSeconds(time));
        _playerInput.InputBlock();
    }

}
