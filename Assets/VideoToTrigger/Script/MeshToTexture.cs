using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class MeshToTexture  : MonoBehaviour
{

    public string m_recName = "Default";
    public VideoPlayer m_video;
    public Renderer m_renderer;
    public string m_directoryAbsolutPath;

    [Header("Debug")]
    public Texture2D m_lastRecorded;

    void Start()
    {
        
    }

    public void Clear()
    {

        if (Directory.Exists(m_directoryAbsolutPath))
            Directory.Delete(m_directoryAbsolutPath, true);
    }
    public void Capture()
    {
        m_lastRecorded = m_renderer.material.mainTexture as Texture2D;
        if (m_lastRecorded == null)
            return
                ;
        Texture2D t = new Texture2D(m_lastRecorded.width, m_lastRecorded.height);
        t.SetPixels(m_lastRecorded.GetPixels());
        Directory.CreateDirectory(m_directoryAbsolutPath);
        File.WriteAllBytes(m_directoryAbsolutPath + "/" + m_recName + "_" + m_video.frame + "_" + (System.Math.Round(m_video.time, 2)) + ".png", t.EncodeToPNG());
    }

    public void OnValidate()
    {
        if (string.IsNullOrEmpty(m_directoryAbsolutPath))
            m_directoryAbsolutPath = Application.dataPath;
    }

    public void Reset()
    {
        m_directoryAbsolutPath = Application.dataPath;
    }
}