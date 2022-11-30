using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("ゲーム''開始時''に呼ぶもの")]
    [Tooltip("ゲーム''開始時''に呼ぶもの")] [SerializeField] UnityEvent _onGameStart;

    [Header("ゲーム''終了時''に呼ぶもの")]
    [Tooltip("ゲーム''終了時''に呼ぶもの")] [SerializeField] UnityEvent _onGameEnd;

    [Header("ゲームの時間")]
    [Tooltip("ゲームの時間")] float _gameTime = 60;

    /// <summary>ゲーム時間計算用の変数</summary>
    private float _countTime = 0;

    [Header("スタートカウント用のText")]
    [Tooltip("スタートカウント用のText")] [SerializeField] Text _startCountText;

    [Header("勝利のための必要ポイント")]
    [Tooltip("勝利のための必要ポイント")] int _winPoint = 3;

    /// <summary>Player1の得点</summary>
    private int _player1Score = 0;

    /// <summary>Player2の得点</summary>
    private int _player2Score = 0;

    [SerializeField] UIManager _uIManager;

    private bool _isGame = false;
    private void Awake()
    {
        _countTime = _gameTime;
    }

    void Start()
    {
      StartCoroutine(StartCount());
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        CountTime();
    }

    public void P1Win()
    {
        _player1Score = 2;
        GetPoint(1);
    }

    public void P2Win()
    {
        _player2Score = 2;
        GetPoint(2);
    }

    public void Drow()
    {
        _isGame = true;
        _countTime = 0;
    }

    IEnumerator StartCount()
    {
        _startCountText.text = "3";
        yield return new WaitForSeconds(1);
        _startCountText.text = "2";
        yield return new WaitForSeconds(1);
        _startCountText.text = "1";
        yield return new WaitForSeconds(1);
        _startCountText.text = "Start";
        _isGame = true;
        yield return new WaitForSeconds(1);
        _startCountText.text = "";
    }

    /// <summary>ゲーム時間計測用の関数</summary>
    void CountTime()
    {
        if (_isGame)
        {
            if (_countTime <= 0)
            {
                _uIManager.SetGameEndPanel(0);
                _onGameEnd.Invoke();
            }//Game時間が0だったら終了
            else
            {
                _countTime -= Time.deltaTime;
                _uIManager.ChangeGameTimeText((int)_countTime);
            }//残っていたら計算し、ゲーム時間のUIを更新
        }
    }



    /// <summary>各プレイヤーの得点を更新</summary>
    /// <param name="playerNumber">プレイヤーの番号</param>
    public void GetPoint(int playerNumber)
    {
        _uIManager.SetPlayerScoreImage(playerNumber);

        if (playerNumber == 1)
        {
            _player1Score++;


            if (_player1Score == _winPoint)
            {
                _uIManager.SetGameEndPanel(1);
                _onGameEnd.Invoke();
            }
        }
        else if (playerNumber == 2)
        {
            _player2Score++;

            if (_player2Score == _winPoint)
            {
            _uIManager.SetGameEndPanel(2);
                _onGameEnd.Invoke();
            }
        }
    }
}
