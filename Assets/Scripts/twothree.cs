using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class twothree : MonoBehaviour
{
    // Start is called before the first frame update
    Texture2D texture1;
        // public Button b1;
    Texture3D text3d;
    public GameObject gameObject;
    void Start()
    {
        Debug.Log("Twothree-StartCalled");
        convert();
    }
    void convert(){
        Debug.Log("Function Called");
        
        texture1 =  gameObject.GetComponent<TestCameraImage>().texture1;
        Debug.Log("texture1 reference from gameObject: "+ texture1.GetPixels());
        Color[] c2D = texture1.GetPixels();
        Color[] c3D = new Color[c2D.Length];
        
        int depth = 10;
        int width = texture1.width;
        int height = texture1.height;

        for(int z = 0; z < depth; ++z)
            for(int y = 0; y < height; ++y)
                for(int x = 0; x < width; ++x)
                    c3D[x + y * width + z * width * height] = c2D[x + y * width * depth + z * width];

        text3d.SetPixels(c3D);
        Debug.Log(text3d.GetPixels());
    }
    void Update()
    {
        
    }
}
