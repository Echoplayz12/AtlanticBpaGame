using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField]
    public int playerATKrange = 0;

    public LayerMask enemy;
    Camera cam; 


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, playerATKrange, enemy))
            {
                Debug.Log("Hit " + hit.collider.name + " " + hit.point);
                //animation for attacking 
                //deals damage if it hits enemy


            }
        }
    }
}
