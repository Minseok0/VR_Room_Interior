using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_ChangeView : MonoBehaviour
{
    enum POV{
        originalView = 0,
        TopView =1
    }
    POV pov;
    private void Start()
    {
        pov = POV.originalView;
    }
    // Start is called before the first frame update
    public void ChangePos()
    {
        if(pov == POV.originalView)
            pov = POV.TopView;
        else
            pov = POV.originalView;

            Debug.Log("POV = " + pov);
    }

}
