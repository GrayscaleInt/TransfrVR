using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button3D : MonoBehaviour
{
    [SerializeField] Material MaterialChange;
    [SerializeField] int SceneToLoad; 


    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().material = MaterialChange;
        SceneManager.LoadScene(SceneToLoad); 

    }
}
