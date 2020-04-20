using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ImagePlacement: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameInsta;
    public GameObject spawn;
    private ARRaycastManager RM;
    // private Vector2 touchPosition;
    //public Texture2D text2;
    static List<ARRaycastHit> hits= new List<ARRaycastHit>();                         
    //public GameObject go1;
   // Sprite s1;
   // public SpriteRenderer r1;
    private void Awake() {
        RM=GetComponent<ARRaycastManager>();
        //text2 = go1.GetComponent<OpenCvSharp.TestCameraImage>().texture1;
        //text2.filterMode = FilterMode.Point;
    }

    //public RawImage rImage;

    bool getTouch(out Vector2 touchPosition){
        if(Input.touchCount>0){
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition=default;
        return false;
    }

    //public Material m1;
    void Update()
    {
        if(!getTouch(out Vector2 touchPosition)){
            return;
        }
        if(RM.Raycast(touchPosition,hits,TrackableType.PlaneWithinPolygon)){
            var hitPose = hits[0].pose;
            if(spawn==null){
                // UnityEngine.Rect r2 = new UnityEngine.Rect(0, 0, text2.width, text2.height);
                // s1 = Sprite.Create(text2, r2, new Vector2(0.5f, 0.5f), 100.0f);
                // r1.sprite = s1;
                //gameInsta.GetComponent<Renderer>().material.mainTexture=text2;
                spawn=Instantiate(gameInsta,hitPose.position, Quaternion.Euler(180,0, 90));
                // Instantiate(r1, new Vector3(0, 0, 10),));
                // Debug.Log("Material Name:::::"+spawn.GetComponent<Renderer>().material.mainTexture);
                // rImage.transform.position=hitPose.position;
                // rImage.transform.rotation=hitPose.rotation;
                // rImage.texture=text2;
            }   
            else{
                spawn.transform.position= hitPose.position;
            }
        }

    }
    
}
