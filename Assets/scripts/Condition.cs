using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
  public GameObject boat;
  public GameObject leftLand;
  public GameObject rightLand;
  public Modal modal;

  void Update()
  {
    CheckWin();
    StartCoroutine(CheckLose());
  }

  void CheckWin()
  {
    int total = leftLand.GetComponent<Slots>().slots.Count;
    int missionaryNumber = RightLandClass().GetMissionaryNumber();
    int cannibalNumber = RightLandClass().GetCannibalNumber();

    if (missionaryNumber + cannibalNumber == total)
      modal.Win();
  }

  IEnumerator CheckLose()
  {
    int leftMissionaryNumber = LeftLandClass().GetMissionaryNumber();
    int leftCannibalNumber = LeftLandClass().GetCannibalNumber();
    if (!BoatClass().isOnRight)
    {
      leftMissionaryNumber += BoatClass().GetMissionaryNumber();
      leftCannibalNumber += BoatClass().GetCannibalNumber();
    }

    int rightMissionaryNumber = RightLandClass().GetMissionaryNumber();
    int rightCannibalNumber = RightLandClass().GetCannibalNumber();
    if (BoatClass().isOnRight)
    {
      rightMissionaryNumber += BoatClass().GetMissionaryNumber();
      rightCannibalNumber += BoatClass().GetCannibalNumber();
    }

    if (IsMissionaryLessThanCannibal(leftMissionaryNumber, leftCannibalNumber))
    {
      yield return new WaitForSeconds(2.5f);
      modal.Gameover();
    }

    if (IsMissionaryLessThanCannibal(rightMissionaryNumber, rightCannibalNumber))
    {
      yield return new WaitForSeconds(2.5f);
      modal.Gameover();
    }
  }

  bool IsMissionaryLessThanCannibal(int missionary, int cannibal)
  {
    if (missionary < cannibal && missionary > 0)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  Boat BoatClass()
  {
    return boat.GetComponent<Boat>();
  }

  Land LeftLandClass()
  {
    return leftLand.GetComponent<Land>();
  }

  Land RightLandClass()
  {
    return rightLand.GetComponent<Land>();
  }
}
