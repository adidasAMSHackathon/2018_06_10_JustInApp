using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputFieldUtility : MonoBehaviour {

    public InputField m_linked;
    // Use this for initialization
    public void SetValue(float value)
    {

        SetValue("" + value);
    }
    public void SetValue(int  value)
    {
        SetValue("" + value);
    }
    public void SetValue(string value)
    {
        m_linked.text = value;
    }
    // Update is called once per frame
    void Awake () {
        m_linked = GetComponent<InputField>();
	}
}
