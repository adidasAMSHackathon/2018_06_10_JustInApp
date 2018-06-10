using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InkTool : MonoBehaviour {


    public Paint3DController m_painter;
    public CursorColor m_cursor;
    
    [Header("Debug")]
    public bool m_waitNextInput;

    public void CaptureNextColor() {
        m_waitNextInput=true;
    }
	void Update () {
      

        if (!m_waitNextInput)
            return;
        if (Input.GetMouseButtonDown(0) )
        {

            CaptureColor();
        }
		
	}

    public void CaptureColor()
    {
        m_painter.SetColor(m_cursor.m_textureColor);
        m_waitNextInput = false;
    }
}
