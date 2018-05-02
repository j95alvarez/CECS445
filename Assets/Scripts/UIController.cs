using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField]
    private GameObject main_menu;

    [SerializeField]
    private GameObject pause_menu;

    [SerializeField]
    private GameObject gameOver_menu;

    [SerializeField]
    private GameObject pause_button;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject distance;

    [SerializeField]
    private GameObject spawn;

    [SerializeField]
    private AudioSource audio;

    private PlayerController pc;
    private EnemyController ec;
    private DistanceTracker dt;
    private WallSpawn ws;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Use this for initialization
    void Start () {
        pc = player.GetComponent<PlayerController>();
        ec = enemy.GetComponent<EnemyController>();
        dt = player.GetComponent<DistanceTracker>();
        ws = spawn.GetComponent<WallSpawn>();
	}

	void Update(){
		if (!pc.alive) {
			GameOver (true);
		}
	}

    public void StartGame() {
        if (main_menu != null) {
			//Sets the main menu to inactive (disappears)
            main_menu.SetActive(false);
			//Sets the pause button to true meaning it'll appear when the game starts
            pause_button.SetActive(true);
            pc.startGame = true;
            ec.startGame = true;
            dt.startGame = true;
            ws.startGame = true;
        } else {
            Debug.Log("main_menu has no reference to the Main Menu Panel.");
        }
    }

    public void Pause(bool active) {
        if (pause_menu != null) {
            pause_menu.SetActive(active);
            pause_button.SetActive(!active);
            Time.timeScale = (!active) ? 1 : 0;
        } else {
            Debug.Log("pause_menu has no reference to the Pause Menu Panel.");
        }
    }

	public void GameOver(bool active){
		if (gameOver_menu != null) {
			pause_button.SetActive (!active);
			gameOver_menu.SetActive (active);
		} else {
			Debug.Log("gameOver_menu has no reference to the Game Over Menu Panel.");
		}
	}

	public void loadScene(string scene){
        SceneManager.LoadScene(scene);
	}

    public void MuteSound() {
        audio.mute = !audio.mute;
    }

}
