using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneratePallet : MonoBehaviour {


    public Transform m_container;
    public GameObject m_tagColorPrefab;
    public ColorTags m_tags;
    public OnColorChangeEvent m_buttonToDo;


	void Start () {
        Refresh();
	}
	


	public void Refresh () {
        
        for (int i = m_container.childCount-1; i>=0 ; i--)
        {
            Destroy(m_container.GetChild(i).gameObject);
        }
        foreach (ColorTag tag in m_tags.m_tagsList.m_tags)
        {
            GameObject obj = Instantiate(m_tagColorPrefab, m_container);
            UI_TriggerColor color = obj.GetComponent<UI_TriggerColor>();
            color.SetPanelWith(tag.m_tag, tag.m_color, m_buttonToDo);

        }
	}
}
