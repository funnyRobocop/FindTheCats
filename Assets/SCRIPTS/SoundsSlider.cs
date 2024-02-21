using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsSlider : MonoBehaviour
{
    public AudioSource SoundSource;
    public AudioSource MusicSource;
    public Slider SoundSlider;
    public Slider MusicSlider;

    void Update()
    {
        SoundSource.volume = SoundSlider.value;
        MusicSource.volume = MusicSlider.value;
    }
}
