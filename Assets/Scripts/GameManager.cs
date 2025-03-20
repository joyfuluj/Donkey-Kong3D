using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private TextMeshProUGUI gameOver;

    [SerializeField] private PlayerController mario; //referring to the mario character
    [SerializeField] private Barrel barrel;
    private void OnEnable()
    {
        //Update the array of hearts
        UpdateHeartsUI();
        gameOver.gameObject.SetActive(false); // Hide the Game Over text initially
    }
    public void RemoveLife()
    {
        maxLives--;
        UpdateHeartsUI();
        // game over UI if maxLives < 0, then exit to main menu after delay
        if (maxLives <= 0)
        {
            // Show Game Over text and return to the main menu after a delay
            StartCoroutine(GameOverSequence());
        }
        else
        {
            mario.ResetPosition();
        }


    }
    private void UpdateHeartsUI()
    {
        // Loop through the hearts array and enable/disable hearts based on maxLives
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < maxLives);
        }
    }

    private IEnumerator GameOverSequence()
    {
        Time.timeScale = 0f; //freezing the time

        // Show the Game Over UI
        gameOver.gameObject.SetActive(true);

        // Wait for 1.5 seconds
        yield return new WaitForSecondsRealtime(1.5f);

        // Unfreeze time and transition to the main menu
        Time.timeScale = 1f;
        
        // Handle Next Scene
        Debug.Log("Back to Main Menu");
        // SceneHandler.Instance.LoadMenuScene();
    }
}
