using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBoardToAction : MonoBehaviour {

    public Mapping[] m_mapping;

    [System.Serializable]
    public class Mapping {
        public string m_desctiption;
        public KeyCode[] m_linkedKeys;
        public UnityEvent m_toDo;


    }

    //public KeyCode[] previousFrame = new KeyCode[] { KeyCode.RightArrow, KeyCode.Keypad6 };
    //public KeyCode[] nextFrame = new KeyCode[] { KeyCode.LeftArrow, KeyCode.Keypad4 };

    //public KeyCode[] copyLastFramePainting = new KeyCode[] { KeyCode.DownArrow, KeyCode.Keypad5 };

    //public KeyCode[] cleanPainting = new KeyCode[] { KeyCode.UpArrow, KeyCode.Keypad8 };

    //public KeyCode[] inkMirror = new KeyCode[] { KeyCode.Keypad9 };
    //public KeyCode[] playPause = new KeyCode[] { KeyCode.Keypad7 };


    //public KeyCode[] moveFarestInVideo = new KeyCode[] { KeyCode.KeypadPlus };
    //public KeyCode[] moveEarlierInVideo = new KeyCode[] { KeyCode.KeypadMinus };
    
	void Update () {

        for (int i = 0; i < m_mapping.Length; i++)
        {
            if (IsOneDown(m_mapping[i].m_linkedKeys))
                m_mapping[i].m_toDo.Invoke();
        }
		
	}

    //TOADDINUTILITY
    public bool IsOneDown(KeyCode[] keys)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
                return true;
        }
        return false;
    }
    public bool IsAllDown(KeyCode[] keys)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (!Input.GetKeyDown(keys[i]))
                return false;
        }
        return true;
    }
}
