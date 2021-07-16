using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    Text InstructionText;
    [SerializeField] int Step;
    private AudioSource AudioInstructions; 

    private void Start()
    {
        AudioInstructions = this.GetComponent<AudioSource>();
        InstructionText = this.GetComponent<Text>();
        SetInstruction(Step);
        

    }
    public void SetInstruction(int step)
    {
        
        switch (step)
        {
            case 1:
                InstructionText.text = "Grab the drill.";
                break;

            case 2:
                InstructionText.text = "With the other hand, grab the hose.";
                AudioInstructions.Play();  // play instruction's beep 
                break;

            case 3:
                InstructionText.text = "Connect the hose to the drill.";
                AudioInstructions.Play();  // play instruction's beep 
                break;

            case 4:
                InstructionText.text = "Drill the screw in front of you, all the way.";
                AudioInstructions.Play();  // play instruction's beep 
                break;

            case 5:
                InstructionText.text = "Awesome, you are done.";
                AudioInstructions.Play();  // play instruction's beep 
                break;
        }
    }

}
