using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
  public bool isOnRight = false;
  public bool isMoving = false;
  public List<GameObject> players;

  private Animator animator;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    players = new List<GameObject>();
    animator = GetComponent<Animator>();
  }

  public void AddPlayer(GameObject player)
  {
    if (players.Count < 2)
      players.Add(player);
  }

  public void RemovePlayer(GameObject player)
  {
    players.Remove(player);
  }

  public void HandleMovement()
  {
    if (players.Count > 0 && !isMoving)
    {
      if (isOnRight)
        MoveLeft();
      else
        MoveRight();

      isOnRight = !isOnRight;
      ChangePlayerPosition(isOnRight);
    }
  }

  void MoveLeft()
  {
    animator.SetTrigger("moveLeft");
  }

  void MoveRight()
  {
    animator.SetTrigger("moveRight");
  }

  void ChangePlayerPosition(bool isOnRight)
  {
    foreach (GameObject player in players)
    {
      player.GetComponent<Player>().isOnRight = isOnRight;
    }
  }

  public int GetMissionaryNumber()
  {
    int num = 0;
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Missionary"))
        num++;
    }
    return num;
  }

  public int GetCannibalNumber()
  {
    int num = 0;
    foreach (GameObject player in players)
    {
      if (player.CompareTag("Cannibal"))
        num++;
    }
    return num;
  }

  public void StartMoving()
  {
    isMoving = true;
  }

  public void StopMoving()
  {
    isMoving = false;
  }
}
