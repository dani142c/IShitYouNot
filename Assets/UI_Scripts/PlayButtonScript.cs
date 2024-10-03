using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour
{
    public GameObject playButton;  // Assign the Play Button GameObject in the Inspector

    public void PlayGame()
    {
        // Disable the Play Button to make it disappear
        playButton.SetActive(false);

        // Add your game start logic here
        // For example, you can activate other game objects or start spawning enemies
        StartGame();
    }

    void StartGame()
    {
        // Add the logic to start the game here
        // This could be enabling game objects, starting timers, etc.
        Debug.Log("Game Started!");
    }
}
