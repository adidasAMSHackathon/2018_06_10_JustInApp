
using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(AudioSourcePlayerInterface))]
[CanEditMultipleObjects]
public class AudioSourcePlayerInterfaceEditor : Editor
{

    public static string m_lookFor;
    public override void OnInspectorGUI()
    {
        AudioSourcePlayerInterface source  = (AudioSourcePlayerInterface)target;

        DrawDefaultInspector();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Replay"))
        {
            source.m_audioSource.time = 0;
            source.m_audioSource.Play();


        }


        EditorGUILayout.EndHorizontal();
       


    }
}
