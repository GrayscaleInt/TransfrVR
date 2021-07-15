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

        [SerializeField] Instructions InstructionsRef;

        float ScrewFinalPos;
        float ScrewStartPos;
        Vector3 pos;
        float timeElapsed = 0;
        bool ScrewAllTheWay=false;

        

        private GameObject objectRef;
        //public GameObject DrillRef;
     //   public Drill DrillRef; 


        private void Start()
        {
            // Set start references

            objectRef = this.gameObject;
            pos = objectRef.transform.position;
            ScrewStartPos = transform.position.y;
            ScrewFinalPos = ScrewStartPos - 0.1f;
            print(ScrewStartPos);


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
            }
            else
            {
                ScrewAllTheWay = true;
                InstructionsRef.SetInstruction(5);
            }
        }
        /*private void OnMouseDown()
        {

            Drilling = true; 

        }
        private void OnMouseUp()
        {
           Drilling = false; 
        }
        */
     /*   private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Drill")
             {
                //DrillRef = other; 
                ScrewMovement();
                 Debug.Log("Collision");
             }

           

           

        }*/


        private void Update()
        {
            /*if(Drilling== true)
            {
                ScrewMovement();
            }*/


        }

    }
}
