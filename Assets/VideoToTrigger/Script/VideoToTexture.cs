using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class VideoToTexture : MonoBehaviour {

    public string m_recName= "Default";
    public VideoPlayer m_video;
    public GetDirectoryPath m_directoryAbsolutPath;

    [Header("Debug")]
    public RenderTexture m_renderTexture;
    public Texture2D m_lastRecorded;

	void Start () {

    }

    public void Clear() {

        if (Directory.Exists(m_directoryAbsolutPath.GetValue()))
            Directory.Delete(m_directoryAbsolutPath.GetValue(), true);
    }
	
	

    public  void Capture()
    {
        m_renderTexture = (RenderTexture)m_video.texture;
        RenderTexture.active = m_renderTexture;
        m_lastRecorded = new Texture2D(m_renderTexture.width, m_renderTexture.height);
        m_lastRecorded.ReadPixels(new Rect(0, 0, m_renderTexture.width, m_renderTexture.height), 0, 0);
        m_lastRecorded.Apply();


        Directory.CreateDirectory(m_directoryAbsolutPath.GetValue());
        File.WriteAllBytes(m_directoryAbsolutPath + "/" + m_recName + "_" + m_video.frame + "_" + (System.Math.Round(m_video.time, 2)) + ".jpg", m_lastRecorded.EncodeToJPG());
    }
    
}
