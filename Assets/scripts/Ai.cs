using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
  private List<string> operators;

  private List<State> moves;

  private bool isOnRight = false;

  private Boat boat;
  private Land leftLand;
  private Land rightLand;

  void Start()
  {
    Initialize();
    FindingMoves();
    // foreach (State move in moves)
    //   Debug.Log(move.op);
  }

  void Initialize()
  {
    boat = GameObject.Find("Boat").GetComponent<Boat>();
    leftLand = GameObject.Find("LeftLand").GetComponent<Land>();
    rightLand = GameObject.Find("RightLand").GetComponent<Land>();

    moves = new List<State>();
    moves.Add(new State(3, 3, 0, 0, false));

    operators = new List<string>();
    operators.Add("MM");
    operators.Add("CC");
    operators.Add("MC");
    operators.Add("M");
    operators.Add("C");
  }

  void FindingMoves()
  {
    while (!GetLastMove().isGoal())
    {
      isOnRight = !isOnRight;
      foreach (string op in operators)
      {
        State move = MakeMove(op);
        if (move.isValid() && IsMoveUnique(move))
        {
          moves.Add(move);
          break;
        }
      }
    }
  }

  State GetLastMove()
  {
    return moves[moves.Count - 1];
  }

  State MakeMove(string op)
  {
    int originMissionary = 0;
    int originCannibal = 0;
    int targetMissionary = 0;
    int targetCannibal = 0;

    if (isOnRight)
    {
      originMissionary = GetLastMove().missionaryLeft;
      originCannibal = GetLastMove().cannibalLeft;
      targetMissionary = GetLastMove().missionaryRight;
      targetCannibal = GetLastMove().cannibalRight;
    }
    else
    {
      originMissionary = GetLastMove().missionaryRight;
      originCannibal = GetLastMove().cannibalRight;
      targetMissionary = GetLastMove().missionaryLeft;
      targetCannibal = GetLastMove().cannibalLeft;
    }

    switch (op)
    {
      case "MM":
        originMissionary -= 2;
        targetMissionary += 2;
        break;
      case "CC":
        originCannibal -= 2;
        targetCannibal += 2;
        break;
      case "MC":
        originMissionary -= 1;
        targetMissionary += 1;

        originCannibal -= 1;
        targetCannibal += 1;
        break;
      case "M":
        originMissionary -= 1;
        targetMissionary += 1;
        break;
      case "C":
        originCannibal -= 1;
        targetCannibal += 1;
        break;
    }

    if (isOnRight)
    {
      return new State(originMissionary, originCannibal, targetMissionary, targetCannibal, isOnRight, op);
    }
    else
    {
      return new State(targetMissionary, targetCannibal, originMissionary, originCannibal, isOnRight, op);
    }
  }

  bool IsMoveUnique(State move)
  {
    bool isUnique = true;

    foreach (State item in moves)
    {
      if (item.cannibalLeft == move.cannibalLeft && item.cannibalRight == move.cannibalRight && item.missionaryLeft == move.missionaryLeft && item.missionaryRight == move.missionaryRight && item.isOnRight == move.isOnRight)
      {
        isUnique = false;
        break;
      }
    }

    return isUnique;
  }

  public void HandleMoves()
  {
    StartCoroutine(DoingMoves());
  }

  IEnumerator DoingMoves()
  {
    foreach (State move in moves)
    {
      if (move.op != null)
      {
        switch (move.op)
        {
          case "MM":
            GetLand(move.isOnRight).GetMissionary().GetOnBoat();
            yield return new WaitForSeconds(1);
            GetLand(move.isOnRight).GetMissionary().GetOnBoat();
            break;
          case "CC":
            GetLand(move.isOnRight).GetCannibal().GetOnBoat();
            yield return new WaitForSeconds(1);
            GetLand(move.isOnRight).GetCannibal().GetOnBoat();
            break;
          case "MC":
            GetLand(move.isOnRight).GetMissionary().GetOnBoat();
            yield return new WaitForSeconds(1);
            GetLand(move.isOnRight).GetCannibal().GetOnBoat();
            break;
          case "M":
            GetLand(move.isOnRight).GetMissionary().GetOnBoat();
            break;
          case "C":
            GetLand(move.isOnRight).GetCannibal().GetOnBoat();
            break;
        }

        yield return new WaitForSeconds(1);
        if (move.isOnRight)
          boat.MoveRight();
        else
          boat.MoveLeft();

        boat.isOnRight = move.isOnRight;
        boat.ChangePlayerPosition(move.isOnRight);

        yield return new WaitForSeconds(4);
        // turunkan semua pemain
        if (boat.players.Count == 2)
        {
          Player playerClass = boat.players[0].GetComponent<Player>();
          playerClass.GetOffBoat();
          yield return new WaitForSeconds(1);
          playerClass = boat.players[0].GetComponent<Player>();
          playerClass.GetOffBoat();
        }
        else if (boat.players.Count == 1)
        {
          Player playerClass = boat.players[0].GetComponent<Player>();
          playerClass.GetOffBoat();
        }
        yield return new WaitForSeconds(1);
      }
    }
  }

  Land GetLand(bool isOnRight)
  {
    return isOnRight ? leftLand : rightLand;
  }
}
