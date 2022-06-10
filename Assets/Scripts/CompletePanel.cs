using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class CompletePanel : MonoBehaviour
{
    public static CompletePanel instance;

    [Header("UI")]
    public Button continueButton;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void OpenPanel()
    {
        CanvasManager.instance.progressBarRoot.SetActive(false);
        CanvasManager.instance.counterText.transform.parent.gameObject.SetActive(false);


        transform.DOScale(Vector3.one, 0.5f).SetDelay(0.2f).SetEase(Ease.OutBack).OnComplete(() =>{ });
    }


    public void NextButtonAction()
    {
        continueButton.enabled = false;
        LevelManager.LoadNextLevel();

    }

}
