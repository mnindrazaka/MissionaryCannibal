using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
  public bool isOnRight = false;
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
    if (players.Count > 0)
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
}
