
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Button playButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playButton != null) {
            playButton.onClick.AddListener(OnPlayButtonClicked);
        
        }

        
    }

    void OnPlayButtonClicked() {
        if (SceneHandler.instance != null)
        {
            SceneHandler.instance.LoadLevel1Scene();
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayAmbientSound();
            }
        }
        else {
            Debug.LogError("Scene Handler instance not found");
        }
    
    }
}
