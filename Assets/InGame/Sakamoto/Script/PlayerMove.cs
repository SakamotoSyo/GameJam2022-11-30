using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    public Collider2D Col => _col;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [Header("Player‚Ì‘«Œ³")]
    [SerializeField] Vector2 _asi;
    [Header("GroundLayer")]
    [SerializeField] LayerMask _groundMask;

    private Collider2D _col;
    private PlayerInput _input;

    public void Init(PlayerInput input) 
    {
        _input = input;
    }

    public void Update(Transform transform)
    {
        _col = Physics2D.OverlapBox(transform.position, _asi, 0f, _groundMask);

        if (_input.Jump && _col)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }

    public void FixedUpdate()
    {
        _rb.velocity = new Vector2(_input.MoveInput.x * _speed, _rb.velocity.y);
    }
}
