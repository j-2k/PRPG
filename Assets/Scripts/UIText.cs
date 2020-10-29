using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    Text text;
    public float timer;
    public enum TextPart
    {
        Intro1,
        Intro2,
        Intro3,
        Intro4,
        Portal1,
        Idle,
        NewIntro1,
        NewIntro2,
        NewPortal1,
        NewPortal2
    }
    public TextPart currentText;
    void Start()
    {
        text = GetComponent<Text>();
        currentText = TextPart.Intro1;
    }

    void Update()
    {
        switch (currentText)
        {
            case TextPart.Intro1:
            text.text = "Hello adventurer! Welcome to Mirror Adventure! Please take this time to listen to me. We are both stuck here.";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    currentText = TextPart.Intro2;
                    timer = 0;
                }
                break;
            case TextPart.Intro2:
                text.text = "We need to find a way out of here, there is a portal nearby we might be able to activate.";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    currentText = TextPart.Intro3;
                    timer = 0;
                }
                break;
            case TextPart.Intro3:
                text.text = "I have seen some keys scattered around in here find them and we shall escape. Ill be following you until then.";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    currentText = TextPart.Intro4;
                    timer = 0;
                }
                break;
            case TextPart.Intro4:
                text.text = "** USE WASD TO MOVE ** USE MOUSE TO LOOK AROUND ** GOOD LUCK **";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    text.enabled = false;
                    timer = 0;
                }
                break;
            case TextPart.Portal1:
                text.enabled = true;
                text.text = "The portal has opened! Lets get out of here! Ill be waiting for you to go in first. ";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    text.enabled = false;
                    currentText = TextPart.Idle;
                    timer = 0;
                }
                break;
            case TextPart.Idle:
                text.enabled = false;
                break;
            case TextPart.NewIntro1:
                text.enabled = true;
                text.text = "Wow, This new dimension looks very dark. However that door looks awfully famiilier.";
                timer += Time.deltaTime;
                if (timer >= 5)
                {
                    currentText = TextPart.NewIntro2;
                    timer = 0;
                }
                break;
            case TextPart.NewIntro2:
                text.text = "This seems to be a puzzle... Matching numbers and Matching colors maybe? Ill be waiting by the door anyways.";
                timer += Time.deltaTime;
                if (timer >= 5)
                {
                    currentText = TextPart.Idle;
                    timer = 0;
                }
                break;
            case TextPart.NewPortal1:
                text.enabled = true;
                text.text = "The door has opened! Great job! Ill be going in first since last time you went first its only fair. See you!";
                timer += Time.deltaTime;
                if (timer >= 7)
                {
                    currentText = TextPart.Idle;
                    timer = 0;
                }
                break;

        }
    }
}
