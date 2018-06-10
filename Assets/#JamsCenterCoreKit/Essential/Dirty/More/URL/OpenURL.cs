using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour {

    public string m_url="http://www.google.com/";
    public bool m_loadAtStart = false;

    private void Awake()
    {
        if (m_loadAtStart)
            LoadPage();
    }
    public void LoadPage (string url) {
        Application.OpenURL(url);
	}
    public void LoadPage()
    {
        LoadPage(m_url);
    }

}
