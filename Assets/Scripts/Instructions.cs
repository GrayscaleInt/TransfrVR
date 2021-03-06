using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    Text InstructionText;
    [SerializeField] int Step;
    [SerializeField] AudioClip Next;
    [SerializeField] AudioClip End; 
    private AudioSource AudioInstructions;
    Button3D[] Buttons3D = new Button3D[2];


    private void Start()
    {
        AudioInstructions = this.GetComponent<AudioSource>();
        InstructionText = this.GetComponent<Text>();
        SetInstruction(Step);

       // find 3d buttons an disable them 
        Buttons3D = FindObjectsOfType<Button3D>();
        Debug.Log(Buttons3D.Length);

        for (int i = 0; i < Buttons3D.Length; i++)
        {
            Buttons3D[i].gameObject.SetActive(false);
        }



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
                AudioInstructions.PlayOneShot(Next);  // play instruction's beep 
                break;

            case 3:
                InstructionText.text = "Connect the hose to the drill.";
                AudioInstructions.PlayOneShot(Next);  // play instruction's beep 
                break;

            case 4:
                InstructionText.text = "Drill the screw in front of you, all the way.";
                AudioInstructions.PlayOneShot(Next);  // play instruction's beep 
                break;

            case 5:
                InstructionText.text = "Awesome, you are done.";
                AudioInstructions.PlayOneShot(End);   // play instruction's beep 
               
                // enable 3D buttons 
                for(int i=0;i<Buttons3D.Length ; i++ )
                {
                    Buttons3D[i].gameObject.SetActive(true);
                }
                break;
        }
    }

}
