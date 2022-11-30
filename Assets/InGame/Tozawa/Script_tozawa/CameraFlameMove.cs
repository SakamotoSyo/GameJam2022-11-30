using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// �t���[���̈ړ����Ǘ�����
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class CameraFlameMove : MonoBehaviour
{
    [SerializeField, Header("�J�����t���[��X�������")]
    int _xRange;
    [SerializeField, Header("�J�����t���[��Y�������")]
    int _yRange;
    [SerializeField, Range(1, 5),Header("�J�����t���[��1�ӂ̑傫��")]
    int _flameLength = 1;
    [SerializeField,Header("�ړ����x")]
    float _moveSpeed;
    [SerializeField, Header("�B�e�C���^�[�o��")]
    float _takePhotoInterval;
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    float _moveDistance;
    float _CameraXPos;
    float _CameraYPos;
    float _time;
    float presentPos;
    Vector3 _flameSize;
    Vector3 _moveStartPos;
    Vector3 _moveEndPos;
    bool _isMove = false;
    bool _isInside = false;
    PlayerMovementController _pMC;
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    const int NUM_HALF = 2;
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
            CountTimer();//�C���^�[�o�����ƂɎB�e���ړ�
        }
        else
        {
            FlameMove();//�ړ�
        }
    }
    void CountTimer()//�C���^�[�o�����ƂɎB�e���ړ�
    {
        _time += Time.deltaTime;
        if(_time >= _takePhotoInterval)
        {
            PhotoShot();
            SetMoveStatus();
            _isMove = true;
            _time = 0;
        }
    }
    void PhotoShot()//�B�e����
    {
        if (_pMC!=null)
        {
            _pMC.Photographed();
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Called");
        _pMC = collision.GetComponent<PlayerMovementController>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _pMC = null;
    }
}
