namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Screw : MonoBehaviour
    {
        // Screw movement 

        [Header("Screw Movement")]

        [SerializeField] float ScrewTime = 10;
        [SerializeField] float ScrewRotSpeed = 180;
        [SerializeField] float WoodThickness=0.03f; 
        [SerializeField] AudioClip ScrewDrilling;
        [SerializeField] AudioClip ScrewStops;


        [SerializeField] Instructions InstructionsRef;

        float ScrewFinalPos;
        float ScrewStartPos;
        Vector3 pos;
        float timeElapsed = 0;
        bool ScrewAllTheWay=false;
        bool HasPlayedAudio1=false;
        bool HasPlayedAudio2 = false;
      

        private GameObject objectRef;
        AudioSource AudioScrew; 


        private void Start()
        {
            // Set start references

            objectRef = this.gameObject;
            pos = objectRef.transform.position;
            ScrewStartPos = transform.position.y;
            ScrewFinalPos = ScrewStartPos - WoodThickness;
           
            AudioScrew = this.GetComponent<AudioSource>(); 

        }
        public void ScrewMovement() //changes the screw position and rotation
        {

            if (timeElapsed < ScrewTime)
            {

                float NewY = Mathf.Lerp(ScrewStartPos, ScrewFinalPos, timeElapsed / ScrewTime);
                Debug.Log(NewY);
                transform.position = new Vector3(pos.x, NewY, pos.z);
                transform.Rotate(new Vector3(0f, ScrewRotSpeed, 0f), Space.Self);
                timeElapsed += Time.deltaTime;

               SetScrewAudio(1);// play screw drilling audio
            }
            else
            {
                if (ScrewAllTheWay == false)
                {
                    ScrewAllTheWay = true;
                    InstructionsRef.SetInstruction(5);
                    SetScrewAudio(0);
                }
             
                SetScrewAudio(2); // play screw stops audio
            }
        }
       
        public void SetScrewAudio(int ScrewState)
        {
            switch (ScrewState)
            {
                case 0:
                    AudioScrew.Stop(); //Stop all screw audio
                    HasPlayedAudio1 = false;
                    HasPlayedAudio2 = false;
                    break;
                case 1:
                   if (HasPlayedAudio1 == false)
                   {
                        AudioScrew.PlayOneShot(ScrewDrilling);  //Play screw drilling 
                        HasPlayedAudio1 = true; 
                   }
                    break;
                case 2:
                   if (HasPlayedAudio2 == false)
                   {
                      
                        AudioScrew.PlayOneShot(ScrewStops); //Play screw stops
                        HasPlayedAudio2 = true;
                   }
                    
                    break;

            }
        }


    }
}
