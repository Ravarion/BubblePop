using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BubbleGen : MonoBehaviour {
	
	public int initialSpawnNum = 15;
	public int score = 0;
	public int multiplier = 1;
	
	public string gameState = "Playing"; //Other options: "Menu","GameOver",etc...
	
	public GameObject redBubble;
	public GameObject blueBubble;
	public GameObject yellowBubble;
	public GameObject purpleBubble;
	public GameObject greenBubble;
	
	private Text scoreText;
	
	private float spawnLatency = 1f;
	private float lastSpawn = 0f;
	private float rotationSpeed = 1f;
	
	private List<GameObject> bubbles = new List<GameObject>();
	
	void Awake()
	{
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		lastSpawn = Time.time;
		bubbles.Add(redBubble);
		bubbles.Add(blueBubble);
		bubbles.Add(yellowBubble);
		bubbles.Add(purpleBubble);
		bubbles.Add(greenBubble);
		SpawnInitial();
	}
	
	// Update is called once per frame
	void Update()
	{
		//transform.Rotate(new Vector3(0,0,rotationSpeed));
		if(Time.time - lastSpawn > spawnLatency * (1f-multiplier/100f))
		{
			//rotationSpeed = Random.Range(-1.0f,1.0f);
			lastSpawn = Time.time;
			int color = Random.Range(0, 5);
			GameObject bubble = Instantiate(bubbles[color], transform.position, Quaternion.identity) as GameObject;
			bubble.transform.SetParent(this.transform);
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			AddMultiplier();
		}
	}
	
	public void LoseGame()
	{
		if(gameState == "Playing")
		{
			gameState = "GameOver";
		}
	}
	
	public void StartGame()
	{
		gameState = "Playing";
	}
	
	public void AddScore(int combo)
	{
		score += combo * multiplier;
		scoreText.text = "Score: " + score + "\n" + "Multiplier: " + multiplier +"x";
	}
	
	public void AddMultiplier()
	{
		multiplier++;
		if(multiplier >= 99)
		{
			multiplier = 99;
		}
		scoreText.text = "Score: " + score + "\n" + "Multiplier: " + multiplier +"x";
	}
	
	public void BreakMultiplier()
	{
		multiplier = 0;
		scoreText.text = "Score: " + score + "\n" + "Multiplier: " + multiplier +"x";
	}
	
	void SpawnInitial()
	{
		for(int i = 0; i < initialSpawnNum; i++)
		{
			int color = Random.Range(0, 5);
			GameObject bubble = Instantiate(bubbles[color], transform.position + new Vector3(Random.Range(-0.1f,0.1f),Random.Range(-0.1f,0.1f),0), Quaternion.identity) as GameObject;
			bubble.transform.SetParent(this.transform);
		}
	}
}
