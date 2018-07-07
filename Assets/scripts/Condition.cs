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
    int missionaryNumber = RightLandClass().GetMissionaryNumber();
    int cannibalNumber = RightLandClass().GetCannibalNumber();

    if (missionaryNumber + cannibalNumber == 4)
      Debug.Log("Win");
  }

  void CheckLose()
  {
    int leftMissionaryNumber = LeftLandClass().GetMissionaryNumber();
    int leftCannibalNumber = LeftLandClass().GetCannibalNumber();

    int rightMissionaryNumber = RightLandClass().GetMissionaryNumber();
    int rightCannibalNumber = RightLandClass().GetCannibalNumber();

    if (leftMissionaryNumber < leftCannibalNumber && BoatClass().players.Count == 0)
      Debug.Log("Lose");

    if (rightMissionaryNumber < rightCannibalNumber && BoatClass().players.Count == 0)
      Debug.Log("Lose");
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
