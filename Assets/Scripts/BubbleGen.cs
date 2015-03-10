using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BubbleGen : MonoBehaviour {
	
	public GameObject redBubble;
	public GameObject blueBubble;
	public GameObject yellowBubble;
	public GameObject purpleBubble;
	public GameObject greenBubble;
	
	private float spawnLatency = 5f;
	private float lastSpawn = 0f;
	private float rotationSpeed = 1f;
	
	private List<GameObject> bubbles = new List<GameObject>();
	
	void Awake()
	{
		lastSpawn = Time.time;
		bubbles.Add(redBubble);
		bubbles.Add(blueBubble);
		bubbles.Add(yellowBubble);
		bubbles.Add(purpleBubble);
		bubbles.Add(greenBubble); 
	}	
	
	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0,0,rotationSpeed));
		if(Time.time - lastSpawn > spawnLatency)
		{
			rotationSpeed = Random.Range(-1.0f,1.0f);
			lastSpawn = Time.time;
			int color = Random.Range(0, 5);
			GameObject bubble = Instantiate(bubbles[color], transform.position, Quaternion.identity) as GameObject;
			bubble.transform.SetParent(this.transform);
		}
	}
}
