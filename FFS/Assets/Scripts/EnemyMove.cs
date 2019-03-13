using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMove : MonoBehaviour
{

    public Transform target;
    private Rigidbody2D rb;
    public float speed;
    int LungeMulti = 5;
    float jumpCD;
    public float BaseJumpCD,RotateSpeed,ReactionTime,ActiveRange;
    Vector2 targetPoint;
	
	bool moving;

    float reaction;
    // Use this for initialization
    void Start()
    {
        jumpCD = 2;
		targetPoint = transform.position;
		moving = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

    // Update is called once per frame
    public void Stop(){
		targetPoint = transform.position-transform.up;
		moving = false;
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Stop();
		
	}
	void FixedUpdate()
    {

        Vector2 dir = (Vector2)target.position - rb.position;
        if (dir.magnitude < ActiveRange)
        {
            reaction-=1*Time.fixedDeltaTime;
			if (reaction <= 0&&!moving)
            {
                dir.Normalize();
                float rotateAmount = Vector3.Cross(dir, transform.up).z;
                transform.Rotate(new Vector3(0,0,-rotateAmount*RotateSpeed));
                if (Mathf.Abs(rotateAmount) < 0.1 && jumpCD <= 0)
                {
                    targetPoint = transform.position+transform.up*LungeMulti;
                    jumpCD = BaseJumpCD;
                }
                if (jumpCD > 0)
                {
                    jumpCD -= Time.fixedDeltaTime;
                }
            }
        }else{
			reaction= ReactionTime;
		}
		if(targetPoint!= (Vector2)transform.position){
			transform.position = Vector2.MoveTowards(transform.position,targetPoint,speed);
			moving = true;
		}else{
			moving = false;
		}
    }
}
