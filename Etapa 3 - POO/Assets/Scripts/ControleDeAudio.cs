using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Unity.UIElements;
using UnityEngine.Audio;
using Slider = UnityEngine.UI.Slider;

public class ControleDeAudio : MonoBehaviour
{
    public float volume = 0f;
    public AudioMixer audioMixer;

    public Slider slide;
    
    public TMP_Text texto;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slide.minValue = -80;
        slide.maxValue = 20;
        slide.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && volume > 20)
        {
            volume += 1;
            //audioMixer.SetFloat("Master", volume);

        }
        if (Input.GetKeyDown(KeyCode.S) && volume > -80)
        {
            volume -= 1;
            //audioMixer.SetFloat("Master", volume);

        }
        volume = slide.value;
        
        audioMixer.SetFloat("Master", volume);
        texto.text = volume.ToString();
        
    }
}
