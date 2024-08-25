using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField inputField;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        
        inputField.text = ValueManager.Instance.playerName;
        DisplayText();
    }

    // Update is called once per frame
    void Update()
    {

        ValueManager.Instance.playerName = inputField.text; 
    }

    public void StartNew()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

        
    }

    public void DisplayText()
    {
        displayText.text = "Best Score : " + ValueManager.Instance.playerName + " : " + ValueManager.Instance.highScore;
    }
}
