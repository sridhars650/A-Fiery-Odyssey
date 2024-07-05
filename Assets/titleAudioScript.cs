using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleAudioScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateAudioVolume()
    {
        audioSource.volume = slider.value;
    }
}
