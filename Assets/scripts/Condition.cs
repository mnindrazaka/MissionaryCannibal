using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
  private GameObject boat;
  private GameObject leftLand;
  private GameObject rightLand;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    boat = GameObject.Find("Boat");
    leftLand = GameObject.Find("LeftLand");
    rightLand = GameObject.Find("RightLand");
  }

  void Update()
  {
    CheckWin();
    CheckLose();
  }

  void CheckWin()
  {
    int total = leftLand.GetComponent<Slots>().slots.Count;
    int missionaryNumber = RightLandClass().GetMissionaryNumber();
    int cannibalNumber = RightLandClass().GetCannibalNumber();

    if (missionaryNumber + cannibalNumber == total)
      Debug.Log("Win");
  }

  void CheckLose()
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
      Debug.Log("Lose");

    if (IsMissionaryLessThanCannibal(rightMissionaryNumber, rightCannibalNumber))
      Debug.Log("Lose");
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
