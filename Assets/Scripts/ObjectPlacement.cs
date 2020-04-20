// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.ARFoundation;
// using UnityEngine.XR.ARSubsystems;
// using UnityEngine.UI;

// public class ObjectPlacement : MonoBehaviour
// {
//     public GameObject placeIndicator;
//     public Image objectToPlace;

//     private ARSessionOrigin arOrigin;
//     private ARRaycastManager arOriginRayCast;
//     private Pose placementPose;
//     private bool placementPoseIsValid = false;

//     public Button b1;
//     public Texture2D objecttext;
//     Start 
//     void Start()
//     {
//         arOrigin = FindObjectOfType<ARSessionOrigin>();
//         arOriginRayCast = arOrigin.GetComponent<ARRaycastManager>();
//         objecttext = this.GetComponent<OpenCvSharp.TestCameraImage>().texture1;
//     }

     
//     void Update()
//     {
//         UpdatePlacementPose();
//         UpdatePlacementIndicator();

//         if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//         {
//             Debug.Log("s");
//             PlaceObject();
//         }
//     }

//     private void PlaceObject()
//     {
//         Vector2 pivot = new Vector2(0.5f, 0.5f);
//         Rect tRect = new Rect(0, 0, objecttext.width, objecttext.height);
//         Sprite newSprite = Sprite.Create(objecttext, tRect, pivot);
//         objectToPlace.GetComponent<SpriteRenderer>().sprite = newSprite;
//         Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
//     }
//     void UpdatePlacementPose()
//     {
//         var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
//         var hits = new List<ARRaycastHit>();
//         arOriginRayCast.Raycast(screenCenter, hits, TrackableType.Planes);
//         //arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, TrackableType.Planes);

//         placementPoseIsValid = hits.Count > 0;
//         if (placementPoseIsValid)
//         {
//             placementPose = hits[0].pose;
//         }
//     }

//     void UpdatePlacementIndicator()
//     {
//         if (placementPoseIsValid)
//         {
//             placeIndicator.SetActive(true);
//             placeIndicator.transform.SetPositionAndRotation
//                 (placementPose.position, placementPose.rotation);
//                 Debug.Log("->"+(placementPose.position, placementPose.rotation));
//         }
//         else
//         {
//             placeIndicator.SetActive(false);
//         }
//     }
// }