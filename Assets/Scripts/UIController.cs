using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject main_menu;
    public GameObject pause_menu;
    public GameObject pause_button;

    // Use this for initialization
    void Start () {
		
	}

    public void StartGame() {
        if (main_menu != null) {
            main_menu.gameObject.SetActive(false);
            pause_button.gameObject.SetActive(true);
        } else {
            Debug.Log("main_menu has no reference to the Main Menu Panel.");
        }
    }

    public void Pause(bool active) {
        if (pause_menu != null) {
            pause_menu.gameObject.SetActive(active);
            pause_button.gameObject.SetActive(!active);
        } else {
            Debug.Log("pause_menu has no reference to the Main Menu Panel.");
        }
    }
}
