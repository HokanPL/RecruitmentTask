using System.Collections;
using UnityEngine;

public class PopupPanel : MonoBehaviour
{
    public RectTransform popup;
    public float delayInSeconds;
    public RectTransform[] uiElementsToEnable;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(Run());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        SetAllElementsActive(false);
    }

    private IEnumerator Run()
    {
        popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(delayInSeconds);
        SetAllElementsActive(true);
    }

    private void SetAllElementsActive(bool active)
    {
        foreach (var a in uiElementsToEnable) a.gameObject.SetActive(active);
    }

    public void DisableMe()
    {
        gameObject.SetActive(false);
        enabled = false;
    }
}
