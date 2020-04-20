namespace OpenCvSharp.Demo
{
	using System.Collections.Generic;
	using OpenCvSharp;
	using UnityEngine.UI;

	public class AlphabetOCRScene : UnityEngine.MonoBehaviour
	{
		// [SerializeField]
		public UnityEngine.Texture2D texture;
		public UnityEngine.TextAsset model;
		
		public Button b1;
		public UnityEngine.GameObject gameobj;
		
		void f1(){
			//mytext.text="";
			UnityEngine.Debug.Log("FunctionCalled");
			
			AlphabetOCR alphabet = new AlphabetOCR(model.bytes);

			// UnityEngine.Texture2D m_Texture = gameobj.GetComponent<TestCameraImage>().m_Texture;	

			var image = Unity.TextureToMat(this.texture);
			
			IList<AlphabetOCR.RecognizedLetter> letters = alphabet.ProcessImage(image);

			foreach (var letter in letters)
			{
				// const int textPadding = 2;
				// const HersheyFonts textFontFace = HersheyFonts.HersheyPlain;
				// double textFontScale = System.Math.Max(this.texture.width, this.texture.height) / 512.0;
				// Scalar boxColor = Scalar.DeepPink;
				// Scalar textColor = Scalar.White;
				// int line;
				// var bounds = Cv2.BoundingRect(letter.Rect);
				UnityEngine.Debug.Log(letter.Data);
				// System.Diagnostics.Debug.WriteLine(letter.Data);
				//mytext.text = mytext.text + letter.Data;
				//text box
				// var textData = string.Format("{0}: {1}%", letter.Data, System.Math.Round(letter.Confidence * 100));
				// var textSize = Cv2.GetTextSize(textData, textFontFace, textFontScale, 1, out line);
				// var textBox = new Rect(
				// 	bounds.X + (bounds.Width - textSize.Width) / 2 - textPadding,
				// 	bounds.Bottom,
				// 	textSize.Width + textPadding * 2,
				// 	textSize.Height + textPadding * 2
				// );
				// // draw shape
				// image.Rectangle(bounds, boxColor, 2);
				// image.Rectangle(textBox, boxColor, -1);
				// image.PutText(textData, textBox.TopLeft + new Point(textPadding, textPadding + textSize.Height), textFontFace, textFontScale, textColor, (int)(textFontScale + 0.5));
				// UnityEngine.Texture2D texture = Unity.MatToTexture(image);
				RawImage rawImage = gameObject.GetComponent<RawImage>();
				rawImage.texture =texture;

				 UnityEngine.Debug.Log("Function ended");
			}
		}	

		void Start()
		{
			b1 = b1.GetComponent<Button>();
			 UnityEngine.Debug.Log("Started");
			// Debug.Log("");
			b1.onClick.AddListener(f1);
			// some constants for drawing
			
			
			// load alphabet
			

			// scan image
			

			// result
			// // output
			// var transform = gameObject.GetComponent<UnityEngine.RectTransform>();
			// transform.sizeDelta = new UnityEngine.Vector2(image.Width, image.Height);
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}