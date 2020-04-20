// namespace OpenCvSharp{

using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using OpenCvSharp;
using OpenCvSharp.Aruco;

public class Scan : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The ARCameraManager which will produce frame events.")]
    ARCameraManager m_CameraManager;

    public ARCameraManager cameraManager
    {
        get { return m_CameraManager; }
        set { m_CameraManager = value; }
    }

    [SerializeField]
    RawImage m_RawImage;

    public RawImage rawImage
    {
        get { return m_RawImage; }
        set { m_RawImage = value; }
    }

    [SerializeField]
    Text m_ImageInfo;

    public Text imageInfo
    {
        get { return m_ImageInfo; }
        set { m_ImageInfo = value; }
    }

    void OnEnable()
    {
        if (m_CameraManager != null)
        {
            m_CameraManager.frameReceived += OnCameraFrameReceived;
        }
    }

    void OnDisable()
    {
        if (m_CameraManager != null)
        {
            m_CameraManager.frameReceived -= OnCameraFrameReceived;
        }
    }

    public Button b1;
    //public Button b2;


    public Texture2D texture1;

    void Start() {
        b1 = b1.GetComponent<Button>();
        //b2 = b2.GetComponent<Button>();
        //b1.onClick.AddListener(f1);
        //b2.onClick.AddListener(place);
    }

    
    // void f1(){
        
    //     Mat mainMat = new Mat(m_Texture.height, m_Texture.width, MatType.CV_8UC3);
    //     Mat grayMat = new Mat();
    //     mainMat = Unity.TextureToMat(m_Texture);
    //     Cv2.CvtColor(mainMat, grayMat, ColorConversionCodes.BGR2GRAY);
    //     Cv2.GaussianBlur(grayMat, grayMat, new Size(5, 5), 0);
    //     Cv2.Canny(grayMat, grayMat, 10.0, 70.0);
    //     Cv2.FastNlMeansDenoising(grayMat, grayMat, 3, 7, 21);
    //     Cv2.Threshold(grayMat, grayMat, 70.0, 255.0, ThresholdTypes.BinaryInv);
        
    //     texture1 = Unity.MatToTexture(grayMat);

    //     Color[] pixels = texture1.GetPixels(0, 0, texture1.width, texture1.height, 0);
    //     for (int p = 0; p < pixels.Length; p++)
    //     {
    //         if (pixels[p].Equals(new Color(1, 1, 1, 1)))
    //             pixels[p] = new Color(0, 0, 0, 0);
    //     }
    //     texture1.SetPixels(0, 0, texture1.width, texture1.height, pixels, 0);
    //     texture1.Apply();
    //     //m_RawImage.texture = texture1;
    // }
    // void place(){
    //     // UnityEngine.Rect r2 = new UnityEngine.Rect(0, 0, texture1.width, texture1.height);
    //     // s1 = Sprite.Create(texture1, r2, new Vector2(0.5f, 0.5f), 100.0f);
    //     // r1.sprite = s1;
    //     //Instantiate(r1, new Vector3(0, 0, 10), Quaternion.Euler(0, 0, 90));
    // }

    unsafe void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        // Attempt to get the latest camera image. If this method succeeds,
        // it acquires a native resource that must be disposed (see below).
        XRCameraImage image;
        if (!cameraManager.TryGetLatestImage(out image))
        {
            return;
        }

        // Display some information about the camera image
        m_ImageInfo.text = string.Format(
            "Image info:\n\twidth: {0}\n\theight: {1}\n\tplaneCount: {2}\n\ttimestamp: {3}\n\tformat: {4}",
            image.width, image.height, image.planeCount, image.timestamp, image.format);

        // Once we have a valid XRCameraImage, we can access the individual image "planes"
        // (the separate channels in the image). XRCameraImage.GetPlane provides
        // low-overhead access to this data. This could then be passed to a
        // computer vision algorithm. Here, we will convert the camera image
        // to an RGBA texture and draw it on the screen.

        // Choose an RGBA format.
        // See XRCameraImage.FormatSupported for a complete list of supported formats.
        var format = TextureFormat.RGBA32;

        if (m_Texture == null || m_Texture.width != image.width || m_Texture.height != image.height)
        {
            m_Texture = new Texture2D(image.width, image.height, format, false);
        }

        // Convert the image to format, flipping the image across the Y axis.
        // We can also get a sub rectangle, but we'll get the full image here.
        var conversionParams = new XRCameraImageConversionParams(image, format, CameraImageTransformation.MirrorY);

        // Texture2D allows us write directly to the raw texture data
        // This allows us to do the conversion in-place without making any copies.
        var rawTextureData = m_Texture.GetRawTextureData<byte>();
        try
        {
            image.Convert(conversionParams, new IntPtr(rawTextureData.GetUnsafePtr()), rawTextureData.Length);
        }
        finally
        {
            // We must dispose of the XRCameraImage after we're finished
            // with it to avoid leaking native resources.
            image.Dispose();
        }

        // Apply the updated texture data to our texture
        m_Texture.Apply();

        // Set the RawImage's texture so we can visualize it.
        
    }

    Texture2D m_Texture;
}
// }