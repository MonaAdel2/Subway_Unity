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

        GameObject ground = Instantiate(levelData.GroundPrefab , Vector3.zero , levelData.GroundPrefab.transform.rotation,holder.transform);
        ground.transform.localScale =new Vector3( levelData.gridSize.x, levelData.gridSize.y , 1);
        PrefabUtility.ApplyAddedGameObject(ground , localPath , InteractionMode.UserAction);
        for (int i = 0; i < levelData.gameObjectsCountInLevel; i++)
        {
            int randomPrefab = Random.Range(0 , levelData.Prefabs.Count);
           float randomScale =  Random.Range(levelData.objectRandomScaleFactor.x , levelData.objectRandomScaleFactor.y);
           float randomAngle =  Random.Range(levelData.objectRandomAngle.x , levelData.objectRandomAngle.y);

            Vector3[] pos = new Vector3[2];
            pos[0].x =Random.Range(-levelData.gridSize.x , -levelData.gridSize.x*0.4f) *0.4f;
            pos[0].y = 0;
            pos[0].z = Random.Range(-levelData.gridSize.y , levelData.gridSize.y*1.2f)*0.4f;

            pos[1].x = Random.Range(levelData.gridSize.x*0.85f , levelData.gridSize.x*1.2f) * 0.4f;
            pos[1].y = 0;
            pos[1].z = Random.Range(-levelData.gridSize.y , levelData.gridSize.y*1.2f) * 0.4f;

            if (levelData.Prefabs[randomPrefab] && levelData.gameObjectsCountInLevel > 0)
            {
                GameObject spawnedGameObject = Instantiate(levelData.Prefabs[randomPrefab] , pos[Random.Range(0,2)] , Quaternion.identity , holder.transform);
                spawnedGameObject.transform.localScale = Vector3.one;
                spawnedGameObject.transform.localScale *= randomScale;
                spawnedGameObject.transform.Rotate(Vector3.one * randomAngle);

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
    public GameObject GroundPrefab;
    public List<GameObject> Prefabs;
    public Vector2 gridSize;
    public Vector2 objectRandomScaleFactor;
    public Vector2 objectRandomAngle;
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