using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	private float RotateSpeed;
	private float RotateDir;
	Rigidbody2D rb;
	private float LungeSpeed;
	int LungeMulti;
	
	Vector2 targetPoint;
	
	bool moving;
	
	// Use this for initialization
	void Start () {
		RotateSpeed = 6.5f;
		RotateDir= 0;
		LungeSpeed = .5f;
		moving = false;
		LungeMulti = 5;
		targetPoint = transform.position;
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		RotateDir = -Input.GetAxis("Horizontal");
		if(Input.GetKeyDown(KeyCode.UpArrow)&&!moving){
			targetPoint= transform.position+transform.up*LungeMulti;
		}
		
	}
	public void Stop(){
		targetPoint=transform.position-transform.up;
		
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Stop();
		
	}
	void FixedUpdate()
	{
		if(Mathf.Abs(transform.position.x)>40){
			transform.position += new Vector3(-Mathf.Sign(transform.position.x)*70,0,0); 
			if(moving){
				targetPoint += new Vector2(-Mathf.Sign(targetPoint.x)*70,0);
			}
		}
		if(Mathf.Abs(transform.position.y)>40){
			transform.position += new Vector3(0,-Mathf.Sign(transform.position.y)*70,0); 
			if(moving){
				targetPoint += new Vector2(0,-Mathf.Sign(targetPoint.y)*70);
			}
		}
		if((Vector2) transform.position !=targetPoint){
			moving = true;
			transform.position = Vector2.MoveTowards(transform.position,targetPoint,LungeSpeed);
		}else{
			moving = false;
			gameObject.transform.Rotate(new Vector3(0,0,RotateDir*RotateSpeed));
		}
		
	}
}
