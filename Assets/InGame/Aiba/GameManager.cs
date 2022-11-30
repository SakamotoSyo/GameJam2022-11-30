using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("�Q�[��''�J�n��''�ɌĂԂ���")]
    [Tooltip("�Q�[��''�J�n��''�ɌĂԂ���")] [SerializeField] UnityEvent _onGameStart;

    [Header("�Q�[��''�I����''�ɌĂԂ���")]
    [Tooltip("�Q�[��''�I����''�ɌĂԂ���")] [SerializeField] UnityEvent _onGameEnd;

    [Header("�Q�[���̎���")]
    [Tooltip("�Q�[���̎���")] float _gameTime = 60;

    /// <summary>�Q�[�����Ԍv�Z�p�̕ϐ�</summary>
    private float _countTime = 0;

    [Header("�X�^�[�g�J�E���g�p��Text")]
    [Tooltip("�X�^�[�g�J�E���g�p��Text")] [SerializeField] Text _startCountText;

    [Header("�����̂��߂̕K�v�|�C���g")]
    [Tooltip("�����̂��߂̕K�v�|�C���g")] int _winPoint = 3;

    /// <summary>Player1�̓��_</summary>
    private int _player1Score = 0;

    /// <summary>Player2�̓��_</summary>
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

    /// <summary>�Q�[�����Ԍv���p�̊֐�</summary>
    void CountTime()
    {
        if (_isGame)
        {
            if (_countTime <= 0)
            {
                _uIManager.SetGameEndPanel(0);
                _onGameEnd.Invoke();
            }//Game���Ԃ�0��������I��
            else
            {
                _countTime -= Time.deltaTime;
                _uIManager.ChangeGameTimeText((int)_countTime);
            }//�c���Ă�����v�Z���A�Q�[�����Ԃ�UI���X�V
        }
    }



    /// <summary>�e�v���C���[�̓��_���X�V</summary>
    /// <param name="playerNumber">�v���C���[�̔ԍ�</param>
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
