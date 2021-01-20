using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //press play again and goes to start game
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    //press main menu and goes back to main menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
