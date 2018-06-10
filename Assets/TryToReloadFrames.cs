using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class TryToReloadFrames : MonoBehaviour {

    public VideoPlayer m_video;
    public RenderTexture m_rendererTexture;
    public GetDirectoryPath m_framesDirectory;

    // Use this for initialization
    public void CheckForExistingFrame()
    {
        CheckForExistingFrame((int)m_video.frame);
    }
    public void LoadPreviousFrame()
    {
        CheckForExistingFrame((int)m_video.frame - 1);
    }
    public void CheckForExistingFrame(int frameNumber) {
        string filePath = LookForFrame(m_framesDirectory.GetValue(), frameNumber);
        if (!string.IsNullOrEmpty(filePath))
        {
            Texture2D tex = new Texture2D(2, 2);
           // Debug.Log("Found one(" + frameNumber + "):" + filePath);
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);

                tex.LoadImage(fileData);
            }

            Graphics.Blit(tex, m_rendererTexture);
        }

    }
    

    public static string LookForFrame(string directoryPath, int frameNumber)
    {
        Directory.CreateDirectory(directoryPath);
        string[] files = Directory.GetFiles(directoryPath);

        for (int i = 0; i < files.Length; i++)
        {
            if ( files[i].Contains(string.Format("{0:00000000}", frameNumber) ))
                return files[i];

        }
        return null;
    }
    
}
