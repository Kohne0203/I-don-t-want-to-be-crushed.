using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static int CurrentStage;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void MoveStage()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        if (CurrentStage == 1)
        {
            SceneManager.LoadScene(loadScene.name);
        }
        else if (CurrentStage == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
