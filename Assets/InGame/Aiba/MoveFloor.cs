using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [Tooltip("�ړ���^�[�Q�b�g�ƂȂ�I�u�W�F�N�g")]  // ���̂悤�ɏ����� Inspector �ɐ�����\���ł���
    [SerializeField] Transform[] _targets;
    [Tooltip("�I�u�W�F�N�g�̈ړ����x")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("�^�[�Q�b�g�ɓ��B�����Ɣ��f���鋗���i�P��:���[�g���j")]
    [SerializeField] float _stoppingDistance = 0.05f;
    /// <summary>���̃^�[�Q�b�g�ɓ��B����܂ł̃^�C�����~�b�g�i�b�j</summary>
    [SerializeField] float _timeLimitToNextTarget = 1f;
    /// <summary>���݂̃^�[�Q�b�g�̃C���f�b�N�X</summary>
    int _currentTargetIndex = 0;
    float _timer = 0;



    private void FixedUpdate()
    {
    }

    void Update()
    {
        PatrolWithChangeTargetByCollision();
    }

    void PatrolWithChangeTargetByCollision()
    {
        float distance = Vector2.Distance(this.transform.position, _targets[_currentTargetIndex].position);

        if (distance > _stoppingDistance)
        {

            Vector3 dir = (_targets[_currentTargetIndex].transform.position - this.transform.position).normalized * _moveSpeed;
            this.transform.Translate(dir * Time.deltaTime);


        }
        else
        {

            _currentTargetIndex++;
            _currentTargetIndex = _currentTargetIndex % _targets.Length;
        }

    }

}