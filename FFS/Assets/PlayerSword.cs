using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour {

	// Use this for initialization
	public PlayerMove move;
	void Start () {
		move = transform.parent.gameObject.GetComponent<PlayerMove>();
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
		if(other.collider.gameObject.CompareTag("Enemy")){
			GameObject.Destroy(other.collider.gameObject);
				ScoreKeeper.Score++;
		}
	}
}
