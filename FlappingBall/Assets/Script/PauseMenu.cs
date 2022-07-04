using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Değişkenler
    public  bool isPaused;
    public  GameObject pauseMenu ;


	void Start()
	{
		pauseMenu.SetActive(false);
	}
	
	//Oyunu Durdurma Menüsü
    public void PauseGame()
    {	
		pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true ;
    }
	// Oyunu Devam Ettirme
	public void  ResumeGame(){
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false ;
	}
	// Oyunu Tekrar Başlatma
	public void RestartGame(){
		SceneManager.LoadScene("Level-1");
		Time.timeScale = 1f;
	}
	// Ana Menüye Gitme
	public void MainMenu(){
		SceneManager.LoadScene("MainMenuScene");
	}
	
}
