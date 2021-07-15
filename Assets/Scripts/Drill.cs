namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Drill : MonoBehaviour
    {

        [Header("References")]

        [SerializeField] VRTK_InteractableObject linkedObject;
        


        [Header("Drill settings")]

        [SerializeField] public GameObject DrillBit;
        [SerializeField] public float DrillSpeed;
        [SerializeField] iTween.LoopType LoopType;
        [SerializeField] public iTween.EaseType EaseType;

        public bool IsOn = false;
        protected bool Connected = false; // checks if the hose is connected  

       

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
        }

        protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {

            DrillMovement(false);
        }

    

        public void DrillMovement(bool power)  // drill animation
        {

            if (power == true)
            {
                iTween.RotateAdd(DrillBit, iTween.Hash("z", 180, "time", DrillSpeed, "easetype", EaseType, "looptype", LoopType));
                IsOn = true;
            }
            else
            {
                iTween.Stop();
                IsOn = false;
            }


        }

        public void SetConnected(bool connected) // sets connected 
        {
            Connected = connected; 
        }


        
    }
}
