using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickAudio : MonoBehaviour
{
    public AudioClip choose;

    private AudioSource audioSource;

    private Button button;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        button = gameObject.GetComponent<Button>();
        audioSource.clip = choose;
        audioSource.playOnAwake = false;

        button.onClick.AddListener(()=>Click());
    }

    public void Click()
    {
        audioSource.PlayOneShot(choose);
    }
}
