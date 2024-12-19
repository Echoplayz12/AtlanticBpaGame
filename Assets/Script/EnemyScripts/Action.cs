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
    public virtual void Interact ()
    {

    }
    void Update()
    {
        //code provide by our sweet and lovely Matt
        //the code gets user mouse left input and the code cast a ray
        //if ray hit something it gonna take damage
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, playerATKrange))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                Debug.Log("Hit " + hit.collider.name + " " + hit.point);

                if (interactable != null)
                {
                }
                //animation for attacking 
                //deals damage if it hits enemy
            }
        }
    }
}
