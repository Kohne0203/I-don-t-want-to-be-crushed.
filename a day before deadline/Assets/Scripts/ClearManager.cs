using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        backButton.onClick.AddListener(BackToTitle);
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
