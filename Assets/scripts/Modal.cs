using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
  public GameObject modal;
  public GameObject instructionPanel;
  public GameObject highScorePanel;
  public GameObject gameoverPanel;
  public GameObject winPanel;

  public Text winText;

  public Text highScoreText;

  public Timer timer;

  void Start()
  {
    ShowInstruction();
  }
  public void ShowInstruction()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(true);
    highScorePanel.SetActive(false);
    gameoverPanel.SetActive(false);
    winPanel.SetActive(false);
    timer.isPaused = true;
  }

  public void ShowHighScore()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(false);
    highScorePanel.SetActive(true);
    gameoverPanel.SetActive(false);
    winPanel.SetActive(false);
    timer.isPaused = true;
  }

  public void ShowGameover()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(false);
    highScorePanel.SetActive(false);
    gameoverPanel.SetActive(true);
    winPanel.SetActive(false);
    timer.isPaused = true;
  }

  public void ShowWin()
  {
    modal.SetActive(true);
    instructionPanel.SetActive(false);
    highScorePanel.SetActive(false);
    gameoverPanel.SetActive(false);
    winPanel.SetActive(true);
    timer.isPaused = true;
    winText.text = timer.GetTime();
  }

  public void Play()
  {
    modal.SetActive(false);
    instructionPanel.SetActive(false);
    highScorePanel.SetActive(false);
    gameoverPanel.SetActive(false);
    winPanel.SetActive(false);
    timer.isPaused = false;
  }

  public void Retry(string scene)
  {
    SceneManager.LoadScene(scene);
  }
}
