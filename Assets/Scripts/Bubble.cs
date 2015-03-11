using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {
	
	public bool popped = false;
	
	private float speed = 0.05f;
	private float lastUpdate = 0f;
	private bool move = true;
	
	public bool isShooter = false;
	
	private List<GameObject> touching = new List<GameObject>();
	
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
		speed = 1f;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
		{
			touching.Add(collision.gameObject);
		}
		if(isShooter)
		{
			if(collision.transform.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
			{
				Pop();
			}
			else
			{
				isShooter = false;
				speed = 0.05f;
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		touching.Remove(collision.gameObject);
	}
	
	public void Pop()
	{
		popped = true;
		foreach(GameObject bubble in touching)
		{
			if(bubble.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
			{
				if(!bubble.GetComponent<Bubble>().popped)
				{
					bubble.GetComponent<Bubble>().Pop();
				}
			}
		}
		Destroy(gameObject);
	}
}
