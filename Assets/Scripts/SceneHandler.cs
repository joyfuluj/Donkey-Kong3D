using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance { get; private set; }

    public void Awake()
    {
        // Singleton pattern to ensure only one SceneHandler Exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes


        }
        else {
            Destroy(gameObject);
        
        }
    
    
    
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    
    }
    public void LoadLevel1Scene()
    {
        SceneManager.LoadScene(1);

    }
    public void LoadWinScene()
    {
        SceneManager.LoadScene(2);

    }

}
