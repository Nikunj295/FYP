using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MenuSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void spaceDrawing(){
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single); 
    }
    public void imageConvert(){
        SceneManager.LoadScene("imageInstance",LoadSceneMode.Single); 
    }

}
