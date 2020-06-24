using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableManager : MonoBehaviour
{
    // 各変数,プロパティをまとめるスクリプト

    public GameManager gameManager;
    
    // GameManager関連

    private int goalCount;
    private int stageNum;

    public int GoalCount
    {
        get {
            if (gameManager.currentStage == GameManager.GameStage.Stage1)
            {
                return 10;
            }
            else if (gameManager.currentStage == GameManager.GameStage.Stage2)
            {
                return 30;
            }
            else if (gameManager.currentStage == GameManager.GameStage.Stage3)
            {
                return 50;
            }
            else
            {
                return this.goalCount;
            }
        }
        private set { this.goalCount = value; }
    }

    public int StageNum
    {
        get
        {
            if (gameManager.currentStage == GameManager.GameStage.Stage1)
            {
                return 1;
            }
            else if (gameManager.currentStage == GameManager.GameStage.Stage2)
            {
                return 2;
            }
            else if (gameManager.currentStage == GameManager.GameStage.Stage3)
            {
                return 3;
            }
            else
            {
                return this.stageNum;
            }
        }
        private set { this.stageNum = value; }
    }

    // Player関連

    private float playerSpeed = 10.0f;

    public float PlayerSpeed
    {
        get
        {
            if (gameManager.currentStage == GameManager.GameStage.Stage2)
            {
                return 7.0f;
            }
            else if (gameManager.currentStage == GameManager.GameStage.Stage3)
            {
                return 5.0f;
            }

            return this.playerSpeed;
        }
        private set { this.playerSpeed = value; }
    }

    // FallingObject関連

    private float fallSpan = 3.0f;
    private int invokeTime = 3;
    private float fallSpeed = 5.0f;
    private float waitTime = 3.0f;

    public float FallSpan
    {
        get
        {
            float random = Random.Range(1.0f, 3.0f);
            return random;
        }
        private set { this.fallSpan = value; }
    }

    public int InvokeTime
    {
        get { return this.invokeTime; }
        private set { this.invokeTime = value; }
    }

    public float FallSpeed
    {
        get
        {
            if (gameManager.currentStage == GameManager.GameStage.Stage1)
            {
                float random = Random.Range(10.0f, 20.0f);
                return random;
            }

            return this.fallSpeed;
        }
        private set { this.fallSpeed = value; }
    }

    public float WaitTime
    {
        get
        {
            if (gameManager.currentStage != GameManager.GameStage.Stage1)
            {
                return 2.0f;
            }
            else
            {
                return this.waitTime;
            }
        }
        private set { this.waitTime = value; }
    }
}
