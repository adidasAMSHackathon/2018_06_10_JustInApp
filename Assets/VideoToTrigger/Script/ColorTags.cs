using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ColorTags : MonoBehaviour {
    
    public ColorTagsList m_tagsList;
    public OnColorChangeEvent m_onColorAdded;
    public UnityEvent m_onEdited;


    public ColorTag[] targeted;
    internal string GetTagOf(Color color, int precision)
    {
        targeted = m_tagsList.m_tags.Where(k => GetColorDifferenceScore(k.m_color, color)<precision).OrderBy(k => GetColorDifferenceScore(k.m_color, color)).ToArray();
        if (targeted.Length > 0 && GetColorDifferenceScore(color , targeted[0].m_color)<precision)
            return targeted[0].m_tag;
        return null;
    }
    internal string GetTagOf(Color color)
    {
        ColorTag[] targeted;
        targeted = m_tagsList.m_tags.Where(k => k.m_color == color).ToArray();
        if (targeted.Length > 0)
            return targeted[0].m_tag;
        return null;
    }

    private int GetColorDifferenceScore(Color o, Color c)
    {

        int scoreResult=0;
        int scoreDifference;

        scoreDifference = (int)Mathf.Abs((o.r * 255f) - (c.r * 255f));
        if (scoreDifference > scoreResult)
            scoreResult = scoreDifference;

        scoreDifference = (int)Mathf.Abs(( o.g * 255f  ) - ( c.g * 255f ));
        if (scoreDifference > scoreResult)
            scoreResult = scoreDifference;

        scoreDifference = (int)Mathf.Abs((o.b * 255f) - ( c.b * 255f));
        if (scoreDifference > scoreResult)
            scoreResult = scoreDifference;

        return scoreResult;
    }

    internal void AddColor(string name, Color color)
    {
        m_tagsList.m_tags.Add(new ColorTag() { m_tag = name, m_color = color });
        m_onColorAdded.Invoke(color);
    }

    public void Reset()
    {
        List<ColorTag> tags = new List<ColorTag>();
        tags.Add(new ColorTag() { m_color = Color.white, m_tag = "Your Tag Name" });
        m_tagsList = new ColorTagsList() { m_tags = tags, m_name = "Default" };
    }

    public void OnValidate()
    {
        m_onEdited.Invoke();

    }
    public void Clear() {
        m_tagsList.m_tags.Clear();
        m_onEdited.Invoke();

    }
}
[System.Serializable]
public class ColorTag {
    public string m_tag="Default";
    public Color m_color = Color.white;
}

[System.Serializable]
public class ColorTagsList {
    public string m_name;
    public List<ColorTag> m_tags= new List<ColorTag>();
}

[System.Serializable]
public class OnColorChangeEvent : UnityEvent<Color> { }