using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject character;
    string sceneName;

    // UI関連
    GameObject timeUi;
    GameObject stageUi;
    private float time = 0f;
    Color White = new Color(1, 1, 1, 1);
    public static int stageNum = 0;
    public float goalTime = 5f;

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
        Text stageText = this.stageUi.GetComponent<Text>();

        stageText.text = "Stage " + stageNum;

        timeText.color = White;
        stageText.color = White;

        // カットイン演出
        stageCanvasClone = Instantiate(stageCanvasPrefab);
        startCutin = stageCanvasClone.GetComponentInChildren<Text>();
        startCutin.text = stageText.text;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // timeUIの更新
        time += Time.deltaTime;
        timeUi.GetComponent<Text>().text = this.time.ToString("F1") + "s";

        if (Time.time == goalTime)
        {
            print("ステージクリア");
            StageClear();
        }
    }

    public void StageClear()
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
}
