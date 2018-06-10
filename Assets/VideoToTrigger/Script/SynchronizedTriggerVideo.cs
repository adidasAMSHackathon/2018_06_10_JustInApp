using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SynchronizedTriggerVideo : MonoBehaviour {

    [Range(0,1f)]
    public float m_pourcent;
    public VideoPlayerInterface [] m_videoInterfaces;
    
	
    public void OnValidate()
    {
        for (int i = 0; i < m_videoInterfaces.Length; i++)
        {
            m_videoInterfaces[i].SetMusicTimeTo(m_pourcent);

        }
    }

}
