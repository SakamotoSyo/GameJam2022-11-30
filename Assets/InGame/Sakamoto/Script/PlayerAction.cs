using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAction
{
    [Header("�p���`�̔�����o�����W")]
    [SerializeField] Transform[] _punchPos = new Transform[1];
    [Header("�p���`�̔��苗��")]
    [SerializeField] float _punchRay;
    [Header("�X�^�������鎞��")]
    [SerializeField] float _stanTime;

    [Tooltip("Ray���o������")]
    PlayerInput _playerInput;

    public void Init(PlayerInput input) 
    {
        _playerInput = input;
    }

    public void Update(Transform transform)
    {
        if (_playerInput.Action)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerInput.LastMoveDir, _punchRay);

            if (hit.collider.TryGetComponent(out IDamage damage)) 
            {
                Debug.Log("������");
                damage.AddDamage(_stanTime);
            }
        }
    }
}
