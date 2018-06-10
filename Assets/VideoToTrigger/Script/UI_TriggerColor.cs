using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_TriggerColor : MonoBehaviour {

    [Header("Params")]
    public string m_tag;
    public Color m_color;
    public OnColorChangeEvent m_toDo;

    [Header("UI")]
    public Text m_tTag;
    public Text m_tColor;
    public Image m_imgBackground;
    public Button m_button;


    public void  SetPanelWith (string tag, Color color, OnColorChangeEvent toDo)
    {
        m_color = color;
        m_tag = tag;
        m_tTag.text = tag;
        m_tColor.text = string.Format("R:{0:000} G:{1:000} B:{2:000}", color.r*255, color.g * 255, color.b * 255);
        m_toDo = toDo;
        m_button.onClick.AddListener(InvotkeToDo);
        m_button.image.color = m_color;
        m_imgBackground.color = m_color;

    }

    private void InvotkeToDo()
    {
        m_toDo.Invoke(m_color);
    }
}
