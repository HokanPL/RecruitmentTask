using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource audioSource;

    [HideInInspector]
    public AudioClip[] clipsOnClick;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        clipsOnClick = new AudioClip[UserInterfaceManager.Instance.audioToggles.Length];
    }
}