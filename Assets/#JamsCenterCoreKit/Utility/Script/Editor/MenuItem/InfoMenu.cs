using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InfoMenu : Editor {


    [MenuItem("Window/Jams.Center/Website/Patreon")]
    public static void MenuItem_JC_License_StreeEloi()
    {
        Application.OpenURL("https://www.patreon.com/eloistree");
    }
    [MenuItem("Window/Jams.Center/Website/Official")]
    public static void MenuItem_JC_Info_StreeEloi()
    {
        Application.OpenURL("https://jams.center/");
    }
    [MenuItem("Window/Jams.Center/Website/Codes")]
    public static void MenuItem_JC_Code_StreeEloi()
    {
        Application.OpenURL("https://gitlab.com/JamsCenter");
    }

}
