using UnityEngine;  
using System.Collections;  
using ZXing; 
using ZXing.QrCode;  
using UnityEngine.UI;  
using TMPro;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class CreateQRCode : MonoBehaviour  
{   
	public static Texture2D encoded;  
	public string Lastresult;
    public Image QRCodePlaceHolder;

    public List<TMP_InputField> inputFields;

    public GameObject Form;
    public Button GenerateButton;

    public CanvasGroup QRCodeImageCanvas;
    public CanvasGroup ShareButtonCanvasGroup;
    public CanvasGroup GenerateAgainButtonCanvas;
    public CanvasGroup BackButtonCanvas;

    public Scene scene;

    //public void Start()
    //{
    //    Lastresult = " ";
    //}
    // For generating raw text
    public virtual string GenerateText()
    {
        return Lastresult;
    }

    // For generating QRCode
	public static Color32[] Encode(string textForEncoding, int width, int height)  
	{  
		var writer = new BarcodeWriter  
		{  
			Format = BarcodeFormat.QR_CODE,  
			Options = new QrCodeEncodingOptions  
			{  
				Height = height,  
				Width = width  
			}  
		};  
		return writer.Write(textForEncoding);  
	}

	// For generating the QRCode Image
    public void GenerateQROutput()
    {
        if (UIManager.Instance.isFormValid)
        {
            encoded = new Texture2D(256, 256);
            var textForEncoding = Lastresult;
            if (textForEncoding != null)
            {
                var color32 = Encode(textForEncoding, encoded.width, encoded.height);
                encoded.SetPixels32(color32);
                encoded.Apply();
            }
            QRCodePlaceHolder.sprite = Sprite.Create(encoded, new Rect(0, 0, encoded.width, encoded.height), Vector2.zero);
        }
    }

    public void GenerateAgain()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void StoreInput()
    {
        if (UIManager.Instance.isFormValid)
        {
            GenerateButton.gameObject.SetActive(false);
            UIManager.Instance.FadeIn(QRCodeImageCanvas);
            UIManager.Instance.FadeIn(ShareButtonCanvasGroup);
            UIManager.Instance.FadeIn(GenerateAgainButtonCanvas);
            UIManager.Instance.FadeIn(BackButtonCanvas);
        }
    }

    public void EnableEditFunction()
    {
        Lastresult = "";
        QRCodeImageCanvas.alpha = 0;
    }

    public void ShareImage()
    {
        Texture2D ss = encoded;

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        //Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Hello world!").SetUrl("https://github.com/yasirkula/UnityNativeShare")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
    }
}  