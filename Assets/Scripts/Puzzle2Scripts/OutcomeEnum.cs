using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutcomeEnum : MonoBehaviour
{
    public AudioClip rewardSound;
    AudioSource audioSource;
    SphereEnum checkingState0;
    SphereEnum checkingState1;
    SphereEnum checkingState2;
    SphereEnum checkingState3;
    SphereEnum checkingState4;
    SphereEnum checkingState5;
    float timer1;
    float timer2;
    AIScript2 aiScript;

    void Start()
    {
        aiScript = GameObject.FindGameObjectWithTag("AI").GetComponent<AIScript2>();
        checkingState0 = GameObject.FindGameObjectWithTag("Sphere0Enum").GetComponent<SphereEnum>();
        checkingState1 = GameObject.FindGameObjectWithTag("Sphere1Enum").GetComponent<SphereEnum>();
        checkingState2 = GameObject.FindGameObjectWithTag("Sphere2Enum").GetComponent<SphereEnum>();
        checkingState3 = GameObject.FindGameObjectWithTag("Sphere3Enum").GetComponent<SphereEnum>();
        checkingState4 = GameObject.FindGameObjectWithTag("Sphere4Enum").GetComponent<SphereEnum>();
        checkingState5 = GameObject.FindGameObjectWithTag("Sphere5Enum").GetComponent<SphereEnum>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (checkingState0.currentColorType == SphereEnum.ColorType.Red 
            && checkingState1.currentColorType == SphereEnum.ColorType.LBlue
            && checkingState2.currentColorType == SphereEnum.ColorType.Green
            && checkingState3.currentColorType == SphereEnum.ColorType.Purple
            && checkingState4.currentColorType == SphereEnum.ColorType.Blue
            && checkingState5.currentColorType == SphereEnum.ColorType.White)
        {
            timer1 += Time.deltaTime;
            if (timer1 >= 1)
            {
                checkingState0.currentColorType = SphereEnum.ColorType.CompletedColor;
                checkingState1.currentColorType = SphereEnum.ColorType.CompletedColor;
                checkingState2.currentColorType = SphereEnum.ColorType.CompletedColor;
                checkingState3.currentColorType = SphereEnum.ColorType.CompletedColor;
                checkingState4.currentColorType = SphereEnum.ColorType.CompletedColor;
                checkingState5.currentColorType = SphereEnum.ColorType.CompletedColor;
            }
        }

        if (checkingState0.currentColorType == SphereEnum.ColorType.CompletedColor
            && checkingState1.currentColorType == SphereEnum.ColorType.CompletedColor
            && checkingState2.currentColorType == SphereEnum.ColorType.CompletedColor
            && checkingState3.currentColorType == SphereEnum.ColorType.CompletedColor
            && checkingState4.currentColorType == SphereEnum.ColorType.CompletedColor
            && checkingState5.currentColorType == SphereEnum.ColorType.CompletedColor)
        {
            audioSource.PlayOneShot(rewardSound, 0.5F);// SOUND IS EXTREMELY DISTORTED FOR SOME REASON, SOUND REDUCED TO 0.05 IN INSPECTOR BUT IS IN 3D READY FORMAT
            timer2 += Time.deltaTime;
            if (timer2 >= 3)
            {
                aiScript.currentAIStates = AIScript2.AIStates.EndPortal;
                Destroy(gameObject);
            }
        }
    }
}
