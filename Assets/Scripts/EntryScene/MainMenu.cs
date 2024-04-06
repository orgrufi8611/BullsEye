using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TMP_InputField inputField;
    bool named = false;

    private void Update()
    {
        
    }

    public void GetName()
    {
        nameText.text = inputField.text;
    }
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
