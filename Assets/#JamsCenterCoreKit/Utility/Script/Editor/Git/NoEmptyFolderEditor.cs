using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class NoEmptyFolderEditor : UnityEditor.AssetModificationProcessor
{
    [MenuItem("Window/Jams.Center/Script/Git/No empty folder")]
    public static void MenuItem_FeelEmptyFolder() {

        FillFolder();
    }
    private static string emptyFileName= "/NoEmptyDirectory.txt";
    private static void FillFolder()
    {
        string path = Application.dataPath;
        List<string> directoryPaths = JC.Utility.Directory.GetDirectories(path, "*" ,SearchOption.AllDirectories);
       

        foreach (string dir in directoryPaths)
        {
            bool hasFile = System.IO.Directory.GetFiles(dir).Length > 0;
            bool hasDirectory = System.IO.Directory.GetDirectories(dir).Length > 0;
            bool hasEmptyFile = File.Exists(dir + emptyFileName);

            if (!hasFile && !hasDirectory)
                File.WriteAllText(dir + emptyFileName, "Git don't like empty directory");
            else if (hasEmptyFile)
                File.Delete(dir + emptyFileName);
        }

        AssetDatabase.Refresh();
    }

    

   
}