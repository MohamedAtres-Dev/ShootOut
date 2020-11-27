using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static bool tap;
    
    private void Update()
    {
        DetectSwipe();
        
    }

    public void DetectSwipe()
    {
        //to sure that values are reset 
        tap = false;
        //to detect touches
        if (Input.touches.Length != 0)
        {

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
            }
        }
        else

        // this is for Mouse Input
        {
            if (Input.GetMouseButtonDown(0))
            {
                tap = true;
            }
        }

    }

    
}
