using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backT : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            //uncommant the code and input the scene number in between the parentheses
            //And changethe tag on the object in the UNITY or create a tag 

            SceneManager.LoadScene(1);
        }
    }
}
