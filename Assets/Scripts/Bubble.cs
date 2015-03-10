using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	
	private float speed = 0.05f;
	private float lastUpdate = 0f;
	private bool move = true;
	private bool isShooter = false;
	
	void Awake()
	{
		lastUpdate = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(move)
		{
			transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, Time.deltaTime * speed);
			if(Time.time - lastUpdate > 3f)
			{
				speed = 0.05f;
			}
		}
	}
	
	public void Shooter()
	{
		isShooter = true;
		speed = 0.5f;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(isShooter)
		{
			move = false;
		}
	}
}
