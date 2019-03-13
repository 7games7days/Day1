using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour {
	public static int Score;
	public static int lives;
	public TextMeshProUGUI pointsText;
	public TextMeshProUGUI lifeText;
	bool alive = true;
	public GameObject panel;
	
	// Use this for initialization
	void Start () {
		lives = 3;
	}
	public void Restart(){
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}
	// Update is called once per frame
	void Update () {
		pointsText.text = "Points: "+Score;
		lifeText.text = "Lives: "+lives;
		if(lives <= 0&&alive){
			alive = false;
			panel.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
