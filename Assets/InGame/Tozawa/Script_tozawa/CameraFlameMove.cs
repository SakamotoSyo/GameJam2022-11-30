using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
/// <summary>
/// フレームの移動を管理する
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
public class CameraFlameMove : MonoBehaviour
{
    [SerializeField, Header("カメラフレームX軸下上限")]
    int _xRange;
    [SerializeField, Header("カメラフレームY軸下上限")]
    int _yRange;
    [SerializeField, Range(1, 5),Header("カメラフレーム1辺の大きさ")]
    int _flameLength = 1;
    [SerializeField,Header("移動速度")]
    float _moveSpeed;
    [SerializeField, Header("撮影インターバル")]
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
        SizeChange();//フレームの大きさ変更
        SetInitialPos();//初期位置設定
    }
    void Update()
    {
        if(_isMove == false)//移動してない時は撮影待機
        {
            CountTimer();//インターバルごとに撮影＆移動
        }
        else
        {
            FlameMove();//移動
        }
    }
    void CountTimer()//インターバルごとに撮影＆移動
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
    void PhotoShot()//撮影処理
    {
        if (_pMC!=null)
        {
            _pMC.Photographed();
        }
    }

    void SetMoveStatus()//移動のための位置定義
    {
        _moveStartPos = this.transform.position;//開始地点(現在地)決定
        _moveEndPos = RandomPos();//次の移動場所
        _moveDistance = Vector3.Distance(_moveStartPos,_moveEndPos);//二点間の距離
    }
    void FlameMove()//移動
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
    void SetInitialPos()//初期位置設定
    {
        gameObject.transform.position = RandomPos();
    }

    Vector3 RandomPos()//画面内のランダムな座標を返す（Vector2）
    {
        _CameraXPos = Random.Range(-_xRange,_xRange);
        _CameraYPos = Random.Range(-_yRange,_yRange);
        return new Vector3(_CameraXPos,_CameraYPos);
    }
    void SizeChange()//フレームの大きさ変更
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
