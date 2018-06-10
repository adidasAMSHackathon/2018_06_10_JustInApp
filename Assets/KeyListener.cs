using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyListener : MonoBehaviour {

    public KeyCode m_key;
    public OnKeyEvent m_pressing;
    public OnKeyEvent m_down;
    public OnKeyEvent m_up;

    [System.Serializable]
    public class OnKeyEvent : UnityEvent<KeyCode>{}
    
	void Update () {

        if (Input.GetKeyDown(m_key))
            m_down.Invoke(m_key);
        if (Input.GetKeyUp(m_key))
            m_up.Invoke(m_key);

        if (Input.GetKey(m_key))
            m_pressing.Invoke(m_key);

    }
}
