using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndReloadColorTags : MonoBehaviour {

    public ColorTags m_tags;
    public bool m_runtimeEditable=true;
    public GetDirectoryPath m_jsonSaveDirectoryPath;
    void Start () {
		
	}

    private void OnDestroy()
    {
        if (Application.isPlaying && m_runtimeEditable)
        {
            SaveInTemp();
        }
    }

    private void SaveInTemp()
    {
        string path = GetPath();
        string json= JsonUtility.ToJson(m_tags.m_tagsList);
        File.WriteAllText(path, json);

        if (!string.IsNullOrEmpty(m_jsonSaveDirectoryPath.GetValue())) {
            if (!Directory.Exists(m_jsonSaveDirectoryPath.GetValue()))
                Directory.CreateDirectory(m_jsonSaveDirectoryPath.GetValue());
        
            File.WriteAllText(m_jsonSaveDirectoryPath.GetValue() + PathFileName(), json);
#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }

    private string GetPath()
    {
        return Application.temporaryCachePath + PathFileName();
    }

    private string PathFileName()
    {
        return  "/" + m_tags.m_tagsList.m_name + ".json";
    }

    private void OnValidate()
    {
        string path = GetPath();

        if (!Application.isPlaying && File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LoadFrom(json);
            File.Delete(path);
        }
        //if (!string.IsNullOrEmpty(m_jsonLoader))
        //{
        //    LoadFrom(m_jsonLoader);
        //    m_jsonLoader = "";
        //}
        
                             
                             
                             
                             
    }
    

    private void LoadFrom(string json)
    {
        try
        {

            m_tags.m_tagsList = JsonUtility.FromJson<ColorTagsList>(json);
        }
        catch (Exception e ) { Debug.LogWarning(e); }
    }
}
