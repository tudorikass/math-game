using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGameManager : MonoBehaviour
{


    public LayerMask TouchInputMask;
    //This mask makes sure that only things we want to react to the raycast are reacting.

    private Vector3 pos;
    private Vector3 touchedPos;


    void Start()
    {
        Input.multiTouchEnabled = true;
        pos = new Vector3(transform.position.x, transform.position.y);
        //Saving this here in case we want to revert the object back to it's original position
    }
    private Vector3 offset;

    private float dist;
    private Vector3 v3Offset;
    private Plane plane;
    private bool ObjectMouseDown = false;
    public GameObject linkedObject;

    void OnMouseDown()
    {
        plane.SetNormalAndPosition(Camera.main.transform.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float dist;
        plane.Raycast(ray, out dist);
        v3Offset = transform.position - ray.GetPoint(dist);
        ObjectMouseDown = true;
    }

    void OnMouseDrag()
    {
        if (ObjectMouseDown == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dist;
            plane.Raycast(ray, out dist);
            Vector3 v3Pos = ray.GetPoint(dist);
            v3Pos.z = gameObject.transform.position.z;
            v3Offset.z = 0;
            transform.position = v3Pos + v3Offset;

            if (linkedObject != null)
            {
                linkedObject.transform.position = v3Pos + v3Offset;
            }
        }
    }

    void OnMouseOut()
    {
        ObjectMouseDown = false;
    }

    void Update()
    {
        //If mouse button 0 is down
      
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            //This only pays attention if the finger is touching for more than a frame.

            {
                Touch touch = Input.GetTouch(i);
                touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                //For some reason that 10 is very neccessary!!

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                //Build a ray from where the touch position is to where the camera is.

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, TouchInputMask))
                //Check to see if that ray, heading out until infinity, hits anything that has the TouchInputMask as it's layermask.

                {
                    GameObject thisWasHit = hit.transform.gameObject;
                    //Turn the RaycastHit object into a gameobject.

                    if (thisWasHit == this.gameObject)
                    //Check if the the object that was hit was this object.

                    {
                        transform.position = touchedPos;
                        //Change the position of this object to equal that of the finger touch.

                        print("this object was hit!");
                    }
                }
            }
        }

    }
}

