using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateEnum2 : MonoBehaviour
{
    public AudioClip gettingOnPad;
    public AudioClip gettingOffPad;
    AudioSource audioSource1;
    AudioSource audioSource2;
    SphereEnum _enumChanger;

    void Start()
    {
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        _enumChanger = GameObject.FindGameObjectWithTag("Sphere2Enum").GetComponent<SphereEnum>();
        _enumChanger.currentColorType = SphereEnum.ColorType.StarterColor;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource1.PlayOneShot(gettingOnPad, 1F);
            if (_enumChanger.currentColorType == SphereEnum.ColorType.StarterColor)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.Blue;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.Blue)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.Green;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.Green)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.LBlue;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.LBlue)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.Purple;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.Purple)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.Red;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.Red)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.White;
                return;
            }
            if (_enumChanger.currentColorType == SphereEnum.ColorType.White)
            {
                _enumChanger.currentColorType = SphereEnum.ColorType.Blue;
                return;
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _enumChanger.soundTrigger = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource2.PlayOneShot(gettingOffPad, 1F);
            _enumChanger.soundTrigger = false;
        }
    }
}
