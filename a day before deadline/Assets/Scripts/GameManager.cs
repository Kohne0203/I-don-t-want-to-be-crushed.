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
    float time = 0f;
    Color White = new Color(1, 1, 1, 1);
    int stageNum = 1;

    // ゲームオーバー関連
    [SerializeField]
    GameObject gameOverCanvasPrefab;
    GameObject gameOverCanvasClone;
    Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // timeUIの更新
        this.time += Time.deltaTime;
        this.timeUi.GetComponent<Text>().text = this.time.ToString("F1") + "s";

    }

    // ゲームオーバー処理
    public void GameOver()
    {
        character.SetActive(false);
        Time.timeScale = 0;

        gameOverCanvasClone = Instantiate(gameOverCanvasPrefab);
        buttons = gameOverCanvasClone.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(Retry);
    }

    // リトライ処理
    public void Retry()
    {
        Destroy(gameOverCanvasClone);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
