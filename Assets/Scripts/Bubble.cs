using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Bubble : MonoBehaviour {
	
	public Canvas scorePlusCanvas;
	
	public bool popped = false;
	public bool isShooter = false;
	public bool cursed = false;
	
	private BubbleGen bubbleGen;
	private GameObject bubbleArena;
	
	private float speed = 0.05f;
	private float hitCountDown = 0f;
	private bool move = true;
	private bool countingDown = false;
	
	private List<GameObject> sameTouching = new List<GameObject>();
	private List<GameObject> otherTouching = new List<GameObject>();
	
	void Awake()
	{
		bubbleGen = GameObject.Find("Bubbles").GetComponent<BubbleGen>();
		bubbleArena = GameObject.Find("InnerArea");
	}
	
	// Update is called once per frame
	void Update()
	{
		if(move && sameTouching.Count < 2)
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
			if(Vector3.Distance(transform.position, Vector3.zero) > 0.88)
			{
				LoseGame();
			}
		}
	}
	
	public void Break()
	{
		Destroy(gameObject);
	}
	
	private void LoseGame()
	{
		bubbleGen.LoseGame();
	}
	
	private void AddScore(int combo)
	{
		bubbleGen.AddScore(combo);
	}
	
	public void Shooter()
	{
		isShooter = true;
		speed = 1f;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Bubble")
		{
			if(collision.transform.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
			{
				sameTouching.Add(collision.gameObject);
			}
			else
			{
				otherTouching.Add(collision.gameObject);
			}
			if(isShooter)
			{
				if(collision.transform.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
				{
					bubbleGen.AddMultiplier();
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
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.transform.GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
		{
			sameTouching.Remove(collision.gameObject);
		}
		else
		{
			otherTouching.Remove(collision.gameObject);
		}
	}
	
	public bool Contains(Bubble bubble)
	{
		if(sameTouching.Contains(bubble.gameObject))
		{
			return true;
		}
		else if(otherTouching.Contains(bubble.gameObject))
		{
			return true;
		}
		return false;
	}
	
	public void Remove(Bubble bubble)
	{
		if(sameTouching.Contains(bubble.gameObject))
		{
			sameTouching.Remove(bubble.gameObject);
		}
		else if(otherTouching.Contains(bubble.gameObject))
		{
			otherTouching.Remove(bubble.gameObject);
		}
	}
	
	public void Pop(int combo)
	{
		combo++;
		//GameObject scorePlus = Instantiate(scorePlusCanvas, transform.position, Quaternion.identity) as GameObject;
		//scorePlus.GetComponent<ScorePlusScript>().SetScore(combo*bubbleGen.multiplier);
		popped = true;
		for(int i = 0; i < sameTouching.Count; i++)
		{
			if(sameTouching[i] != null)
			{
				if(sameTouching[i].GetComponent<SpriteRenderer>().color == transform.GetComponent<SpriteRenderer>().color)
				{
					if(!sameTouching[i].GetComponent<Bubble>().popped)
					{
						sameTouching[i].GetComponent<Bubble>().Pop(combo);
					}
				}
			}
		}
		if(bubbleGen.gameMode == "Panic")
		{
			for(int i = 0; i < otherTouching.Count; i++)
			{
				if(otherTouching[i] != null)
				{
					if(otherTouching[i].GetComponent<Bubble>().sameTouching.Count > 0)
					{
						if(!otherTouching[i].GetComponent<Bubble>().popped)
						{
							otherTouching[i].GetComponent<Bubble>().Pop(combo);
						}
					}
				}
			}
		}
		AddScore(combo);
		Destroy(gameObject);
	}
}
