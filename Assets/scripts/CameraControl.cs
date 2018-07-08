using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  private Camera mainCamera;
  private Camera leftCamera;
  private Camera rightCamera;
  private Camera boatCamera;
  private bool isUsingMainCamera = false;

  private Boat boat;

  void Start()
  {
    Initialize();
  }

  void Initialize()
  {
    mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
    leftCamera = GameObject.Find("LeftCamera").GetComponent<Camera>();
    rightCamera = GameObject.Find("RightCamera").GetComponent<Camera>();
    boatCamera = GameObject.Find("BoatCamera").GetComponent<Camera>();
    boat = GameObject.Find("Boat").GetComponent<Boat>();
  }

  void Update()
  {
    HandleMainCamera();
    SwitchCamera();
  }

  void HandleMainCamera()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
      isUsingMainCamera = true;
    else if (Input.GetKeyDown(KeyCode.Alpha2))
      isUsingMainCamera = false;
  }

  void SwitchCamera()
  {
    if (isUsingMainCamera)
      UseMainCamera();
    else if (boat.isMoving)
      UseBoatCamera();
    else if (boat.isOnRight)
      UseRightCamera();
    else if (!boat.isOnRight)
      UseLeftCamera();
  }

  void UseBoatCamera()
  {
    mainCamera.enabled = false;
    rightCamera.enabled = false;
    leftCamera.enabled = false;
    boatCamera.enabled = true;
  }

  void UseRightCamera()
  {
    mainCamera.enabled = false;
    rightCamera.enabled = true;
    leftCamera.enabled = false;
    boatCamera.enabled = false;
  }

  void UseLeftCamera()
  {
    mainCamera.enabled = false;
    rightCamera.enabled = false;
    leftCamera.enabled = true;
    boatCamera.enabled = false;
  }

  void UseMainCamera()
  {
    mainCamera.enabled = true;
    rightCamera.enabled = false;
    leftCamera.enabled = false;
    boatCamera.enabled = false;
  }
}
