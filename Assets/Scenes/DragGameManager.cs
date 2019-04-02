using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGameManager : MonoBehaviour
{

 
   // public LayerMask TouchInputMask;
    //This mask makes sure that only things we want to react to the raycast are reacting.

   // private Vector3 pos;
   // private Vector3 touchedPos;
    //https://www.youtube.com/watch?v=p7akGCRgBLA
    [SerializeField]
    private Transform bearPlace;
    private Vector2 initialPosition;
    private Vector2 mousePosition;
    public float deltaX, deltaY;
    public static bool locked;

    void Start()
    {
        Debug.Log("merge:");
        initialPosition = transform.position;
        Debug.Log("merge:");
        // Input.multiTouchEnabled = true;
        //Saving this here in case we want to revert the object back to it's original position
    }


    private void OnMouseDown()
    {
        Debug.Log("merge:");
        if (!locked) { 
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
            Debug.Log("merge:");
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
            if(Mathf.Abs(transform.position.x- bearPlace.position.x) <=0.5f &&
                Mathf.Abs(transform.position.y-bearPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    /*void Update()
    {
        //If mouse button 0 is down
      
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
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

    }*/
}

