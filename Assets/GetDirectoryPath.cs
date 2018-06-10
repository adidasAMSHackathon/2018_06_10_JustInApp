using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetDirectoryPath : MonoBehaviour {

    public string m_directoryPath;
    public bool m_createIfNotExisting=true;
	void Awake () {
        if(m_createIfNotExisting && !Directory.Exists(m_directoryPath)){
            Directory.CreateDirectory(m_directoryPath);
        }
		
	}
    public string GetValue() {
        return m_directoryPath;
    }

    public void OpenDirectry() {
        Application.OpenURL(m_directoryPath);
    }

    public void OnValidate()
    {
        CheckPathToNotBeEmpty();
    }

    public void Reset()
    {
        CheckPathToNotBeEmpty();
    }

    private void CheckPathToNotBeEmpty()
    {
        if (m_directoryPath == "")
            m_directoryPath = Application.dataPath;
    }
}
