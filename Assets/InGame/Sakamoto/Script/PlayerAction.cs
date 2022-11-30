using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAction
{
    [Header("パンチの判定を出す座標")]
    [SerializeField] Transform[] _punchPos = new Transform[1];
    [Header("パンチの判定距離")]
    [SerializeField] float _punchRay;
    [Header("スタンさせる時間")]
    [SerializeField] float _stanTime;

    [Tooltip("Rayを出す方向")]
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
                Debug.Log("見つけた");
                damage.AddDamage(_stanTime);
            }
        }
    }
}
