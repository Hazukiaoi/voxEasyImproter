using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class VoxImporter : EditorWindow {

    public Object voxFile;

    #region colorboard
    private static float[][] voxColors = new float[][]
        {
            new float[]{1.0F, 1.0F, 1.0F, 1.0F},
            new float[]{1.0F, 1.0F, 0.8F, 1.0F},
            new float[]{1.0F, 1.0F, 0.6F, 1.0F},
            new float[]{1.0F, 1.0F, 0.4F, 1.0F},
            new float[]{1.0F, 1.0F, 0.2F, 1.0F},
            new float[]{1.0F, 1.0F, 0.0F, 1.0F},
            new float[]{1.0F, 0.8F, 1.0F, 1.0F},
            new float[]{1.0F, 0.8F, 0.8F, 1.0F},
            new float[]{1.0F, 0.8F, 0.6F, 1.0F},
            new float[]{1.0F, 0.8F, 0.4F, 1.0F},
            new float[]{1.0F, 0.8F, 0.2F, 1.0F},
            new float[]{1.0F, 0.8F, 0.0F, 1.0F},
            new float[]{1.0F, 0.6F, 1.0F, 1.0F},
            new float[]{1.0F, 0.6F, 0.8F, 1.0F},
            new float[]{1.0F, 0.6F, 0.6F, 1.0F},
            new float[]{1.0F, 0.6F, 0.4F, 1.0F},
            new float[]{1.0F, 0.6F, 0.2F, 1.0F},
            new float[]{1.0F, 0.6F, 0.0F, 1.0F},
            new float[]{1.0F, 0.4F, 1.0F, 1.0F},
            new float[]{1.0F, 0.4F, 0.8F, 1.0F},
            new float[]{1.0F, 0.4F, 0.6F, 1.0F},
            new float[]{1.0F, 0.4F, 0.4F, 1.0F},
            new float[]{1.0F, 0.4F, 0.2F, 1.0F},
            new float[]{1.0F, 0.4F, 0.0F, 1.0F},
            new float[]{1.0F, 0.2F, 1.0F, 1.0F},
            new float[]{1.0F, 0.2F, 0.8F, 1.0F},
            new float[]{1.0F, 0.2F, 0.6F, 1.0F},
            new float[]{1.0F, 0.2F, 0.4F, 1.0F},
            new float[]{1.0F, 0.2F, 0.2F, 1.0F},
            new float[]{1.0F, 0.2F, 0.0F, 1.0F},
            new float[]{1.0F, 0.0F, 1.0F, 1.0F},
            new float[]{1.0F, 0.0F, 0.8F, 1.0F},
            new float[]{1.0F, 0.0F, 0.6F, 1.0F},
            new float[]{1.0F, 0.0F, 0.4F, 1.0F},
            new float[]{1.0F, 0.0F, 0.2F, 1.0F},
            new float[]{1.0F, 0.0F, 0.0F, 1.0F},
            new float[]{0.8F, 1.0F, 1.0F, 1.0F},
            new float[]{0.8F, 1.0F, 0.8F, 1.0F},
            new float[]{0.8F, 1.0F, 0.6F, 1.0F},
            new float[]{0.8F, 1.0F, 0.4F, 1.0F},
            new float[]{0.8F, 1.0F, 0.2F, 1.0F},
            new float[]{0.8F, 1.0F, 0.0F, 1.0F},
            new float[]{0.8F, 0.8F, 1.0F, 1.0F},
            new float[]{0.8F, 0.8F, 0.8F, 1.0F},
            new float[]{0.8F, 0.8F, 0.6F, 1.0F},
            new float[]{0.8F, 0.8F, 0.4F, 1.0F},
            new float[]{0.8F, 0.8F, 0.2F, 1.0F},
            new float[]{0.8F, 0.8F, 0.0F, 1.0F},
            new float[]{0.8F, 0.6F, 1.0F, 1.0F},
            new float[]{0.8F, 0.6F, 0.8F, 1.0F},
            new float[]{0.8F, 0.6F, 0.6F, 1.0F},
            new float[]{0.8F, 0.6F, 0.4F, 1.0F},
            new float[]{0.8F, 0.6F, 0.2F, 1.0F},
            new float[]{0.8F, 0.6F, 0.0F, 1.0F},
            new float[]{0.8F, 0.4F, 1.0F, 1.0F},
            new float[]{0.8F, 0.4F, 0.8F, 1.0F},
            new float[]{0.8F, 0.4F, 0.6F, 1.0F},
            new float[]{0.8F, 0.4F, 0.4F, 1.0F},
            new float[]{0.8F, 0.4F, 0.2F, 1.0F},
            new float[]{0.8F, 0.4F, 0.0F, 1.0F},
            new float[]{0.8F, 0.2F, 1.0F, 1.0F},
            new float[]{0.8F, 0.2F, 0.8F, 1.0F},
            new float[]{0.8F, 0.2F, 0.6F, 1.0F},
            new float[]{0.8F, 0.2F, 0.4F, 1.0F},
            new float[]{0.8F, 0.2F, 0.2F, 1.0F},
            new float[]{0.8F, 0.2F, 0.0F, 1.0F},
            new float[]{0.8F, 0.0F, 1.0F, 1.0F},
            new float[]{0.8F, 0.0F, 0.8F, 1.0F},
            new float[]{0.8F, 0.0F, 0.6F, 1.0F},
            new float[]{0.8F, 0.0F, 0.4F, 1.0F},
            new float[]{0.8F, 0.0F, 0.2F, 1.0F},
            new float[]{0.8F, 0.0F, 0.0F, 1.0F},
            new float[]{0.6F, 1.0F, 1.0F, 1.0F},
            new float[]{0.6F, 1.0F, 0.8F, 1.0F},
            new float[]{0.6F, 1.0F, 0.6F, 1.0F},
            new float[]{0.6F, 1.0F, 0.4F, 1.0F},
            new float[]{0.6F, 1.0F, 0.2F, 1.0F},
            new float[]{0.6F, 1.0F, 0.0F, 1.0F},
            new float[]{0.6F, 0.8F, 1.0F, 1.0F},
            new float[]{0.6F, 0.8F, 0.8F, 1.0F},
            new float[]{0.6F, 0.8F, 0.6F, 1.0F},
            new float[]{0.6F, 0.8F, 0.4F, 1.0F},
            new float[]{0.6F, 0.8F, 0.2F, 1.0F},
            new float[]{0.6F, 0.8F, 0.0F, 1.0F},
            new float[]{0.6F, 0.6F, 1.0F, 1.0F},
            new float[]{0.6F, 0.6F, 0.8F, 1.0F},
            new float[]{0.6F, 0.6F, 0.6F, 1.0F},
            new float[]{0.6F, 0.6F, 0.4F, 1.0F},
            new float[]{0.6F, 0.6F, 0.2F, 1.0F},
            new float[]{0.6F, 0.6F, 0.0F, 1.0F},
            new float[]{0.6F, 0.4F, 1.0F, 1.0F},
            new float[]{0.6F, 0.4F, 0.8F, 1.0F},
            new float[]{0.6F, 0.4F, 0.6F, 1.0F},
            new float[]{0.6F, 0.4F, 0.4F, 1.0F},
            new float[]{0.6F, 0.4F, 0.2F, 1.0F},
            new float[]{0.6F, 0.4F, 0.0F, 1.0F},
            new float[]{0.6F, 0.2F, 1.0F, 1.0F},
            new float[]{0.6F, 0.2F, 0.8F, 1.0F},
            new float[]{0.6F, 0.2F, 0.6F, 1.0F},
            new float[]{0.6F, 0.2F, 0.4F, 1.0F},
            new float[]{0.6F, 0.2F, 0.2F, 1.0F},
            new float[]{0.6F, 0.2F, 0.0F, 1.0F},
            new float[]{0.6F, 0.0F, 1.0F, 1.0F},
            new float[]{0.6F, 0.0F, 0.8F, 1.0F},
            new float[]{0.6F, 0.0F, 0.6F, 1.0F},
            new float[]{0.6F, 0.0F, 0.4F, 1.0F},
            new float[]{0.6F, 0.0F, 0.2F, 1.0F},
            new float[]{0.6F, 0.0F, 0.0F, 1.0F},
            new float[]{0.4F, 1.0F, 1.0F, 1.0F},
            new float[]{0.4F, 1.0F, 0.8F, 1.0F},
            new float[]{0.4F, 1.0F, 0.6F, 1.0F},
            new float[]{0.4F, 1.0F, 0.4F, 1.0F},
            new float[]{0.4F, 1.0F, 0.2F, 1.0F},
            new float[]{0.4F, 1.0F, 0.0F, 1.0F},
            new float[]{0.4F, 0.8F, 1.0F, 1.0F},
            new float[]{0.4F, 0.8F, 0.8F, 1.0F},
            new float[]{0.4F, 0.8F, 0.6F, 1.0F},
            new float[]{0.4F, 0.8F, 0.4F, 1.0F},
            new float[]{0.4F, 0.8F, 0.2F, 1.0F},
            new float[]{0.4F, 0.8F, 0.0F, 1.0F},
            new float[]{0.4F, 0.6F, 1.0F, 1.0F},
            new float[]{0.4F, 0.6F, 0.8F, 1.0F},
            new float[]{0.4F, 0.6F, 0.6F, 1.0F},
            new float[]{0.4F, 0.6F, 0.4F, 1.0F},
            new float[]{0.4F, 0.6F, 0.2F, 1.0F},
            new float[]{0.4F, 0.6F, 0.0F, 1.0F},
            new float[]{0.4F, 0.4F, 1.0F, 1.0F},
            new float[]{0.4F, 0.4F, 0.8F, 1.0F},
            new float[]{0.4F, 0.4F, 0.6F, 1.0F},
            new float[]{0.4F, 0.4F, 0.4F, 1.0F},
            new float[]{0.4F, 0.4F, 0.2F, 1.0F},
            new float[]{0.4F, 0.4F, 0.0F, 1.0F},
            new float[]{0.4F, 0.2F, 1.0F, 1.0F},
            new float[]{0.4F, 0.2F, 0.8F, 1.0F},
            new float[]{0.4F, 0.2F, 0.6F, 1.0F},
            new float[]{0.4F, 0.2F, 0.4F, 1.0F},
            new float[]{0.4F, 0.2F, 0.2F, 1.0F},
            new float[]{0.4F, 0.2F, 0.0F, 1.0F},
            new float[]{0.4F, 0.0F, 1.0F, 1.0F},
            new float[]{0.4F, 0.0F, 0.8F, 1.0F},
            new float[]{0.4F, 0.0F, 0.6F, 1.0F},
            new float[]{0.4F, 0.0F, 0.4F, 1.0F},
            new float[]{0.4F, 0.0F, 0.2F, 1.0F},
            new float[]{0.4F, 0.0F, 0.0F, 1.0F},
            new float[]{0.2F, 1.0F, 1.0F, 1.0F},
            new float[]{0.2F, 1.0F, 0.8F, 1.0F},
            new float[]{0.2F, 1.0F, 0.6F, 1.0F},
            new float[]{0.2F, 1.0F, 0.4F, 1.0F},
            new float[]{0.2F, 1.0F, 0.2F, 1.0F},
            new float[]{0.2F, 1.0F, 0.0F, 1.0F},
            new float[]{0.2F, 0.8F, 1.0F, 1.0F},
            new float[]{0.2F, 0.8F, 0.8F, 1.0F},
            new float[]{0.2F, 0.8F, 0.6F, 1.0F},
            new float[]{0.2F, 0.8F, 0.4F, 1.0F},
            new float[]{0.2F, 0.8F, 0.2F, 1.0F},
            new float[]{0.2F, 0.8F, 0.0F, 1.0F},
            new float[]{0.2F, 0.6F, 1.0F, 1.0F},
            new float[]{0.2F, 0.6F, 0.8F, 1.0F},
            new float[]{0.2F, 0.6F, 0.6F, 1.0F},
            new float[]{0.2F, 0.6F, 0.4F, 1.0F},
            new float[]{0.2F, 0.6F, 0.2F, 1.0F},
            new float[]{0.2F, 0.6F, 0.0F, 1.0F},
            new float[]{0.2F, 0.4F, 1.0F, 1.0F},
            new float[]{0.2F, 0.4F, 0.8F, 1.0F},
            new float[]{0.2F, 0.4F, 0.6F, 1.0F},
            new float[]{0.2F, 0.4F, 0.4F, 1.0F},
            new float[]{0.2F, 0.4F, 0.2F, 1.0F},
            new float[]{0.2F, 0.4F, 0.0F, 1.0F},
            new float[]{0.2F, 0.2F, 1.0F, 1.0F},
            new float[]{0.2F, 0.2F, 0.8F, 1.0F},
            new float[]{0.2F, 0.2F, 0.6F, 1.0F},
            new float[]{0.2F, 0.2F, 0.4F, 1.0F},
            new float[]{0.2F, 0.2F, 0.2F, 1.0F},
            new float[]{0.2F, 0.2F, 0.0F, 1.0F},
            new float[]{0.2F, 0.0F, 1.0F, 1.0F},
            new float[]{0.2F, 0.0F, 0.8F, 1.0F},
            new float[]{0.2F, 0.0F, 0.6F, 1.0F},
            new float[]{0.2F, 0.0F, 0.4F, 1.0F},
            new float[]{0.2F, 0.0F, 0.2F, 1.0F},
            new float[]{0.2F, 0.0F, 0.0F, 1.0F},
            new float[]{0.0F, 1.0F, 1.0F, 1.0F},
            new float[]{0.0F, 1.0F, 0.8F, 1.0F},
            new float[]{0.0F, 1.0F, 0.6F, 1.0F},
            new float[]{0.0F, 1.0F, 0.4F, 1.0F},
            new float[]{0.0F, 1.0F, 0.2F, 1.0F},
            new float[]{0.0F, 1.0F, 0.0F, 1.0F},
            new float[]{0.0F, 0.8F, 1.0F, 1.0F},
            new float[]{0.0F, 0.8F, 0.8F, 1.0F},
            new float[]{0.0F, 0.8F, 0.6F, 1.0F},
            new float[]{0.0F, 0.8F, 0.4F, 1.0F},
            new float[]{0.0F, 0.8F, 0.2F, 1.0F},
            new float[]{0.0F, 0.8F, 0.0F, 1.0F},
            new float[]{0.0F, 0.6F, 1.0F, 1.0F},
            new float[]{0.0F, 0.6F, 0.8F, 1.0F},
            new float[]{0.0F, 0.6F, 0.6F, 1.0F},
            new float[]{0.0F, 0.6F, 0.4F, 1.0F},
            new float[]{0.0F, 0.6F, 0.2F, 1.0F},
            new float[]{0.0F, 0.6F, 0.0F, 1.0F},
            new float[]{0.0F, 0.4F, 1.0F, 1.0F},
            new float[]{0.0F, 0.4F, 0.8F, 1.0F},
            new float[]{0.0F, 0.4F, 0.6F, 1.0F},
            new float[]{0.0F, 0.4F, 0.4F, 1.0F},
            new float[]{0.0F, 0.4F, 0.2F, 1.0F},
            new float[]{0.0F, 0.4F, 0.0F, 1.0F},
            new float[]{0.0F, 0.2F, 1.0F, 1.0F},
            new float[]{0.0F, 0.2F, 0.8F, 1.0F},
            new float[]{0.0F, 0.2F, 0.6F, 1.0F},
            new float[]{0.0F, 0.2F, 0.4F, 1.0F},
            new float[]{0.0F, 0.2F, 0.2F, 1.0F},
            new float[]{0.0F, 0.2F, 0.0F, 1.0F},
            new float[]{0.0F, 0.0F, 1.0F, 1.0F},
            new float[]{0.0F, 0.0F, 0.8F, 1.0F},
            new float[]{0.0F, 0.0F, 0.6F, 1.0F},
            new float[]{0.0F, 0.0F, 0.4F, 1.0F},
            new float[]{0.0F, 0.0F, 0.2F, 1.0F},
            new float[]{0.9333333333333333F, 0.0F, 0.0F, 1.0F},
            new float[]{0.8666666666666667F, 0.0F, 0.0F, 1.0F},
            new float[]{0.7333333333333333F, 0.0F, 0.0F, 1.0F},
            new float[]{0.6666666666666666F, 0.0F, 0.0F, 1.0F},
            new float[]{0.5333333333333333F, 0.0F, 0.0F, 1.0F},
            new float[]{0.4666666666666667F, 0.0F, 0.0F, 1.0F},
            new float[]{0.3333333333333333F, 0.0F, 0.0F, 1.0F},
            new float[]{0.26666666666666666F, 0.0F, 0.0F, 1.0F},
            new float[]{0.13333333333333333F, 0.0F, 0.0F, 1.0F},
            new float[]{0.06666666666666667F, 0.0F, 0.0F, 1.0F},
            new float[]{0.0F, 0.9333333333333333F, 0.0F, 1.0F},
            new float[]{0.0F, 0.8666666666666667F, 0.0F, 1.0F},
            new float[]{0.0F, 0.7333333333333333F, 0.0F, 1.0F},
            new float[]{0.0F, 0.6666666666666666F, 0.0F, 1.0F},
            new float[]{0.0F, 0.5333333333333333F, 0.0F, 1.0F},
            new float[]{0.0F, 0.4666666666666667F, 0.0F, 1.0F},
            new float[]{0.0F, 0.3333333333333333F, 0.0F, 1.0F},
            new float[]{0.0F, 0.26666666666666666F, 0.0F, 1.0F},
            new float[]{0.0F, 0.13333333333333333F, 0.0F, 1.0F},
            new float[]{0.0F, 0.06666666666666667F, 0.0F, 1.0F},
            new float[]{0.0F, 0.0F, 0.9333333333333333F, 1.0F},
            new float[]{0.0F, 0.0F, 0.8666666666666667F, 1.0F},
            new float[]{0.0F, 0.0F, 0.7333333333333333F, 1.0F},
            new float[]{0.0F, 0.0F, 0.6666666666666666F, 1.0F},
            new float[]{0.0F, 0.0F, 0.5333333333333333F, 1.0F},
            new float[]{0.0F, 0.0F, 0.4666666666666667F, 1.0F},
            new float[]{0.0F, 0.0F, 0.3333333333333333F, 1.0F},
            new float[]{0.0F, 0.0F, 0.26666666666666666F, 1.0F},
            new float[]{0.0F, 0.0F, 0.13333333333333333F, 1.0F},
            new float[]{0.0F, 0.0F, 0.06666666666666667F, 1.0F},
            new float[]{0.9333333333333333F, 0.9333333333333333F, 0.9333333333333333F, 1.0F},
            new float[]{0.8666666666666667F, 0.8666666666666667F, 0.8666666666666667F, 1.0F},
            new float[]{0.7333333333333333F, 0.7333333333333333F, 0.7333333333333333F, 1.0F},
            new float[]{0.6666666666666666F, 0.6666666666666666F, 0.6666666666666666F, 1.0F},
            new float[]{0.5333333333333333F, 0.5333333333333333F, 0.5333333333333333F, 1.0F},
            new float[]{0.4666666666666667F, 0.4666666666666667F, 0.4666666666666667F, 1.0F},
            new float[]{0.3333333333333333F, 0.3333333333333333F, 0.3333333333333333F, 1.0F},
            new float[]{0.26666666666666666F, 0.26666666666666666F, 0.26666666666666666F, 1.0F},
            new float[]{0.13333333333333333F, 0.13333333333333333F, 0.13333333333333333F, 1.0F},
            new float[]{0.06666666666666667F, 0.06666666666666667F, 0.06666666666666667F, 1.0F},
            new float[]{0.0F, 0.0F, 0.0F, 0.0F},
        };
    #endregion

    [MenuItem("ModelTools/VoxImporter")]
    static void Importer()
    {
        VoxImporter windows = (VoxImporter)GetWindowWithRect(typeof(VoxImporter), new Rect(0, 0, 200, 60), true, "VoxImporter");
        windows.Show();
    }

    public void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("VoxFile:");
        voxFile = (Object)EditorGUILayout.ObjectField(voxFile, typeof(Object), false);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Import"))
        {
            importVox(voxFile);
        }
        GUILayout.EndHorizontal();
    }

    void importVox(Object voxFile)
    {
        
        string applicationPath = Application.dataPath;

        List<Vector3> voxPosition = new List<Vector3>();
        List<GameObject> voxList = new List<GameObject>();
        List<int> voxPositionRemoveID = new List<int>();
        List<MagicaVoxelData> MagicaVoxelList = new List<MagicaVoxelData>();
        List<Color> colorList = new List<Color>();

        //创建材质目录
        if (Directory.Exists(Application.dataPath + "/Resources/Materials/voxMat") == false)
            Directory.CreateDirectory(Application.dataPath + "/Resources/Materials/voxMat");

        #region readFile
        BinaryReader bin = new BinaryReader(File.Open(applicationPath.Substring(0, applicationPath.Length - 6) + AssetDatabase.GetAssetPath(voxFile), FileMode.Open));
        MagicaVoxelData[] parsed = FromMagica(bin);
        bin.Close();
        MagicaVoxelList.AddRange(parsed);
        #endregion

        #region buildVoxelModel
        for (int i = 0; i < parsed.Length; i++)
        {
            voxPosition.Add(new Vector3(-parsed[i].y, parsed[i].z, parsed[i].x));
        }

        for (int i = 0; i < voxPosition.Count; i++)
        {
            //如果这个方块的六个方向上都相邻有方块，则表示这个方块在对象的中间部位不可见，可以移除
            if (voxPosition.Contains(new Vector3(voxPosition[i].x + 1, voxPosition[i].y, voxPosition[i].z))
                && voxPosition.Contains(new Vector3(voxPosition[i].x - 1, voxPosition[i].y, voxPosition[i].z))
                && voxPosition.Contains(new Vector3(voxPosition[i].x, voxPosition[i].y + 1, voxPosition[i].z))
                && voxPosition.Contains(new Vector3(voxPosition[i].x, voxPosition[i].y - 1, voxPosition[i].z))
                && voxPosition.Contains(new Vector3(voxPosition[i].x, voxPosition[i].y, voxPosition[i].z + 1))
                && voxPosition.Contains(new Vector3(voxPosition[i].x, voxPosition[i].y, voxPosition[i].z - 1))
                )
            {
                //把被移除的对象ID添加到列表中
                voxPositionRemoveID.Add(i);
            }
        }

        //从后往前删除重叠的对象
        for (int i = voxPositionRemoveID.Count - 1; i >= 0; i--)
        {
            voxPosition.RemoveAt(voxPositionRemoveID[i]);
            MagicaVoxelList.RemoveAt(voxPositionRemoveID[i]);
        }

        //创建父对象
        GameObject father = new GameObject(voxFile.name);
        father.transform.position = Vector3.zero;
        //生成方块
        for (int i = 0; i < MagicaVoxelList.Count; i++)
        {
            voxList.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
            DestroyImmediate(voxList[i].GetComponent<BoxCollider>());   //在编辑器界面移除组件使用此代码
            voxList[i].name = "cube_" + i;
            voxList[i].transform.position = new Vector3(-MagicaVoxelList[i].y, MagicaVoxelList[i].z + 0.5f, MagicaVoxelList[i].x);
            voxList[i].transform.parent = father.transform;

            float[] floatColor = voxColors[MagicaVoxelList[i].color - 1];
            Color color = new Color(floatColor[0], floatColor[1], floatColor[2]);
            if (colorList.Contains(color) == false)//如果颜色不存在于已使用列表上
            {
                colorList.Add(color);                                            //则添加到列表
                SaveMatAssest(MagicaVoxelList[i].color.ToString(), "Assets/Resources/Materials/voxMat", color);//并创建材质
            }
            voxList[i].GetComponent<Renderer>().sharedMaterial = (Material)AssetDatabase.LoadAssetAtPath("Assets/Resources/Materials/voxMat/" + MagicaVoxelList[i].color + ".mat", typeof(Material)); //为对象赋予材质
        }
        #endregion

        AssetDatabase.Refresh();


    }

    public struct MagicaVoxelData
    {
        public byte x;
        public byte y;
        public byte z;
        public byte color;

        public MagicaVoxelData(BinaryReader stream)
        {
            x = stream.ReadByte(); //(byte)(subsample ? stream.ReadByte() / 2 : stream.ReadByte());
            y = stream.ReadByte(); //(byte)(subsample ? stream.ReadByte() / 2 : stream.ReadByte());
            z = stream.ReadByte(); //(byte)(subsample ? stream.ReadByte() / 2 : stream.ReadByte());
            color = stream.ReadByte();
        }
    }

    private static int sizex = 0, sizey = 0, sizez = 0;

    private static MagicaVoxelData[] FromMagica(BinaryReader stream)
    {
        // check out http://voxel.codeplex.com/wikipage?title=VOX%20Format&referringTitle=Home for the file format used below
        // we're going to return a voxel chunk worth of data
        MagicaVoxelData[] voxelData = null;

        string magic = new string(stream.ReadChars(4));
        int version = stream.ReadInt32();

        // a MagicaVoxel .vox file starts with a 'magic' 4 character 'VOX ' identifier
        if (magic == "VOX ")
        {
            while (stream.BaseStream.Position < stream.BaseStream.Length)
            {
                // each chunk has an ID, size and child chunks
                char[] chunkId = stream.ReadChars(4);
                int chunkSize = stream.ReadInt32();
                int childChunks = stream.ReadInt32();
                string chunkName = new string(chunkId);

                // there are only 2 chunks we only care about, and they are SIZE and XYZI
                if (chunkName == "SIZE")
                {
                    sizex = stream.ReadInt32();
                    sizey = stream.ReadInt32();
                    sizez = stream.ReadInt32();

                    //if (sizex > 32 || sizey > 32) subsample = true;

                    stream.ReadBytes(chunkSize - 4 * 3);
                }
                else if (chunkName == "XYZI")
                {
                    // XYZI contains n voxels
                    int numVoxels = stream.ReadInt32();

                    // each voxel has x, y, z and color index values
                    voxelData = new MagicaVoxelData[numVoxels];
                    for (int i = 0; i < voxelData.Length; i++)
                        voxelData[i] = new MagicaVoxelData(stream);
                }
                else if (chunkName == "RGBA")
                {
                    //colors = new float[256][];

                    for (int i = 0; i < 256; i++)
                    {
                        byte r = stream.ReadByte();
                        byte g = stream.ReadByte();
                        byte b = stream.ReadByte();
                        byte a = stream.ReadByte();

                    }
                }
                else stream.ReadBytes(chunkSize);   // read any excess bytes
            }
            if (voxelData.Length == 0) return voxelData; // failed to read any valid voxel data
        }
        return voxelData;
    }

    public static void SaveMatAssest(string matName, string savePath, UnityEngine.Color color)
    {
        Material mat = new Material(Shader.Find("Standard"));
        mat.name = matName;
        mat.SetColor("_Color", color);
        //将材质放入创建的文件夹中  
        AssetDatabase.CreateAsset(mat, savePath + "/" + matName + ".mat");
        AssetDatabase.Refresh();
    }//保存材质
}
