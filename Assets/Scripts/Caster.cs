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
		updateNextShooter(true);
		bubbles = GameObject.Find("Bubbles");
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bubble = Instantiate(bubblePrefabs[curBubbleColor], transform.position, Quaternion.identity) as GameObject;
			bubble.transform.SetParent(bubbles.transform);
			bubble.GetComponent<Bubble>().Shooter();
			updateNextShooter(false);
		}
	}
	
	void updateNextShooter(bool initial)
	{
		if(initial)
		{
			curBubbleColor = Random.Range(0,5);
		}
		else
		{
			curBubbleColor = nextBubbleColor;
		}
		
		foreach(GameObject shooter in bubbleShooters)
		{
			shooter.SetActive(false);
		}
		bubbleShooters[curBubbleColor].SetActive(true);
		
		nextBubbleColor = Random.Range(0,5);
		foreach(GameObject icon in bubbleIcons)
		{
			icon.SetActive(false);
		}
		bubbleIcons[nextBubbleColor].SetActive(true);
	}
}
