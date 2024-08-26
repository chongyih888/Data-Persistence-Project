using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainUIHandler : MonoBehaviour
{
    public Text displayHighScoreText;
    public string nameOfPlayer;



    // Start is called before the first frame update
    void Start()
    {
        ValueManager.Instance.LoadInfo();

        if (ValueManager.Instance.highScore > 0)
        {
            nameOfPlayer = ValueManager.Instance.savedPlayerName;

        }
        else
        {
            nameOfPlayer = null;
        }

        DisplayHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayHighScoreText()
    {
        displayHighScoreText.text = "Best Score : " + nameOfPlayer + " : " + ValueManager.Instance.highScore;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
