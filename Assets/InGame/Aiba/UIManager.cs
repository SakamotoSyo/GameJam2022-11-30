using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("得点の画像")]
    [Tooltip("得点の画像")] [SerializeField] GameObject _pointImage;


    [Header("Player1のレイアウト")]
    [Tooltip("Player1のレイアウト")] [SerializeField] LayoutGroup _player1LayoutGroup;

    [Header("Player2のレイアウト")]
    [Tooltip("Player2のレイアウト")] [SerializeField] LayoutGroup _player2LayoutGroup;

    [Header("ゲーム時間のText")]
    [Tooltip("ゲーム時間のText")] [SerializeField] Text _gameTimeText;



    [Header("Player1勝利のパネル")]
    [Tooltip("Player1勝利のパネル")] [SerializeField] GameObject _player1WinnerPanel;

    [Header("Player2勝利のパネル")]
    [Tooltip("Player2勝利のパネル")] [SerializeField] GameObject _player2WinnerPanel;

    [Header("引き分けのパネル")]
    [Tooltip("引き分けのパネル")] [SerializeField] GameObject _drawPanel;


    /// <summaryゲーム終了時のパネルを出す</summary>
    /// <param name="playerNumber">プレイヤーの番号</param>
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



    /// <summary>ゲーム時間のUIを更新する関数</summary>
    /// <param name="time">現在の時間</param>
    public void ChangeGameTimeText(int time)
    {
        _gameTimeText.text = time.ToString();
    }

    /// <summary>各プレイヤーの得点を更新</summary>
    /// 
    /// カメラに映ることに成功したときの、得点用の画像を出す関数
    /// 
    /// <param name="playerNumber">プレイヤーの番号</param>
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
