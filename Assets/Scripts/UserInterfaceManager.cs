using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance;

    public Button first;
    public Button second;
    public Button third;

    public PopupPanel popupPanel;
    //public Button closePopupImage;

    //public Text popupText;

    public Toggle[] audioToggles;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        first.gameObject.SetActive(true);
        second.gameObject.SetActive(true);
        third.gameObject.SetActive(true);

        popupPanel.gameObject.SetActive(false);
        //closePopupImage.gameObject.SetActive(false);

        foreach (Toggle t in audioToggles)
        {
            t.gameObject.SetActive(true);
            t.isOn = true;
        }
    }

    public void InvokePopup(PopupPanel popup)
    {
        popup.gameObject.SetActive(true);
        popup.enabled = true;
    }
    public void InvokePopup(PopupText popup)
    {
        popup.gameObject.SetActive(true);
        popup.enabled = true;
        popup.StopAllCoroutines();
        popup.StartCoroutine(popup.Run());
    }


}
