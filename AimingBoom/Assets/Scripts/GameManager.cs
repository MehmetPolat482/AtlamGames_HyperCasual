using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> targets;
	private float spawnRate = 2f ;
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	public TextMeshProUGUI youWinText;
	public TextMeshProUGUI yourScoreText;
	private int score;
	public Button restartButton;
	public Button mainMenuButton;
	
	public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {

			 
		if (PlayerPrefs.HasKey("score"))  
		{
		score = PlayerPrefs.GetInt("score"); 
		scoreText.text = "Score : " + score ;
		}
	
		isGameActive = true;
		
		StartCoroutine(SpawnTarget());
		UptadeScore(0);

		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	IEnumerator SpawnTarget(){
			while(isGameActive) {
				
				yield return new WaitForSeconds(spawnRate);
				int index = Random.Range (0 , targets.Count);
				Instantiate(targets[index]);
				
			}
			
	}
	
	public void UptadeScore(int scoreAdd){
		score += scoreAdd;
		 scoreText.text = "Score : " + score.ToString();
		 PlayerPrefs.SetInt("score", score); 
		 scoreText.text = "Score : " + score;
		 
		WinScene();
	}
		
		
	
	public static void DeleteAll(){
		PlayerPrefs.DeleteAll();
	}
	
	public void GameOver(){
		
		restartButton.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		yourScoreText.gameObject.SetActive(true);
		mainMenuButton.gameObject.SetActive(true);
		isGameActive = false;
		yourScoreText.text= scoreText.text + " POINTS";
	}
	public void WinScene(){
		if(score > 2000){
			isGameActive=false;
			restartButton.gameObject.SetActive(true);
			mainMenuButton.gameObject.SetActive(true);
			youWinText.gameObject.SetActive(true);
			yourScoreText.gameObject.SetActive(true);
			yourScoreText.text= scoreText.text + " POINTS";
	}
		
	}
	
	public void RestartGame(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		DeleteAll();

	}
	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
	
	
}
