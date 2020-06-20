using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    Button startButton;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        startButton.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        SceneManager.LoadScene("Stage1");
        gameManager.SetStage(GameManager.GameStage.Stage1);
    }
}
