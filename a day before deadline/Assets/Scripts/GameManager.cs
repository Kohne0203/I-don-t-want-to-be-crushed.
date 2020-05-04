using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject character;
    string sceneName;

    [SerializeField]
    GameObject gameOverCanvasPrefab;
    GameObject gameOverCanvasClone;
    Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        character = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        
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
