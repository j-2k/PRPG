using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnum : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    public AudioClip thumpSoundFromSphere;
    AudioSource audioSource;
    public bool soundTrigger;
    float timer;

    public enum ColorType
    {
        StarterColor,
        Blue,
        Green,
        LBlue,
        Purple,
        Red,
        White,
        CompletedColor
    }
    public ColorType currentColorType;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        currentColorType = ColorType.StarterColor;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        print(currentColorType);
        switch(currentColorType)
        {
            case ColorType.StarterColor:
                rend.sharedMaterial = material[0];
                break;
            case ColorType.Blue:
                rend.sharedMaterial = material[1];
                break;
            case ColorType.Green:
                rend.sharedMaterial = material[2];
                break;
            case ColorType.LBlue:
                rend.sharedMaterial = material[3];
                break;
            case ColorType.Purple:
                rend.sharedMaterial = material[4];
                break;
            case ColorType.Red:
                rend.sharedMaterial = material[5];
                break;
            case ColorType.White:
                rend.sharedMaterial = material[6];
                break;
            case ColorType.CompletedColor:
                break;
        }

        if (soundTrigger == true)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                audioSource.PlayOneShot(thumpSoundFromSphere, 1f);
                timer = 0;
            }
        }
    }
}
