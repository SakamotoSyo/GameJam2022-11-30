using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerInput
{
    public Vector2 PlayerDir => _playerDir;
    public Vector2 LastMoveDir => _playerDir;
    public int PlayerNum => _playerNum;

    [Header("�������g�̃v���C���[�ԍ�")]
    [SerializeField] int _playerNum;

    [Tooltip("��������")]
    Vector2 _movement;
    [Tooltip("�Ō�ɓ���������")]
    Vector2 _playerDir;
    [Tooltip("����Action����")]
    bool _isAction = false;
    [Tooltip("���݃W�����v�����ǂ���")]
    bool _isJump = false;
    [Tooltip("Input���u���b�N���邩�ǂ���")]
    bool _inputBlock = true;

    /// <summary>���݃A�N�V���������ǂ����Ԃ�</summary>
    public bool Action
    {
        get { return _isAction && !_inputBlock; }
    }

    public bool Jump
    {
        get { return _isJump && !_inputBlock; }
    }
    /// <summary>���݂̕������͂�Ԃ�</summary>
    public Vector2 MoveInput
    {
        get
        {
            if (_inputBlock)
            {
                return Vector2.zero;
            }
            return _movement;
        }
    }

    public void Update()
    {
        _movement = new Vector2(Input.GetAxisRaw($"Horizontal{_playerNum}"),0);

        if (Vector2.zero != _movement)
        {
            _playerDir = _movement;
        }

        if (Input.GetButtonDown($"Action{_playerNum}"))
        {
            _isAction = true;
        }
        else
        {
            _isAction = false;
        }

        if (Input.GetButtonDown($"Jump{_playerNum}"))
        {
            _isJump = true;
        }
        else
        {
            _isJump = false;
        }
    }


    /// <summary>Input�Ɋւ�����͂��󂯕t���邩�ǂ����ύX����</summary>
    public void InputBlock()
    {
        _inputBlock = !_inputBlock;
    }
}
