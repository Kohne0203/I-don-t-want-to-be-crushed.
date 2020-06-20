using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public VariableManager variable;
    GameObject character;

    // ゲーム状態
    public GameState currentGameState;
    public enum GameState
    {
        Gaming,
        MoveStage,
        Result
    }

    // ステージ設定
    public GameStage currentStage;
    public enum GameStage
    {
        Stage1,
        Stage2,
        Stage3
    }

    // UI関連
    GameObject timeUi;
    GameObject stageUi;
    private float timer = 0f;

    Color White = new Color(1, 1, 1, 1);

    private float goalTime;
    private int stageNum;

    [SerializeField]
    GameObject stageCanvasPrefab;
    GameObject stageCanvasClone;
    Text startCutin;

    [SerializeField]
    GameObject clearCanvasPrefab;
    GameObject clearCanvasClone;

    // ゲームオーバー関連
    [SerializeField]
    GameObject gameOverCanvasPrefab;
    GameObject gameOverCanvasClone;
    Button[] buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        SetStage(GameStage.Stage1);
        character = GameObject.Find("unitychan");

        // UIを設定
        this.timeUi = GameObject.Find("RunTime");
        this.stageUi = GameObject.Find("CurrentStage");

        Text timeText = this.timeUi.GetComponent<Text>();
        timeText.color = White;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // stageUIの更新
        Text stageText = this.stageUi.GetComponent<Text>();
        stageText.text = "Stage" + stageNum;
        stageText.color = White;

        // timeUIの更新
        timer += Time.deltaTime;
        timeUi.GetComponent<Text>().text = this.timer.ToString("F1") + "s";

        if (Time.time == goalTime)
        {
            SetCurrentState(GameState.MoveStage);
            StageClear();
        };
    }

    // 次のステージの準備処理
    public void SetStage(GameStage stage)
    {
        currentStage = stage;
        SetCurrentState(GameState.Gaming);
        StageNumCutIn();
        goalTime = variable.GoalTime;
    }

    public void SetCurrentState(GameState state)
    {
        currentGameState = state;
    }

    void OnGameStageChanged(GameStage currentStage)
    {
        switch (currentStage)
        {
            case GameStage.Stage1:
                SetStage(GameStage.Stage2);
                MoveStage();
                break;
            case GameStage.Stage2:
                SetStage(GameStage.Stage3);
                MoveStage();
                break;
            case GameStage.Stage3:

                break;
            default:
                break;
        }
    }

    // ステージクリア演出
    public void StageClear()
    {
        timeUi.SetActive(false);
        stageUi.SetActive(false);
        clearCanvasClone = Instantiate(clearCanvasPrefab);

        // クリア演出をした後にステージ移行をする
        StartCoroutine(DelayMethod(2.0f, () =>
        {
            OnGameStageChanged(currentStage);
        }));
    }


    public void MoveStage()
    {
        timeUi.SetActive(true);
        stageUi.SetActive(true);
    }

    // ゲームオーバー処理
    public void GameOver()
    {
        character.SetActive(false);
        Destroy(timeUi);
        Destroy(stageUi);
        Time.timeScale = 0;

        gameOverCanvasClone = Instantiate(gameOverCanvasPrefab);
        buttons = gameOverCanvasClone.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(Retry);
        buttons[1].onClick.AddListener(BackToTitle);
    }

    // カットイン演出
    public void StageNumCutIn()
    {
        stageNum = variable.StageNum;
        stageCanvasClone = Instantiate(stageCanvasPrefab);
        startCutin = stageCanvasClone.GetComponentInChildren<Text>();
        startCutin.text = "Stage" + stageNum;
    }

    // リトライ処理
    public void Retry()
    {
        Destroy(gameOverCanvasClone);
        SceneManager.LoadScene("Stage1");
        stageNum = 0;
        Time.timeScale = 1.0f;
    }

    // タイトルに戻る
    public void BackToTitle()
    {
        Destroy(gameOverCanvasClone);
        SceneManager.LoadScene("Title");
    }

    void GameClear()
    {
        print("ゲームクリア");
    }

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="waitTime">遅延時間[ミリ秒]</param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}