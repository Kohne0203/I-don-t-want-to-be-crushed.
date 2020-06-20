using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{

    public GameObject[] Train;
    float span;
    float delta = 0;
    public Vector3 playerPos;
    int invokeTime;

    public GameManager gameManager;
    public VariableManager variable;

    void Start()
    {
        invokeTime = variable.InvokeTime;
        Invoke("FixedUpdate", invokeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        var number = Random.Range(0, Train.Length);
        playerPos = GameObject.Find("unitychan").GetComponent<Transform>().position;
        span = variable.FallSpan;

        // フレーム毎に変数に値を入れてspanを超えたらインスタンスを生成する
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // 生成する際にdeltaをリセットする
            this.delta = 0;
            
            GameObject go = Instantiate(Train[number]) as GameObject;

            if (gameManager.currentGameState == GameManager.GameState.Gaming)
            {
                // 出現範囲をランダムで生成
                int respawnRange = Random.Range(-7, 7);
                go.transform.position = new Vector3(playerPos.x, 10, 0);
            }
            else if (gameManager.currentGameState == GameManager.GameState.MoveStage)
            {
                print("ステージ移動中");
                Destroy(go);
            }
        }
    }

    public void GenerateDestroy()
    {

    }
}
