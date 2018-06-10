using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public string m_sceneToLoad;
    public float m_timeToLoad=1f;

    public void LoadScene()
    {
        SceneManager.LoadScene(m_sceneToLoad);

    }
    public void LoadSceneWithDelay()
    {
        Invoke("LoadScene", m_timeToLoad);
    }

}
