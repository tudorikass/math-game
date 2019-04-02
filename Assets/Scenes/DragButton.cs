using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragButton : MonoBehaviour
{
    public Rect playerPositionRect = new Rect(0, 151, 200, 50);
    private Vector2 currentDrag = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.Box(playerPositionRect, "MyButton");

        Vector2 screenMousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        if (currentDrag.sqrMagnitude != 0 || playerPositionRect.Contains(screenMousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentDrag = screenMousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                playerPositionRect.x += (screenMousePosition.x - currentDrag.x);
                playerPositionRect.y += (screenMousePosition.y - currentDrag.y);

                currentDrag = screenMousePosition;
            }
            else
            {
                currentDrag.x = 0;
                currentDrag.y = 0;
            }
        }
    }
}
