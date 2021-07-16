namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Drill : MonoBehaviour
    {

        [Header("References")]

        [SerializeField] VRTK_InteractableObject linkedObject;
       // VRTK_InteractHaptics Haptics;
        VRTK_ControllerEvents controllerEvents;


        [Header("Drill settings")]

        [SerializeField] GameObject DrillBit;
        [SerializeField]  float DrillSpeed;
        [SerializeField] iTween.LoopType LoopType;
        [SerializeField] iTween.EaseType EaseType;
        [SerializeField] float HapticStrenght=0.75f; 


        public bool IsOn = false; //checks if drill is on 
        protected bool Connected = false; // checks if the hose is connected  
        
        [Header("Drill sounds")]

        AudioSource AudioDrill;
        [SerializeField] AudioClip DrillDisconnected;
        [SerializeField] AudioClip DrillLoop; 

        private void Start()
        {
            AudioDrill = this.GetComponent<AudioSource>();
           // Haptics = this.GetComponent<VRTK_InteractHaptics>();
            
        }
        
        protected virtual void OnEnable()
        {
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
           
            if (linkedObject != null)
            {

                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
                linkedObject.InteractableObjectUnused += InteractableObjectUnused;
            }

        }

        protected virtual void OnDisable()
        {
            if (linkedObject != null)
            {

                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
                linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
            }

        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
           
            if (Connected == true)
            {
                DrillMovement(true);            
             
            }
           
                SetDrillAudio(0);  //Play audio Drill Disconnected


        }

        protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {

            DrillMovement(false);
         

        }

     /*  protected virtual void StartUsing(VRTK_InteractUse currentUsingObject = null)
        {
            
            controllerEvents = currentUsingObject.GetComponent<VRTK_ControllerEvents>();
        }

        protected virtual void StopUsing(VRTK_InteractUse currentUsingObject = null)
        {
            controllerEvents = null;
        }*/

        public void DrillMovement(bool power)  // drill animation
        {

            if (power == true)
            {
                iTween.RotateAdd(DrillBit, iTween.Hash("z", 180, "time", DrillSpeed, "easetype", EaseType, "looptype", LoopType));
                IsOn = true;
                SetDrillAudio(1); // Play audio Drill Loop 
            }
            else
            {
                iTween.Stop();
                IsOn = false;
                SetDrillAudio(2); // StopAudio
            }


        }

        public void SetConnected(bool connected) // sets connected 
        {
            Connected = connected; 
        }

        void SetDrillAudio(int DrillState) //Changes drill audio
        {
            switch (DrillState)
            {
                case 0: // Drill disconected
                    AudioDrill.PlayOneShot(DrillDisconnected); 
                    break;
                case 1: // Dril Loop
                    AudioDrill.PlayOneShot(DrillLoop);
                    break;

                case 2: // Dril stop
                    AudioDrill.Stop(); 
                    break;
            }
        }

        private void Update()
        {
           
        }




    }
}
