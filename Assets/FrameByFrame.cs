using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameByFrame : MonoBehaviour {

    public VideoPlayerInterface m_video;
    public RendererToTexture m_renderToTexture;
    public TryToReloadFrames m_reloaderFrame;


    public void NextFrame(int frame = 1)
    {
        m_renderToTexture.Capture();
        m_video.NextFrame(frame);
        int currentframe = (int)m_video.NextFrame(frame);
    }
    

    public void PreviousFrame(int frame = 1)
    {
        
        m_renderToTexture.Capture();
        int currentframe =(int) m_video.PreviousFrame(frame);
        //m_reloaderFrame.CheckForExistingFrame(currentframe);
    }

  
}
