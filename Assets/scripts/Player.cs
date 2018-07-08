using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private GameObject boat;
  private GameObject leftLand;
  private GameObject rightLand;

  private Light playerLight;

  private bool isOnBoat = false;
  public bool isOnRight = false;


  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    boat = GameObject.Find("Boat");
    leftLand = GameObject.Find("LeftLand");
    rightLand = GameObject.Find("RightLand");
    playerLight = GetComponentInChildren<Light>();
    playerLight.enabled = false;
  }

  void OnMouseOver()
  {
    playerLight.enabled = true;
  }

  void OnMouseExit()
  {
    playerLight.enabled = false;
  }

  void OnMouseDown()
  {
    HandleClick();
  }

  public void HandleClick()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0) && isOnBoat)
      GetOffBoat();
    else if (Input.GetKeyDown(KeyCode.Mouse0) && !isOnBoat)
      GetOnBoat();
  }

  public void GetOffBoat()
  {
    isOnBoat = false;
    GetBoatClass().RemovePlayer(gameObject);
    transform.parent = GetLand().transform;

    SetPosition(GetLand());
    GetLandClass().AddPlayer(gameObject);
  }

  void SetPosition(GameObject parent)
  {
    Slots slotsClass = parent.GetComponent<Slots>();
    int index = GetAvailableSlot(slotsClass);
    float x = slotsClass.slots[index].transform.localPosition.x;
    transform.localPosition = new Vector2(x, transform.localPosition.y);
  }

  int GetAvailableSlot(Slots slotsClass)
  {
    int index = 0;
    int i = 0;
    foreach (GameObject slot in slotsClass.slots)
    {
      Slot slotClass = slot.GetComponent<Slot>();
      if (slotClass.isAvailable)
      {
        index = i;
        break;
      }
      i++;
    }
    return index;
  }

  public void GetOnBoat()
  {
    if (IsBoatSameSide())
    {
      isOnBoat = true;
      transform.parent = boat.transform;

      SetPosition(boat);
      GetBoatClass().AddPlayer(gameObject);
      GetLandClass().RemovePlayer(gameObject);
    }
  }

  bool IsBoatSameSide()
  {
    return GetBoatClass().isOnRight == isOnRight;
  }

  GameObject GetLand()
  {
    return isOnRight ? rightLand : leftLand;
  }

  Land GetLandClass()
  {
    return GetLand().GetComponent<Land>();
  }

  Boat GetBoatClass()
  {
    return boat.GetComponent<Boat>();
  }
}