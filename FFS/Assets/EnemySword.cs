using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {

	// Use this for initialization
	public EnemyMove move;
	void Start () {
		move = transform.parent.gameObject.GetComponent<EnemyMove>();
	}
	
	// Update is called once per frame

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		move.Stop();
		if(other.collider.gameObject.CompareTag("Player")){
			
				ScoreKeeper.lives--;
		}
	}
}
