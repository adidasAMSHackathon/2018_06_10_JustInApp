using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerInfoOnColor : MonoBehaviour {

    public ColorTags m_tags;
    public Text m_text;
    public int precision = 5;

    public void OnColorProposition ( Color color) {
        m_text.text = m_tags.GetTagOf(color, precision);

    }
}
