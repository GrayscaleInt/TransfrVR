namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class Drill : MonoBehaviour
    {
        [Header("Drill settings")]

        public VRTK_InteractableObject linkedObject;
       protected VRTK_ControllerEvents controllerEvents;
        public GameObject DrillBit;
        public float DrillSpeed;
        public iTween.LoopType LoopType;
        public iTween.EaseType EaseType;
        
        public bool IsOn = false;
         

      
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

                 DrillMovement(true);
         }

         protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
         {

             DrillMovement(false);
         }
        

        public void DrillMovement(bool power)
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

       
       

    }
}
