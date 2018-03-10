using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverviewMapController : MonoBehaviour
{
    //create a game instance in future build
    private SceneLoader sceneload;
    public GameInstance instance;




    public Button HomeBtn;
    public Button RiverdaleBtn;



    // Use this for initialization
    void Start()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {

            instance = gameController.GetComponent<GameInstance>();

            RiverdaleBtn.onClick.AddListener(LoadRiverdale);
            HomeBtn.onClick.AddListener(LoadHomeBase);

        }

    }

    // load areas on the map.
    private void LoadRiverdale()
    {
        SceneManager.LoadScene("RiverdaleMap");
    }

    private void LoadHomeBase()
    {
        SceneManager.LoadScene("BaseScene");
    }



}

