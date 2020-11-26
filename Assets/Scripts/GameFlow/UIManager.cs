using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region Fields
    [Header("UI Staff")]
    [SerializeField] private Button startBtn;
    [SerializeField] private Transform startPanel;
    [Space]
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Transform pausePanel;
    [Space]
    [SerializeField] private Button reloadBtn;
    [SerializeField] private Button homeBtn;
    [SerializeField] private Transform gameOverPanel;

    [Header("Animation")]
    [SerializeField] private Ease startPanelEase;
    [SerializeField] private Ease pausePanelEase;
    #endregion

    #region GameEvents
    public static event Action onStartGame;
    public static event Action onGamePause;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(StartGame);
        pauseBtn.onClick.AddListener(HandleGamePause);
    }



    void StartGame()
    {

        //ToDO: disable panel
        startPanel.DOMoveY(2500f , 1f , false).SetEase(startPanelEase).OnComplete(() =>
        {
            startPanel.gameObject.SetActive(false);
            onStartGame();
        });
    }

    void HandleGameOver()
    {

    }

    void HandleGamePause()
    {
        //onGamePause();
        pausePanel.gameObject.SetActive(true);

        Time.timeScale = 0;

        pausePanel.DOLocalMoveY(0f, 1f, false).SetEase(pausePanelEase).OnComplete(() =>
        {
            
           
        });
    }
}
