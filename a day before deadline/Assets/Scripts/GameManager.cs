using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject character;

    [SerializeField]
    GameObject gameOverCanvasPrefab;
    GameObject gameOverCanvasClone;
    Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        character.SetActive(false);
        Time.timeScale = 0;

        gameOverCanvasClone = Instantiate(gameOverCanvasPrefab);
        buttons = gameOverCanvasClone.GetComponentsInChildren<Button>();
        
    }
}
