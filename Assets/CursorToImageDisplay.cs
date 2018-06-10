using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CursorToImageDisplay : MonoBehaviour {



    public Image m_image;

    public List<TagToImage> m_tagToImage;
    public float m_displayTimeCountDown;
    public ColorTags m_colorRef;
    public int m_stayTime = 6;
    public float m_disapearTime = 2;
    public int m_refPrecision = 5;



    [Header("Auto Add")]
    public ColorTags m_tagGenerator;

    [System.Serializable]
    public struct TagToImage
    {
        public string m_tag;
        public Sprite m_sprite;
    }

    public void Display(Color color) {

        string tag  = m_colorRef.GetTagOf(color, m_refPrecision);
        Display(tag);
    }
    // Use this for initialization
    public void Display (string tagName) {

       List<TagToImage> result = m_tagToImage.Where(k => k.m_tag == tagName).ToList();
        if (result.Count() > 0)
            Display(result.First());
	}
    public void Display(TagToImage toDisplay)
    {
        m_image.sprite = toDisplay.m_sprite;
        m_displayTimeCountDown = m_disapearTime+ m_disapearTime;
        m_image.color = Color.white;

    }
     
    void Update () {

        if (m_displayTimeCountDown < 0)
            return;
        m_displayTimeCountDown -= Time.deltaTime;
        if(m_displayTimeCountDown < m_disapearTime)
            m_image.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), 1f-  m_displayTimeCountDown/ m_disapearTime);

	}

    public void OnValidate()
    {
        if (m_tagGenerator != null)
        {
            foreach (var color in m_tagGenerator.m_tagsList.m_tags)
            {
                m_tagToImage.Add(new TagToImage() { m_tag = color.m_tag});

            }
            m_tagGenerator = null;
        }
    }
}
