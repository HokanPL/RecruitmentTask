using System.Collections;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    public RectTransform popup;
    public float autoDisableInSeconds;

    private void Awake()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public IEnumerator Run()
    {
        popup.gameObject.SetActive(true);
        yield return new WaitForSeconds(autoDisableInSeconds);
        DisableMe();
    }

    private void DisableMe()
    {
        gameObject.SetActive(false);
        enabled = false;
    }
}
