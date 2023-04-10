using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public class LevelGenerator : EditorWindow
{
    [SerializeField] LevelData levelData = new LevelData();

    [MenuItem("Tools/LevelGenerator")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelGenerator));
    }

    Editor editor;

    void OnGUI()
    {
        if (!editor) { editor = Editor.CreateEditor(this); }
        if (editor)
        {
            editor.OnInspectorGUI();
            if (GUILayout.Button("Create A New Level"))
            {
                SpawnObjectsRandomly();
            }
        }
    }
    void SpawnObjectsRandomly()
    {
        GameObject holder = new GameObject(levelData.levelName);
       
        if (!Directory.Exists("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets" , "Prefabs");
        string localPath = "Assets/Prefabs/" + holder.name + ".prefab";

        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

        bool prefabSuccess;
        PrefabUtility.SaveAsPrefabAssetAndConnect(holder , localPath , InteractionMode.UserAction , out prefabSuccess);
        if (prefabSuccess == true)
            Debug.Log("Prefab was saved successfully");
        else
            Debug.Log("Prefab failed to save" + prefabSuccess);

        for (int i = 0; i < levelData.gameObjectsCountInLevel; i++)
        {
            int randomPrefab = Random.Range(0 , levelData.Prefabs.Count);
            Vector3 pos = Vector3.zero;
            pos.x = Mathf.Clamp(Random.Range(0 , levelData.gridSize.x) , 0 , levelData.gridSize.x);
            pos.y = 0;
            pos.z = Mathf.Clamp(Random.Range(0 , levelData.gridSize.y) , 0 , levelData.gridSize.y);
            if (levelData.Prefabs[randomPrefab] && levelData.gameObjectsCountInLevel > 0)
            {
                GameObject spawnedGameObject = Instantiate(levelData.Prefabs[randomPrefab] , pos , Quaternion.identity , holder.transform);
                PrefabUtility.ApplyAddedGameObject(spawnedGameObject , localPath , InteractionMode.UserAction);
            }
        }
    }
    void OnInspectorUpdate()
    {
        Repaint();
    }
}

[System.Serializable]
public class LevelData
{
    public string levelName;
    public List<GameObject> Prefabs;
    public Vector2 gridSize;
    public int gameObjectsCountInLevel;
}

[CustomEditor(typeof(LevelGenerator) , true)]
public class ListTestEditorDrawer : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var levelData = serializedObject.FindProperty("levelData");

        EditorGUILayout.PropertyField(levelData , new GUIContent("LevelData") , true);
        serializedObject.ApplyModifiedProperties();
    }
}