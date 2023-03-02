using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//
public class SceneLoader : MonoBehaviour
{
    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }
    public void GoToContactQRGeneration()
    {
        SceneManager.LoadScene("ContactInfoDemoScene");
    }
    public void GoToEmailQRGeneration()
    {
        SceneManager.LoadScene("EmailAddressDemoScene");
    }
    public void GoToGeoQRGeneration()
    {
        SceneManager.LoadScene("GeoLocationDemoScene");
    }
    public void GoToPhoneQRGeneration()
    {
        SceneManager.LoadScene("PhoneNumberDemoScene");
    }
    public void GoToSMSQRGeneration()
    {
        SceneManager.LoadScene("SMSDemoScene");
    }
    public void GoToTextQRGeneratioin()
    {
        SceneManager.LoadScene("TextDemoScene");
    }
    public void GoToURLQRGeneation()
    {
        SceneManager.LoadScene("URLDemoScene");
    }
    public void GoToWIFIQRGeneration()
    {
        SceneManager.LoadScene("WIFIDemoScene");
    }
}
