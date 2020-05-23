using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{

    public GameObject[] Train;
    float span = 3.0f;
    float delta = 0;
    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var number = Random.Range(0, Train.Length);
        playerPos = GameObject.Find("unitychan").GetComponent<Transform>().position;

        // フレーム毎に変数に値を入れてspanを超えたらインスタンスを生成する
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // 生成する際にdeltaをリセットする
            this.delta = 0;
            
            GameObject go = Instantiate(Train[number]) as GameObject;

            // 出現範囲をランダムで生成
            int respawnRange = Random.Range(-7, 7);
            print(playerPos);
            go.transform.position = new Vector3(playerPos.x, 10, 0);
        }
    }

    public void GenerateDestroy()
    {

    }
}
