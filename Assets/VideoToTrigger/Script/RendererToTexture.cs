using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class RendererToTexture : MonoBehaviour
{

    public string m_recName = "Default";
    public VideoPlayer m_video;
    public RenderTexture m_renderer;
    public GetDirectoryPath m_directoryAbsolutPath;

    [Header("Debug")]
    public Texture2D m_lastRecorded;
    
    public Rect r_rendererSize;
    public void Start()
    {
        m_lastRecorded = new Texture2D(m_renderer.width, m_renderer.height);
        r_rendererSize = new Rect(0, 0, m_renderer.width, m_renderer.height);

    }

    public void Clear()
    {

        if (Directory.Exists(m_directoryAbsolutPath.GetValue()))
            Directory.Delete(m_directoryAbsolutPath.GetValue(), true);
    }



    public void Capture()
    {

        RenderTexture.active = m_renderer;
        m_lastRecorded.ReadPixels(r_rendererSize, 0, 0);
        m_lastRecorded.Apply();

        bool dirExist = Directory.Exists(m_directoryAbsolutPath.GetValue());
        if (!dirExist)
            Directory.CreateDirectory(m_directoryAbsolutPath.GetValue());
        if(dirExist)
        File.WriteAllBytes(m_directoryAbsolutPath.GetValue() + "/" + m_recName + "_" + string.Format("{0:00000000}", m_video.frame) /*+ "_" + (System.Math.Round(m_video.time, 2))*/ + ".jpg", m_lastRecorded.EncodeToJPG());
    }


    //DIRTY LIKE HELL
    public void CaptureWith(int frame)
    {

        RenderTexture.active = m_renderer;
        m_lastRecorded = new Texture2D(m_renderer.width, m_renderer.height);
        m_lastRecorded.ReadPixels(new Rect(0, 0, m_renderer.width, m_renderer.height), 0, 0);
        m_lastRecorded.Apply();


        Directory.CreateDirectory(m_directoryAbsolutPath.GetValue());
        File.WriteAllBytes(m_directoryAbsolutPath.GetValue() + "/" + m_recName + "_" + string.Format("{0:00000000}", frame) /*+ "_" + (System.Math.Round(m_video.time, 2))*/ + ".jpg", m_lastRecorded.EncodeToJPG());
    }
    
    
}