using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject timeUi;
    GameObject stageUi;
    float time = 0f;
    Color White = new Color(1, 1, 1, 1);
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.timeUi = GameObject.Find("RunTime");
        this.stageUi = GameObject.Find("Current Stage");

        Text timeText = this.timeUi.GetComponent<Text>();
        Text stageText = this.stageUi.GetComponent<Text>();
        timeText.color = White;
        stageText.color = White;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.time += Time.deltaTime;
        this.timeUi.GetComponent<Text>().text = this.time.ToString("F1") + "s";
    }
}
