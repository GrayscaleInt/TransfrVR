namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class DrillBit : MonoBehaviour
    {
        public Drill DrillRef;
        public Screw ScrewRef; 
    
    private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Screw" && DrillRef.IsOn==true)
            {
                ScrewRef.ScrewMovement();
            }
           

        }

     /*  private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Screw" && DrillRef.IsOn == true)
            {
                
               ScrewRef.SetScrewAudio(1); // play screw drill audio 

            }
        }*/
        private void OnTriggerExit(Collider other)
        {
            ScrewRef.SetScrewAudio(0); // stops screw audio
        }
    }
    
}
    
