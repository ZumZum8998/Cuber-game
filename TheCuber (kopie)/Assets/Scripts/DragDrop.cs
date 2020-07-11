using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    private bool selected;
    private float startPosX;
    private float startPosY;

    void Update()
    {
        if(selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);

            startPosX = cursorPos.x - this.transform.localPosition.x;
            startPosY = cursorPos.y - this.transform.localPosition.y;

            this.gameObject.transform.localPosition = new Vector2(cursorPos.x - startPosX, cursorPos.y - startPosY);

        }
        if(Input.GetMouseButtonUp(0))
        {

            selected = false;

        }

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;

        }
    }


}
