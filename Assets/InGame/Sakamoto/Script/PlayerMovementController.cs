using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IDamage
{
    public PlayerInput GetPlayerInput => _playerInput; 
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerDamage _playerDamage;
    [SerializeField] private PlayerAnimation _playerAnim;
    [SerializeField] private PlayerPhotographed _playerPhotographed;
    private void Start()
    {
        _playerMove.Init(_playerInput);
        _playerPhotographed.Init(_playerInput);
        _playerAnim.Init(_playerInput);
    }

    private void Update()
    {
        _playerInput.Update();
        _playerMove.Update(transform);
        _playerAnim.Update();
    }

    private void FixedUpdate()
    {
        _playerMove.FixedUpdate();
    }

    /// <summary>
    /// �_���[�W���󂯂��Ƃ��̏���
    /// </summary>
    public async void AddDamage(float time)
    {
       await _playerDamage.AddDamage(time);
    }

    /// <summary>
    /// �ʐ^�ɎB��ꂽ�Ƃ�
    /// </summary>
    public void Photographed() 
    {
        _playerPhotographed.Photographed();
    }
}
