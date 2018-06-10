using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_NewColorPalletConfig : MonoBehaviour {

    public ColorTags m_colorTags;
    public InputField m_colorName;
    public InputField m_r;
    public InputField m_g;
    public InputField m_b;
    public Image m_pickedColor;
    public Button m_submit;
    
    // Use this for initialization
    void Start ()
    {
        m_submit.onClick.AddListener(CheckAndAdd);
        m_r.onValueChanged.AddListener(Refesh);
        m_g.onValueChanged.AddListener(Refesh);
        m_b.onValueChanged.AddListener(Refesh);

    }

    private void Refesh()
    {
        m_r.text = "" + GetColor255Of(m_r);
        m_g.text = "" + GetColor255Of(m_g);
        m_b.text = "" + GetColor255Of(m_b);
        m_pickedColor.color = GetColor();

    }
    private void Refesh(float arg0)
    {
        Refesh();
    }

    private void CheckAndAdd()
    {
        m_colorTags.AddColor(m_colorName.text, GetColor());
    }

    private void Refesh(string arg0)
    {
        Refesh();
    }

    private Color GetColor()
    {
        return new Color(GetColor01Of(m_r), GetColor01Of(m_g), GetColor01Of(m_b));
    }

    private float GetColor01Of(InputField field)
    {
        float result = 0;
        if (float.TryParse(field.text, out result)) {
            result = Mathf.Clamp01(result / 255f);
            return result;
        }
        return 0;
    }
    private float GetColor255Of(InputField field)
    {
        float result = 0;
        if (float.TryParse(field.text, out result))
        {
            result = Mathf.Clamp(result ,0f,255f);
            return result;
        }
        return 0;
    }
}
