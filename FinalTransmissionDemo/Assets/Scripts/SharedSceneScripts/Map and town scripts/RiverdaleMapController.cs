using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RiverdaleMapController : MonoBehaviour {

    public Button OverviewButton;
    public Button RiverdaleMansion;
    GameInstance instance;


	void Start () {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");

        if (gameController != null)
        {

            instance = gameController.GetComponent<GameInstance>();

            OverviewButton.onClick.AddListener(LoadOverview);
            RiverdaleMansion.onClick.AddListener(LoadRiverdaleMansion);
        }
		
	}

    private void LoadOverview()
    {
        SceneManager.LoadScene("OverviewMap");
    }

    private void LoadRiverdaleMansion()
    {
        SceneManager.LoadScene("Riverdale Mansion");
    }
   
}
