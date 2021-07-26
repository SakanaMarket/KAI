using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioSource audio_source;
    [SerializeField] private float music_volume = 0.5f;
    [SerializeField] private Slider s;
    void Awake()
    {
        audio_source = GetComponent<AudioSource>();
        s.value = music_volume;

    }
    void Update()
    {
        audio_source.volume = music_volume;
    }

    public void AdjustVolume()
    {
        float volume_level = s.value;
        music_volume = volume_level;
    }

    public float GetVolume()
    {
        return music_volume;
    }

    public void Play_Sound(AudioClip a)
    {
        audio_source.PlayOneShot(a, .25f);
    }

    public void ShowSlider(GameObject g)
    {
        g.SetActive(!g.activeSelf);
    }
}