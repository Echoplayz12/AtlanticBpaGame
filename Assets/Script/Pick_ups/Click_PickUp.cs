using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click_PickUp : MonoBehaviour
{
    public GameObject PickUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){

        }
        if(Input.GetMouseButtonUp(0)){

        }
    }

    //GameObject getClickedObject(out RaycastHit hit)
    //{
    //    GameObject target = null;
    //    Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(Ray.origin, Ray.direction = 10, out hit))
    //    {
    //        if (!isPointerOverUIObject()) { target = hit.collider.gameObject; }
    //        return target;
    //    }
    //}
    //private bool isPointerOverUIObject()
    //{
    //    PointerEventData ped = new PointerEventData(EventSystem.current);
    //    ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(ped, results);
    //    return results.Count > 0;
    //}
}