using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    [Tooltip("移動先ターゲットとなるオブジェクト")]  // このように書くと Inspector に説明を表示できる
    [SerializeField] Transform[] _targets;
    [Tooltip("オブジェクトの移動速度")]
    [SerializeField] float _moveSpeed = 1f;
    [Tooltip("ターゲットに到達したと判断する距離（単位:メートル）")]
    [SerializeField] float _stoppingDistance = 0.05f;
    /// <summary>次のターゲットに到達するまでのタイムリミット（秒）</summary>
    [SerializeField] float _timeLimitToNextTarget = 1f;
    /// <summary>現在のターゲットのインデックス</summary>
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