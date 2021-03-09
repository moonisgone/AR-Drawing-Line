using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool _pressed = false;
    public ARDrawLine aRDrawLine;

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        aRDrawLine.StopDrawLine();
    }


    // Update is called once per frame
    void Update()
    {

        if (_pressed)
        {
            aRDrawLine.StartDrawLine();
        }

    }
}
