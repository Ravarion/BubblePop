using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {
	
	public bool popped = false;
	public bool isShooter = false;
	public bool cursed = false;
	
	private float speed = 0.05f;
	private float lastUpdate = 0f;
	private float hitCountDown = 0f;
	private bool move = true;
	private bool countingDown = false;
	
	private List<GameObject> touching = new List<GameObject>();
	
	void Awake()
	{
		lastUpdate = Time.time;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(move && touching.Count < 2)
		{
			transform.position = Vector2.MoveTowards(transform.position, transform.parent.position, Time.deltaTime * speed);
			if(cursed)
			{
				transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.parent.position.x+Random.Range(-0.8f,0.8f), transform.parent.position.y+Random.Range(-0.8f,0.8f)), Time.deltaTime*speed);
			}
			if(isShooter && hitCountDown < 0 && countingDown)
			{
				GameObject.Find("Bubbles").GetComponent<BubbleGen>().BreakMultiplier();
				isShooter = false;
				countingDown = false;
				speed = 0.05f;
			}
			if(countingDown)
			{
				hitCountDown -= Time.deltaTime;
			}
		}
		if(Mathf.Abs(transform.position.x) > 0.85f || Mathf.Abs (transform.position.y) > 0.85f)
		{
			LoseGame();
		}
	}
	
	private void LoseGame()
	{
		GameObject.Find("Bubbles").GetComponent<BubbleGen>().LoseGame();
	}
	
	private void AddScore(int combo)
	{
		GameObject.Find("Bubbles").GetComponent<BubbleGen>().AddScore(combo);
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
				GameObject.Find("Bubbles").GetComponent<BubbleGen>().AddMultiplier();
				Pop(0);
			}
			else
			{
				if(!(hitCountDown > 0))
				{
					hitCountDown = 1f;
					countingDown = true;
					speed = 0.05f;
				}
			}
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		touching.Remove(collision.gameObject);
	}
	
	public void Pop(int combo)
	{
		combo++;
		popped = true;
		foreach(GameObject bubble in touching)
		{
			if(bubble.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
			{
				if(!bubble.GetComponent<Bubble>().popped)
				{
					bubble.GetComponent<Bubble>().Pop(combo);
				}
			}
		}
		AddScore(combo);
		Destroy(gameObject);
	}
}
