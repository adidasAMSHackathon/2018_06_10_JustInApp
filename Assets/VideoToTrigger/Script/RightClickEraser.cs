using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickEraser : MonoBehaviour {

    public Paint3DController m_meshPainter; 

    public Color m_erasingColor= Color.white;
    public Color m_usedColor = Color.white;

    void Update () {


        if (Input.GetMouseButtonDown(1))
        {
            m_usedColor = m_meshPainter.GetColor() ;
            m_meshPainter.SetColor(m_erasingColor);
        }
        if (Input.GetMouseButtonUp(1))
        {
            m_meshPainter.SetColor( m_usedColor);
            m_usedColor = m_erasingColor;
        }
    }

    public void Reset() {
        if(m_meshPainter!=null)
          m_meshPainter = GetComponent<Paint3DController>();
    }
}
