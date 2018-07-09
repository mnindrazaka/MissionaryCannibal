using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modal : MonoBehaviour
{
  GameObject modal;
  GameObject instruction;
  GameObject gameover;
  GameObject win;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    modal = GameObject.Find("Modal");
    instruction = GameObject.Find("Instruction");
    gameover = GameObject.Find("Gameover");
    win = GameObject.Find("Win");

    modal.SetActive(true);
    instruction.SetActive(true);
    gameover.SetActive(false);
    win.SetActive(false);
  }

  public void Play()
  {
    modal.SetActive(false);
    instruction.SetActive(false);
    gameover.SetActive(false);
    win.SetActive(false);
  }

  public void Instruction()
  {
    modal.SetActive(true);
    instruction.SetActive(true);
    gameover.SetActive(false);
    win.SetActive(false);
  }

  public void Gameover()
  {
    modal.SetActive(true);
    instruction.SetActive(false);
    gameover.SetActive(true);
    win.SetActive(false);
  }

  public void Win()
  {
    modal.SetActive(true);
    instruction.SetActive(false);
    gameover.SetActive(false);
    win.SetActive(true);
  }

  public void Retry()
  {
    SceneManager.LoadScene("level1");
  }
}
