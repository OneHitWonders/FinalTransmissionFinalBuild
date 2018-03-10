using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private SceneLoader sceneload;
    private GameInstance instance;

    public Text txtUsername;

    public Button btnPlay;
    public Button btnQuit;
    public Button btnDelete;
    // Use this for initialization

    void Start()
    {

        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            instance = gameController.GetComponent<GameInstance>();
            txtUsername.text = instance.UserProfile.Username;

            btnPlay.onClick.AddListener(StartGame);
            btnQuit.onClick.AddListener(QuitGame);
            btnDelete.onClick.AddListener(DeleteProfileAndRestart);

        }

    }


    private void StartGame()
    {
        instance.LoadScene("OverviewMap");
    }

    private void QuitGame()
    {
        instance.Quit();
    }

    private void DeleteProfileAndRestart()
    {
        instance.DeleteProfile();
        instance.LoadScene("createprofile");
    }


}
