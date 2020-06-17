using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    GameObject character;
    string sceneName;

    public GameState gameState;
    public enum GameState
    {
        Gaming,
        MoveStage,
        Result
    }

    // UI関連
    GameObject timeUi;
    GameObject stageUi;
    private float timer = 0f;

    Color White = new Color(1, 1, 1, 1);

    public static int stageNum = 0;
    public float firstGoalTime = 30f;
    public float secondGoalTime = 60f;

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
        stageNum += 1;
        sceneName = SceneManager.GetActiveScene().name;
        character = GameObject.Find("unitychan");

        // UIを設定
        this.timeUi = GameObject.Find("RunTime");
        this.stageUi = GameObject.Find("CurrentStage");

        Text timeText = this.timeUi.GetComponent<Text>();
        timeText.color = White;
       
        StageNumCutIn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Text stageText = this.stageUi.GetComponent<Text>();
        stageText.text = "Stage" + stageNum;
        stageText.color = White;

        // timeUIの更新
        timer += Time.deltaTime;
        timeUi.GetComponent<Text>().text = this.timer.ToString("F1") + "s";

        if (Time.time == firstGoalTime)
        {
            StageClear();
            StageNumCutIn();
            Invoke("StageReset", 2);
        };
    }

    public void StageClear()
    {
        stageNum += 1;
        gameState = GameState.MoveStage;
        timeUi.SetActive(false);
        stageUi.SetActive(false);
    }


    public void StageReset()
    {
        gameState = GameState.Gaming;
        timeUi.SetActive(true);
        stageUi.SetActive(true);
    }

    public void MoveFinalStage()
    {
        timeUi.SetActive(false);
        stageUi.SetActive(false);
        clearCanvasClone = Instantiate(clearCanvasPrefab);
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
}