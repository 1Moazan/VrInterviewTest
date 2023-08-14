
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject categoryPanel;
    [SerializeField] private GameObject initText;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private Button [] weaponButtons;
    [SerializeField] private Button [] instrumentButtons;
    private void Start()
    {
        SetPanel(false);
        
    }

    public void SetPanel(bool active)
    {
        categoryPanel.SetActive(active);
        closeButton.SetActive(active);
        initText.SetActive(!active);
        if (active)
        {
            categoryPanel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            categoryPanel.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.InOutQuad);
            initText.transform.DOKill();
        }
        else
        {
            initText.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 1f).SetLoops(-1, LoopType.Yoyo);
        }
    }

    public void SelectEvent(SelectEnterEventArgs args)
    {
       SetPanel(true);
    }
    
    public void UnSelectEvent(SelectExitEventArgs args)
    {
       SetPanel(false);
    }

    public void SetWeaponAction(int index , UnityAction action)
    {
        weaponButtons[index].onClick.AddListener(action);
    }
    
    public void SetInstrumentAction(int index , UnityAction action)
    {
        instrumentButtons[index].onClick.AddListener(action);
    }
    
}
