using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWinScript : MonoBehaviour
{
  
  
  //Kazanma Ekranı Oyunu Tekrar Başlatma
  public void RestartGame(){
		SceneManager.LoadScene("Level-1");
	}
  //Kazanma Ekranı Ana Menüye Gitme
  public void MainMenuGame(){
		SceneManager.LoadScene("MainMenuScene");
	}
  //Kazanma Ekranı Oyundan Çıkma Komutu
  public void QuitGame(){
		Application.Quit();
	}
}
