using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace JC {


    public class MonoUtility : MonoBehaviour
    {


    }
    public static  class Utility
    {

        public static class Random {

            private static float GetRandomBetween(float range)
            {
                return UnityEngine.Random.Range(-range, range);
            }
            private static float GetRandomBetween(float min, float max)
            {
                return UnityEngine.Random.Range(-min, max);
            }

        }

        public static class Color {
            public static UnityEngine.Color GetAverageOf(ref List<UnityEngine.Color> colors)
            {

                Vector4 c;
                if (colors.Count > 0)
                {
                    int colorCount = colors.Count;
                    c = colors[0];
                    for (int i = 1; i < colorCount; i++)
                    {
                        c.x += colors[i].r;
                        c.y += colors[i].g;
                        c.z += colors[i].b;
                        c.w += colors[i].a;
                    }
                    return new UnityEngine.Color(c.x / (float)colorCount, c.y / (float)colorCount, c.z / (float)colorCount, c.w / (float)colorCount);
                }
                else return UnityEngine.Color.black;
            }



       

        }

        public static class Texture2D {

            //https://answers.unity.com/questions/163662/get-pixel-colour-on-a-ray-hit.html
            public static bool RaycastForColorsAtPosition(Vector3 position, float radius, out UnityEngine.Color foundColor, LayerMask mask, float raycastAngle = 45)
            {
                List<UnityEngine.Color> colors = new List<UnityEngine.Color>();
                List<UnityEngine.Color> findColors = new List<UnityEngine.Color>();
                Vector3 direction = Vector3.forward;

                for (int i = 0; i < 360; i += (int)raycastAngle)
                {
                    for (int y = 0; y < 360; y += (int)raycastAngle)
                    {
                        direction = (Quaternion.Euler(i, y, 0) * Vector3.forward).normalized;
                        RaycastForColor(position, radius, direction, mask, out findColors);
                        colors.AddRange(findColors);
                    }
                }
                foundColor = JC.Utility.Color. GetAverageOf(ref colors);
                bool hitCount = colors.Count > 0;
                return hitCount;
            }


            public static void RaycastForColor(Vector3 position, float radius, Vector3 direction, LayerMask mask, out List<UnityEngine.Color> colors)
            {
                colors = new List<UnityEngine.Color>();
                RaycastHit hit;
                Ray ray = new Ray(position + direction * radius, -direction);
                bool isHitting = Physics.Raycast(ray, out hit, 2 * radius, mask);
                if (isHitting)
                {
                    UnityEngine.Texture2D text = hit.collider.gameObject.GetComponent<Renderer>().material.mainTexture as UnityEngine.Texture2D;
                    if (text != null)
                    {

                        int x = (int)(hit.textureCoord.x * text.width);
                        int y = (int)(hit.textureCoord.y * text.height);
                        UnityEngine.Color color = text.GetPixel(x, y);
                        colors.Add(color);
                    }
                }
                Debug.DrawRay(ray.origin, ray.direction * radius, isHitting ? UnityEngine.Color.green : UnityEngine.Color.red, 0.1f);
            }
        }



        public class Directory
        {
            public static List<string> GetAllDirectoriesIn(string path)
            {
                return Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            }

            public static List<string> GetDirectories(string path, string searchPattern = "*",
            SearchOption searchOption = SearchOption.TopDirectoryOnly)
            {
                if (searchOption == SearchOption.TopDirectoryOnly)
                    return GetDirectories(path, searchPattern).ToList();

                var directories = new List<string>(GetDirectories(path, searchPattern));

                for (var i = 0; i < directories.Count; i++)
                    directories.AddRange(GetDirectories(directories[i], searchPattern));

                return directories;
            }

            private static List<string> GetDirectories(string path, string searchPattern)
            {
                try
                {
                    return System.IO. Directory.GetDirectories(path, searchPattern).ToList();
                }
                catch (UnauthorizedAccessException)
                {
                    return new List<string>();
                }
            }
        }
    }



  

}
