using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CompleteFrame : MonoBehaviour {

    public VideoPlayerInterface m_video;
    public RendererToTexture m_rendererToTexture;
    public Paint3DController m_painter;
    public Text m_currentFrame;
    public Text m_totalFrame;
    public bool m_completeAtStart;
    public int m_index;
    public void Start()
    {
        if(m_completeAtStart)
            StartCompleteCoroutine( );
    }
    [ContextMenu("Complete with empty file")]
    public void StartCompleteCoroutine()
    {
        StartCoroutine(Complete());

    }
    public IEnumerator Complete () {

        for (int i = 0; i < (int) m_video.GetTotalFrame(); i++)
        {
            m_index = i;
            string filepath = TryToReloadFrames.LookForFrame(m_rendererToTexture.m_directoryAbsolutPath.GetValue(), i);
            if (filepath == null) {
                m_painter.Clear();
                m_rendererToTexture.CaptureWith(i);
            }
            yield return new WaitForSeconds(0.1f);
        }
        
		
	}
	
	void Update ()
    {
        m_currentFrame.text = "" + m_video.GetFrame();
        m_totalFrame.text = "" + m_video.GetTotalFrame();


    }
}
