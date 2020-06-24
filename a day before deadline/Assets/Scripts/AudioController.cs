using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // 音を管理するスクリプト

    private AudioSource bgm1;
    private AudioSource bgm2;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        bgm1 = GameObject.Find("BGM1").GetComponent<AudioSource>();
        bgm2 = GameObject.Find("BGM2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentStage == GameManager.GameStage.Stage3)
        {
            bgm1.enabled = false;
            bgm2.enabled = true;
        }
        else
        {
            bgm1.enabled = true;
            bgm2.enabled = false;
        }
    }
}
