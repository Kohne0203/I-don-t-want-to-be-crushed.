using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    GameObject timeUi;
    GameObject gameUi;
    float time = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.timeUi = GameObject.Find("RunTime");
        this.gameUi = GameObject.Find("Current Stage");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.time += Time.deltaTime;
        this.timeUi.GetComponent<Text>().text = this.time.ToString("F1") + "s";
    }
}
