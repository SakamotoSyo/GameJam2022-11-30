using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("���_�̉摜")]
    [Tooltip("���_�̉摜")] [SerializeField] GameObject _pointImage;


    [Header("Player1�̃��C�A�E�g")]
    [Tooltip("Player1�̃��C�A�E�g")] [SerializeField] LayoutGroup _player1LayoutGroup;

    [Header("Player2�̃��C�A�E�g")]
    [Tooltip("Player2�̃��C�A�E�g")] [SerializeField] LayoutGroup _player2LayoutGroup;

    [Header("�Q�[�����Ԃ�Text")]
    [Tooltip("�Q�[�����Ԃ�Text")] [SerializeField] Text _gameTimeText;



    [Header("Player1�����̃p�l��")]
    [Tooltip("Player1�����̃p�l��")] [SerializeField] GameObject _player1WinnerPanel;

    [Header("Player2�����̃p�l��")]
    [Tooltip("Player2�����̃p�l��")] [SerializeField] GameObject _player2WinnerPanel;

    [Header("���������̃p�l��")]
    [Tooltip("���������̃p�l��")] [SerializeField] GameObject _drawPanel;


    /// <summary�Q�[���I�����̃p�l�����o��</summary>
    /// <param name="playerNumber">�v���C���[�̔ԍ�</param>
    public void SetGameEndPanel(int playerNumber)
    {
        if (playerNumber == 1)
        {
            _player1WinnerPanel.SetActive(true);
        }
        else if (playerNumber == 2)
        {
            _player2WinnerPanel.SetActive(true);
        }
        else
        {
            _drawPanel.SetActive(true);
        }
    }



    /// <summary>�Q�[�����Ԃ�UI���X�V����֐�</summary>
    /// <param name="time">���݂̎���</param>
    public void ChangeGameTimeText(int time)
    {
        _gameTimeText.text = time.ToString();
    }

    /// <summary>�e�v���C���[�̓��_���X�V</summary>
    /// 
    /// �J�����ɉf�邱�Ƃɐ��������Ƃ��́A���_�p�̉摜���o���֐�
    /// 
    /// <param name="playerNumber">�v���C���[�̔ԍ�</param>
    public void SetPlayerScoreImage(int playerNumber)
    {
        var go = Instantiate(_pointImage);

        if (playerNumber == 1)
        {
            go.transform.SetParent(_player1LayoutGroup.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerNumber == 2)
        {
            go.transform.SetParent(_player2LayoutGroup.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }


}
