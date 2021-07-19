using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    public delegate void TapAction(Touch t);
    public static event TapAction onTap;


    public Vector2 movement;
    public float tapMaxmovement = 50f;
    bool tapGseture = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                movement = Vector2.zero;
                print("Touched");
            }
            else if(touch.phase==TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                print("Touched");
                movement = movement + touch.deltaPosition;
                if (movement.magnitude > tapMaxmovement)
                {
                    tapGseture = true;
                }
            }
            else
            {
                if (!tapGseture)
                {
                    if (onTap != null)
                    {
                        onTap(touch);
                    }
                    tapGseture = false;
                }
            }
        }
    }
}
