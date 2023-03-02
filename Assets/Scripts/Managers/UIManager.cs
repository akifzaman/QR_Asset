using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    //public CanvasGroup ButtonCanvasGroup;
    public RectTransform rectTransform;
    public List<GameObject> ShareButtons = new List<GameObject>();


    public List<TMP_InputField> inputFields;
    public List<RectTransform> inputFieldTransforms;
    public float moveDuration = 1f;
    public float delayBetweenMoves = 0.5f;
    public float finalXPosition = 1640f;
    public float finalYPosition = -2000f;

    public Button GenerateButton;
    public Button HomeButton;
    public Button GenerateAgainButton;
    public CanvasGroup GenerateButtonCanvas;
    public CanvasGroup GenerateAgainButtonCanvas;
    public CanvasGroup ShareButtonCanvas;
    public CanvasGroup BackButtonCanvas;

    public bool isFormValid = false;

    public GameObject Form;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void Start()
    {
        GenerateButtonCanvas.transform.localScale = Vector3.zero;
        GenerateButtonCanvas.alpha = 0;
        ShareButtonCanvas.transform.localScale = Vector3.zero;
        ShareButtonCanvas.alpha = 0;
        ShowForm();
        StartCoroutine(ShowGenerateButton());
    }

    public void OnGenerateButtonClicked()
    {
        if (isFormValid)
        {
            Form.gameObject.SetActive(false);
            HomeButton.gameObject.SetActive(false);
            GenerateButton.gameObject.SetActive(false);
        }
    }
    public void OnBackButtonClicked()
    {
        Form.gameObject.SetActive(true);
        GenerateButton.gameObject.SetActive(true);
        HomeButton.gameObject.SetActive(true);
        ShareButtonCanvas.alpha = 0;
        GenerateAgainButtonCanvas.alpha = 0;
        BackButtonCanvas.alpha = 0;
    }
    IEnumerator ShowButtons()
    {
        yield return new WaitForSeconds(0.5f);
        ShareButtonCanvas.DOFade(1, fadeTime);
        foreach (var shareButton in ShareButtons)
        {
            shareButton.transform.localScale = Vector3.zero;
        }

        foreach (var shareButton in ShareButtons)
        {
            shareButton.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }

    //Move form from the left side of the screen to the middle of the screen
    public void ShowForm()
    {
        foreach (var inputFieldTransform in inputFieldTransforms)
        {
            MoveInputFieldX(inputFieldTransform, finalXPosition);
        }
    }
    IEnumerator ShowShareButtons()
    {
        yield return new WaitForSeconds(1f);
        FadeIn(ShareButtonCanvas);
    }
    IEnumerator ShowGenerateButton()
    {
        yield return new WaitForSeconds(1f);
        FadeIn(GenerateButtonCanvas);
    }
    public void FadeIn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }
    public void RemoveForm()
    {
        if (UIManager.Instance.isFormValid)
        {
            foreach (var inputFieldTransform in inputFieldTransforms)
            {
                MoveInputFieldX(inputFieldTransform, 2 * finalXPosition);
            }
        }
    }
    private void MoveInputFieldX(RectTransform inputFieldTransform, float xPosition)
    {
        inputFieldTransform.DOAnchorPosX(xPosition, moveDuration).SetDelay(delayBetweenMoves);
    }
    public void PanelFadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1f;
        ShareButtonCanvas.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(1640f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
        ShareButtonCanvas.DOFade(0, fadeTime);
    }
}