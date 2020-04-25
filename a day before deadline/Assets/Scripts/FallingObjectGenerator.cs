using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{

    public GameObject fallingPrefab;
    float span = 3.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // フレーム毎に変数に値を入れてspanを超えたらインスタンスを生成する
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // 生成する際にdeltaをリセットする
            this.delta = 0;
            
            GameObject go = Instantiate(fallingPrefab) as GameObject;

            // 出現範囲をランダムで生成
            int respawnRange = Random.Range(-10, 10);
            go.transform.position = new Vector3(respawnRange, 6, 0);

        }
    }
}
