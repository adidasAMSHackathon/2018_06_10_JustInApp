using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SynchVideoToVideos : MonoBehaviour {

    public VideoPlayer m_video;
    public VideoPlayer[] m_videoToSynchronised;
    public float m_synchTime = 5;
	
	IEnumerator Start () {

        while (true) {

        foreach (VideoPlayer vid in m_videoToSynchronised)
        {
            vid.frame = m_video.frame;

        }

            yield return new WaitForSeconds(m_synchTime);
        }

		
	}
}
