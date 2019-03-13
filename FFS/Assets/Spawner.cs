using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	public GameObject EnemyPreFab;
	public List<GameObject> enemies = new List<GameObject>();
	int enemyAmount;
	
	void Start () {
		for(float x = -35;x<35;x+=Random.Range(2.25f,15.5f)){
			for(float y = -35;y<35;y += Random.Range(2.25f,15.5f)){
				GameObject enemy = Instantiate(EnemyPreFab,new Vector3(x+Random.Range(-0.5f,0.5f),y+Random.Range(-0.5f,0.5f),0),Quaternion.identity);
				enemy.transform.Rotate(new Vector3(0,0,Random.Range(0,360)));
				enemies.Add(enemy);
			}
		}
		enemyAmount = enemies.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
