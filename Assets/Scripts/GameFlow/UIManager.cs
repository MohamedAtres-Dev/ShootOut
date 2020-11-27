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
    [SerializeField] private Transform gameOverPanel;
    [SerializeField] private Transform gameSuccessPanel;

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

        //Subscribe to Events
        PlayerHealth.onGameOver += HandleGameOver;
        PlayerShoot.onGameSuccess += HandleGameSuccess;
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
        //onGamePause();
        gameOverPanel.gameObject.SetActive(true);

        Time.timeScale = 0;

        gameOverPanel.DOLocalMoveY(0f, 1f, false).SetEase(pausePanelEase).OnComplete(() =>
        {


        });
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

    void HandleGameSuccess()
    {
        //onGamePause();
        gameSuccessPanel.gameObject.SetActive(true);

        Time.timeScale = 0;

        gameSuccessPanel.DOLocalMoveY(0f, 1f, false).SetEase(pausePanelEase).OnComplete(() =>
        {


        });
    }

    public void ContinueButton()
    {
        pausePanel.DOLocalMoveY(2500f, 1f, false).SetEase(startPanelEase).OnComplete(() =>
        {
            pausePanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        });



    }

    public void ReloadButton()
    {
        gameOverPanel.DOLocalMoveY(2500f, 1f, false).SetEase(startPanelEase).OnComplete(() =>
        {
            gameOverPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
            //TODO : make a game reload effect
        });
    }

    public void HomeButton()
    {
        if (gameOverPanel)
        {
            gameOverPanel.DOLocalMoveY(2500f, 1f, false).SetEase(startPanelEase).OnComplete(() =>
            {
                gameOverPanel.gameObject.SetActive(false);
                Time.timeScale = 1;
                //TODO : make a game reload effect
                startPanel.gameObject.SetActive(true);
                startPanel.DOLocalMoveY(0f, 1f, false).SetEase(pausePanelEase).OnComplete(() =>
                {


                });

            });
        }

        if (pausePanel)
        {
            pausePanel.DOLocalMoveY(2500f, 1f, false).SetEase(startPanelEase).OnComplete(() =>
            {
                pausePanel.gameObject.SetActive(false);
                Time.timeScale = 1;
                //TODO : make a game reload effect
                startPanel.gameObject.SetActive(true);
                startPanel.DOLocalMoveY(0f, 1f, false).SetEase(pausePanelEase).OnComplete(() =>
                {


                });

            });
        }

    }
}
