using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectGenerator : MonoBehaviour
{

    public GameObject[] Train;
    float span = 3.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var number = Random.Range(0, Train.Length);

        // フレーム毎に変数に値を入れてspanを超えたらインスタンスを生成する
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            // 生成する際にdeltaをリセットする
            this.delta = 0;
            
            GameObject go = Instantiate(Train[number]) as GameObject;

            // 出現範囲をランダムで生成
            int respawnRange = Random.Range(-7, 7);
            go.transform.position = new Vector3(respawnRange, 10, 0);

        }
    }
}
