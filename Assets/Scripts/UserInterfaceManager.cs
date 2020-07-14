using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AudioToggle
{
    public Toggle toggle;
    public AudioClip clip;
}

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance;

    public Button first;
    public Button second;
    public Button third;

    public PopupPanel popupPanel;
    public AudioToggle[] audioToggles;
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        first.gameObject.SetActive(true);
        second.gameObject.SetActive(true);
        third.gameObject.SetActive(true);

        popupPanel.gameObject.SetActive(false);
        
        foreach (AudioToggle t in audioToggles)
        {
            t.toggle.gameObject.SetActive(true);
            t.toggle.isOn = true;
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
    public void InvokeRandomAudioPlaying()
    {
        List<AudioClip> clipsToPlay = new List<AudioClip>();

        for (int i = 0; i < audioToggles.Length; i++)
        {
            if (audioToggles[i].toggle.isOn) clipsToPlay.Add(audioToggles[i].clip);
        }

        int idToPlay = Random.Range(0, clipsToPlay.Count);

        AudioManager.Instance.audioSource.clip = clipsToPlay[idToPlay];
        AudioManager.Instance.audioSource.Play();
        
    }


}
