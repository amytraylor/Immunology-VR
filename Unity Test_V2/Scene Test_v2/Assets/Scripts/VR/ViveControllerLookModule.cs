using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Valve.VR;

// To use:
// 1. Drag onto your EventSystem game object. 
// 2. Disable any other Input Modules (eg: StandaloneInputModule & TouchInputModule) as they will fight over selections.
// 3. Make sure your Canvas is in world space and has a GraphicRaycaster (should by default).
// 4. If you have multiple cameras then make sure to drag your VR (center eye) camera into the canvas.
public class ViveControllerLookModule : PointerInputModule {
  public Camera ControllerCamera;
  public SteamVR_TrackedObject RightController;
  //1
  public GameObject reticle;
  public Transform laserTransform;
  //2
  private Transform rightControllerTransform;
  //3
  public float reticleSizeMultiplier = 0.02f; // The size of the reticle will get scaled with this value
  //4
  private PointerEventData pointerEventData;
  //5
  private RaycastResult currentRaycast;
  //6
  private GameObject currentLookAtHandler;

  void Awake() {
    rightControllerTransform = RightController.transform;
  }

  public override void Process() {
    HandleLook();
    HandleSelection();
  }

  void HandleLook() {
    if (pointerEventData == null) {
      pointerEventData = new PointerEventData(eventSystem);
    }

    pointerEventData.position = ControllerCamera.ViewportToScreenPoint(new Vector3(.5f, .5f)); // Set a virtual pointer to the center of the screen
    List<RaycastResult> raycastResults = new List<RaycastResult>(); // A list to hold all the raycast results
    eventSystem.RaycastAll(pointerEventData, raycastResults); // Do a raycast using all enabled raycasters in the scene
    currentRaycast = pointerEventData.pointerCurrentRaycast = FindFirstRaycast(raycastResults); // Get the first hit an set both the local and pointerEventData results

    reticle.transform.position = rightControllerTransform.position + (rightControllerTransform.forward * currentRaycast.distance); // Move reticle

    laserTransform.position = Vector3.Lerp(rightControllerTransform.position, reticle.transform.position, .5f);
    laserTransform.LookAt(reticle.transform);
    laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y, currentRaycast.distance);

    float reticleSize = currentRaycast.distance * reticleSizeMultiplier;
    reticle.transform.localScale = new Vector3(reticleSize, reticleSize, reticleSize); //Scale reticle so it's always the same size

    ProcessMove(pointerEventData); // Pass the pointer data to the event system so entering and exiting of objects is detected
  }

  void HandleSelection() {
    if (pointerEventData.pointerEnter != null) {
      //Get the OnPointerClick handler of the entered object
      currentLookAtHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(pointerEventData.pointerEnter);

      if (currentLookAtHandler != null && IsTriggerPressed()) {
        // Object in sight with a OnPointerClick handler & pressed the main button
        ExecuteEvents.ExecuteHierarchy(currentLookAtHandler, pointerEventData, ExecuteEvents.pointerClickHandler);
      }
    }
    else {
      currentLookAtHandler = null;
    }
  }

  private bool IsTriggerPressed() {
    return SteamVR_Controller.Input((int)RightController.index).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger);
  }
}