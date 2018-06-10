using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;

public class CursorColor : MonoBehaviour {

    [System.Serializable]
    public struct RGB { public int r; public int g; public int b; }
    public Color m_textureColor;
    public Color m_textureColorAverage;
    public RGB m_RGB;
    public LayerMask m_mask = 1;
    public GameObject m_targetObject;
    public Material m_targetMaterial;
    public Texture m_targetTexture;

    public float m_delayBetweenCheck=0.2f;
    public string m_shaderProperty = "_MainTex";
    public OnCursorColorChange m_onColorChanged;
    public OnCursorColorChange m_onColorSelected;

    [System.Serializable]
    public class OnCursorColorChange : UnityEvent<Color> { }


    public int m_crossSide=5;

    public bool m_isVR;
    public Transform m_vrDirection;
  
	IEnumerator Start () {


       Color m_textureLastColor;
        while (true) {
            m_textureLastColor = m_textureColor;

            m_isVR = !string.IsNullOrEmpty(XRSettings.loadedDeviceName);
            Vector3 screenPosition = Input.mousePosition;
            Ray ray =   Camera.main.ScreenPointToRay(screenPosition);
            if (m_isVR)
                ray = new Ray(m_vrDirection.position, m_vrDirection.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, m_mask)) {
            m_targetObject = hit.collider.gameObject;
            m_targetMaterial = m_targetObject.GetComponent<Renderer>().material;

            Texture2D text=null;
            m_targetTexture = m_targetMaterial.GetTexture(m_shaderProperty);
                if (m_targetTexture != null)
                {

                    if (m_targetTexture.GetType() == typeof(Texture2D))
                    {
                        text = (Texture2D)m_targetTexture;
                    }
                    if (m_targetTexture.GetType() == typeof(RenderTexture))
                    {
                        RenderTexture m_renderTexture = (RenderTexture)m_targetTexture;
                        RenderTexture.active = m_renderTexture;
                        text = new Texture2D(m_renderTexture.width, m_renderTexture.height);
                        text.ReadPixels(new Rect(0, 0, m_renderTexture.width, m_renderTexture.height), 0, 0);
                        text.Apply();
                    }

                    int x = (int)(hit.textureCoord.x * text.width);
                    int y = (int)(hit.textureCoord.y * text.height);
                    m_textureColor = text.GetPixel( x, y);
                    m_textureColorAverage = GetAverage(text, x, y);
                    m_RGB.r = (int)(m_textureColor.r * 255f);
                    m_RGB.g = (int)(m_textureColor.g * 255f);
                    m_RGB.b = (int)(m_textureColor.b * 255f);
                }

            }
            if (m_textureLastColor != m_textureColor)
                m_onColorChanged.Invoke(m_textureColor);


            yield return new WaitForSeconds(m_delayBetweenCheck);
        }
	}

    public void Update()
    {
        m_onColorSelected.Invoke(m_textureColor);
    }

    private  Color GetAverage(Texture2D text, int x, int y)
    {
        Color c;
        float r = 0, g = 0, b = 0, a = 0;
        int ix=x, iy=y;
        c = text.GetPixel(x, y);
        r = c.r;
        g = c.g;
        b = c.b;
        a= c.a;

        int count = 1;

        for (int i = ix - m_crossSide; i < ix + m_crossSide; i++)
        {
            if (i > 0 && i < text.width) {
                c = text.GetPixel(x, y);
                r += c.r;
                g += c.g;
                b += c.b;
                a += c.a;
                count++;

            }
        }
        for (int i = iy - m_crossSide; i < iy + m_crossSide; i++)
        {
            if (i > 0 && i < text.height)
            {

                c = text.GetPixel(x, y);
                r += c.r;
                g += c.g;
                b += c.b;
                a += c.a;
                count++;
            }
        }


        return new Color(r / count, g / count, b / count, a / count);
    }
}
