using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private SceneLoader sceneload;

    public Button btnPlay;
    public Button btnQuit;
    public Button btnDelete;
    // Use this for initialization

    void Start()
    {

        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {
            sceneload = gameController.GetComponent<SceneLoader>();

            btnPlay.onClick.AddListener(StartGame);
          
        }

    }


    private void StartGame()
    {
        SceneManager.LoadScene("OverviewMap");
    }



}
