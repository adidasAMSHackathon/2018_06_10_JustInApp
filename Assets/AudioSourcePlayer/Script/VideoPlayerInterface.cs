using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoPlayerInterface : MonoBehaviour
{

    public VideoPlayer m_videoPlayer;
    [Range(0, 1f)]
    public float m_musicTimer;
    public OnTimeChangeEvent m_onTimeChanged;
    [System.Serializable]
    public class OnTimeChangeEvent : UnityEvent<float> { }
    public OnFrameChangeEvent m_onFrameChanged;
    [System.Serializable]
    public class OnFrameChangeEvent : UnityEvent<long> { }

    public UnityEvent m_onVideoEndReach;
    internal ulong GetTotalFrame()
    {
       return  m_videoPlayer.frameCount;
    }

    [Header("Debug")]
    [Range(0, 1f)]
    public float m_musicTimerViewer;
    public double m_musicTime;

    public void Update()
    {
        m_musicTimerViewer = (float)((double)m_videoPlayer.frame / (double)m_videoPlayer.frameCount);
        m_musicTime = m_videoPlayer.time;

        
        currentFrame = m_videoPlayer.frame;
        if (currentFrame != previousFrame)
            m_onFrameChanged.Invoke(currentFrame);
        previousFrame = currentFrame;

        if ((ulong)currentFrame == m_videoPlayer.frameCount)
            m_onVideoEndReach.Invoke();



    }
    private long previousFrame = 0;
    public long currentFrame = 0;

    internal long GetFrame()
    {
        return m_videoPlayer.frame;
    }

    public void OnValidate()
    {
        SetMusicTimeTo(m_musicTimer );
    }

    public void SetMusicTimeTo(float timePourcent)
    {

        timePourcent = Mathf.Clamp(timePourcent, 0, 0.999999f);
        m_videoPlayer.frame = (int)(m_videoPlayer.frameCount * timePourcent);
        RefreshCursorTime(timePourcent);


    }

    private void RefreshCursorTime(float timePourcent)
    {
        //m_musicTimer = timePourcent;
        m_onTimeChanged.Invoke(timePourcent);
    }

    public void ResetToZero()
    {
        m_videoPlayer.frame = 0;
    }
    public void Play()
    {
        m_videoPlayer.Play();
    }
    public void Pause() {
        m_videoPlayer.Pause();
    }
    public void SwitchState() {
        if (m_videoPlayer.isPlaying)
            Pause();
        else Play();
    }

    public void BackInTime(float time) {
        double newTime = m_videoPlayer.time -time;
        if (newTime < 0f) newTime = 0;
        m_videoPlayer.time = newTime;


    }


    public long NextFrame(int frame = 1) {
        m_videoPlayer.frame += frame;
        return m_videoPlayer.frame + frame;
    }
    public long PreviousFrame(int frame = 1) {
        m_videoPlayer.frame -= frame;
        return m_videoPlayer.frame - frame;
    }
    public double AddTime(float second = 1) {
        m_videoPlayer.time += second;
        return m_videoPlayer.time + second;
    }
    public double RemoveTime(float second = 1) {
        m_videoPlayer.time -= second;
        return m_videoPlayer.time + second;
    }
}
