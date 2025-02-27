using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InroductionGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Button[] mainButtons = new Button[3];

    [SerializeField] Ease easeType = Ease.OutBounce;
    [SerializeField] float timerToAppear;
    [SerializeField] float timerToMove;

    void Start()
    {
        EnableDisableButtons(false);

        ActiveIntro();
    }

    void ActiveIntro()
    {
        title.DOFade(1, 1).OnComplete(ShowButtons); //Title alpha activation
    }

    void ShowButtons()
    {
        mainButtons[0].transform.DOScaleX(1, timerToAppear).SetEase(easeType).SetDelay(1f);
        mainButtons[0].GetComponent<RectTransform>()
        .DOAnchorPos(mainButtons[0].GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50), timerToMove)
        .SetEase(easeType)
        .SetDelay(1.5f)
        .OnComplete(() =>
        {
            mainButtons[1].transform.DOScaleX(1, timerToAppear).SetEase(easeType);

            mainButtons[0].GetComponent<RectTransform>()
            .DOAnchorPos(mainButtons[0].GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50), timerToMove)
            .SetDelay(0.5f)
            .SetEase(easeType);

            mainButtons[1].transform.GetComponent<RectTransform>()
            .DOAnchorPos(mainButtons[1].GetComponent<RectTransform>().anchoredPosition + new Vector2(0, 50), timerToMove)
            .SetDelay(0.5f)
            .SetEase(easeType)
            .OnComplete(() =>
            {
                mainButtons[2].transform.DOScaleX(1, timerToAppear).SetEase(easeType);

                EnableDisableButtons(true);
            });
        });
    }


    void EnableDisableButtons(bool value)
    {
        foreach (Button button in mainButtons)
        {
            button.interactable = value;
        }
    }

}
