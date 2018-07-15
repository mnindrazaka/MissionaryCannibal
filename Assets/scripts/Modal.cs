using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
  public GameObject modal;
  public GameObject instruction;
  public GameObject gameover;
  public GameObject win;

  public Text winTime;

  public Timer timer;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    modal.SetActive(true);
    instruction.SetActive(true);
    gameover.SetActive(false);
    win.SetActive(false);
    timer.isPaused = true;
  }

  public void Play()
  {
    modal.SetActive(false);
    instruction.SetActive(false);
    gameover.SetActive(false);
    win.SetActive(false);
    timer.isPaused = false;
  }

  public void Instruction()
  {
    modal.SetActive(true);
    instruction.SetActive(true);
    gameover.SetActive(false);
    win.SetActive(false);
    timer.isPaused = true;
  }

  public void Gameover()
  {
    modal.SetActive(true);
    instruction.SetActive(false);
    gameover.SetActive(true);
    win.SetActive(false);
    timer.isPaused = true;
  }

  public void Win()
  {
    modal.SetActive(true);
    instruction.SetActive(false);
    gameover.SetActive(false);
    win.SetActive(true);
    timer.isPaused = true;
    winTime.text = timer.GetTime();
  }

  public void Retry()
  {
    SceneManager.LoadScene("level1");
  }
}
