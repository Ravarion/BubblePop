using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Caster : MonoBehaviour {
	
	public GameObject redBubble;
	public GameObject blueBubble;
	public GameObject yellowBubble;
	public GameObject purpleBubble;
	public GameObject greenBubble;
	
	public GameObject redBubbleIcon;
	public GameObject blueBubbleIcon;
	public GameObject yellowBubbleIcon;
	public GameObject purpleBubbleIcon;
	public GameObject greenBubbleIcon;
	
	public GameObject redBubbleShooter;
	public GameObject blueBubbleShooter;
	public GameObject yellowBubbleShooter;
	public GameObject purpleBubbleShooter;
	public GameObject greenBubbleShooter;
	
	private GameObject bubbles;
	
	private List<GameObject> bubblePrefabs = new List<GameObject>();
	private List<GameObject> bubbleIcons = new List<GameObject>();
	private List<GameObject> bubbleShooters = new List<GameObject>();
	
	private int curBubbleColor = 0;
	private int nextBubbleColor = 0;
	
	void Awake()
	{
		bubblePrefabs.Add(redBubble);
		bubblePrefabs.Add(blueBubble);
		bubblePrefabs.Add(greenBubble);
		bubblePrefabs.Add(purpleBubble);
		bubblePrefabs.Add(yellowBubble);
		bubbleIcons.Add(redBubbleIcon);
		bubbleIcons.Add(blueBubbleIcon);
		bubbleIcons.Add(greenBubbleIcon);
		bubbleIcons.Add(purpleBubbleIcon);
		bubbleIcons.Add(yellowBubbleIcon);
		bubbleShooters.Add(redBubbleShooter);
		bubbleShooters.Add(blueBubbleShooter);
		bubbleShooters.Add(greenBubbleShooter);
		bubbleShooters.Add(purpleBubbleShooter);
		bubbleShooters.Add(yellowBubbleShooter);
		UpdateNextShooter(true);
		bubbles = GameObject.Find("Bubbles");
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
		{
			GameObject bubble = Instantiate(bubblePrefabs[curBubbleColor], transform.position, Quaternion.identity) as GameObject;
			bubble.transform.SetParent(bubbles.transform);
			bubble.GetComponent<Bubble>().Shooter();
			UpdateNextShooter(false);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Fire2"))
		{
			SwitchNextBubble();
		}
	}
	
	void SwitchNextBubble()
	{
		int switchColor = curBubbleColor;
		curBubbleColor = nextBubbleColor;
		nextBubbleColor = switchColor;
		ActivateBubbleIcons();
	}
	
	void UpdateNextShooter(bool initial)
	{
		if(initial)
		{
			curBubbleColor = Random.Range(0,5);
			nextBubbleColor = Random.Range(0,5);
		}
		else
		{
			curBubbleColor = nextBubbleColor;
			nextBubbleColor = Random.Range(0,5);
		}
		ActivateBubbleIcons();
	}
	
	void ActivateBubbleIcons()
	{
		foreach(GameObject shooter in bubbleShooters)
		{
			shooter.SetActive(false);
		}
		bubbleShooters[curBubbleColor].SetActive(true);
		
		foreach(GameObject icon in bubbleIcons)
		{
			icon.SetActive(false);
		}
		bubbleIcons[nextBubbleColor].SetActive(true);
	}
}
