using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject main_menu;
    public GameObject pause_menu;
	public GameObject gameOver_menu; 
    public GameObject pause_button;
    public GameObject player;

    private PlayerController pc;
    // Use this for initialization
    void Start () {
        pc = player.gameObject.GetComponent<PlayerController>();
	}

	void Update(){
		if (!pc.alive) {
			GameOver (true);
		}
	}

    public void StartGame() {
        if (main_menu != null) {
			//Sets the main menu to inactive (disappears)
            main_menu.gameObject.SetActive(false);
			//Sets the pause button to true meaning it'll appear when the game starts
            pause_button.gameObject.SetActive(true);
            pc.startGame = true;
        } else {
            Debug.Log("main_menu has no reference to the Main Menu Panel.");
        }
    }

    public void Pause(bool active) {
        if (pause_menu != null) {
            pause_menu.gameObject.SetActive(active);
            pause_button.gameObject.SetActive(!active);
            Time.timeScale = (!active) ? 1 : 0;
        } else {
            Debug.Log("pause_menu has no reference to the Pause Menu Panel.");
        }
    }

	public void GameOver(bool active){
		if (gameOver_menu != null) {
			pause_button.gameObject.SetActive (!active);
			gameOver_menu.gameObject.SetActive (active);
		} else {
			Debug.Log("gameOver_menu has no reference to the Game Over Menu Panel.");
		}
	}

	public void loadScene(string scene){
		Application.LoadLevel (scene);
	}

}
