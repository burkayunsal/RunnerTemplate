using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailPanel : MonoBehaviour
{
    public static FailPanel instance;


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
        

        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack).OnComplete(() => { });
    }

    public void RestartButtonAction()
    {
        SceneManager.LoadScene(0);
    }
}
