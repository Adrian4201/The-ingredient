using RogueEngine;
using RogueEngine.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SettingScripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioClip[] music;
    public UIPanel Settingpanel;
    void Start()
    {
        
        Settingpanel.Toggle(false);
    }

    // Update is called once per frame
    public void Update()
    {
      
        if (KeyInput.IsKeyPress(Key.Escape))
        {
            Debug.Log("stop hitting me");
            Settingpanel.Toggle(true);
        }   
    }

    public void OnButtonClick()
    {
        Application.Quit();
    }
}
