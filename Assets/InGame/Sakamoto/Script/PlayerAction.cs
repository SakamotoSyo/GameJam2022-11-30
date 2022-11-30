using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAction
{
    [Header("パンチの判定を出す座標")]
    [SerializeField] Transform[] _punchPos = new Transform[1];
    [Header("Rayを出す方向")]
    [SerializeField] PlayerInput _playerInput;
    [Header("パンチの判定距離")]
    [SerializeField] float _punchRay;
    [Header("スタンさせる時間")]
    [SerializeField] float _stanTime;
    void Update(Transform transform)
    {
        if (_playerInput.Action)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, _playerInput.LastMoveDir, _punchRay);

            if (hit.collider.TryGetComponent(out IDamage damage)) 
            {
                damage.AddDamage(_stanTime);
            }
        }
    }
}
