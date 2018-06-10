using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioSourcePlayerInterface : MonoBehaviour
{

    public AudioSource m_audioSource;
    [Range(0, 1f)]
    public float m_musicTimer;
    public OnTimeChangeEvent m_onTimeChanged;
    [System.Serializable]
    public class OnTimeChangeEvent : UnityEvent <float>{ }


    public void Update()
    {
        SetMusicTimeTo( m_audioSource.time / m_audioSource.clip.length);

    }

    public void OnValidate()
    {
        SetMusicTimeTo(m_musicTimer);
    }

    public void SetMusicTimeTo(float timePourcent)
    {

        timePourcent = Mathf.Clamp(timePourcent,0,0.999999f);
        m_audioSource.timeSamples = (int)(m_audioSource.clip.frequency * m_audioSource.clip.length * timePourcent) ;
        m_musicTimer = timePourcent;
        m_onTimeChanged.Invoke(timePourcent);
    }

    public void ResetToZero()
    {
        m_audioSource.timeSamples = 0;
    }
    public void Play()
    {
        m_audioSource.Play();
    }
}
