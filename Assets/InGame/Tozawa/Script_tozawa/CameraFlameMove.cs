using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// �t���[���̈ړ����Ǘ�����
/// </summary>
public class CameraFlameMove : MonoBehaviour
{
    const int NUM_HALF = 2;
    [SerializeField, Header("�J�����t���[��X�������")]
    int _xRange;
    [SerializeField, Header("�J�����t���[��Y�������")]
    int _yRange;
    [SerializeField, Range(1, 5),Header("�J�����t���[��1�ӂ̑傫��")]
    int _flameLength = 1;
    Vector3 _flameSize;
    Vector3 _moveStartPos;
    Vector3 _moveEndPos;
    [SerializeField,Header("�ړ����x")]
    float _moveSpeed;
    [SerializeField, Header("�B�e�C���^�[�o��")]
    float _takePhotoInterval;
    float _moveDistance;
    float _CameraXPos;
    float _CameraYPos;
    float _time;
    float presentPos;
    [SerializeField]bool _isMove = false;
    const int NUM_ONE = 1;
    void Start()
    {
        SizeChange();//�t���[���̑傫���ύX
        SetInitialPos();//�����ʒu�ݒ�
    }
    void Update()
    {
        if(_isMove == false)//�ړ����ĂȂ����͎B�e�ҋ@
        {
            CountTimer();
        }
        else
        {
            FlameMove();
        }
    }

    private void CountTimer()
    {
        _time += Time.deltaTime;
        if(_time >= _takePhotoInterval)
        {
            SetMoveStatus();
            _isMove = true;
            _time = 0;
        }
    }

    void SetMoveStatus()//�ړ��̂��߂̈ʒu��`
    {
        _moveStartPos = this.transform.position;//�J�n�n�_(���ݒn)����
        _moveEndPos = RandomPos();//���̈ړ��ꏊ
        _moveDistance = Vector3.Distance(_moveStartPos,_moveEndPos);//��_�Ԃ̋���
    }
    void FlameMove()//�ړ�
    {
        _time += Time.deltaTime;
        presentPos = (_time * _moveSpeed) / _moveDistance;
        transform.position = Vector3.Slerp(_moveStartPos, _moveEndPos, presentPos);
        if(presentPos >= NUM_ONE)
        {
            presentPos = 0;
            _time = 0;
            _isMove = false;
        }
    }

    void SetInitialPos()//�����ʒu�ݒ�
    {
        gameObject.transform.position = RandomPos();
    }

    Vector3 RandomPos()//��ʓ��̃����_���ȍ��W��Ԃ��iVector2�j
    {
        _CameraXPos = Random.Range(-_xRange,_xRange);
        _CameraYPos = Random.Range(-_yRange,_yRange);
        return new Vector3(_CameraXPos,_CameraYPos);
    }
    void SizeChange()//�t���[���̑傫���ύX
    {
        _flameSize = new Vector3(_flameLength, _flameLength, _flameLength);
        gameObject.transform.localScale = _flameSize;
    }
}
