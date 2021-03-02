using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainManager : MonoBehaviour
{
    public TerrainData OriginalTerrainData;
    private TerrainData _terrainData;

    public TreeObject TreePrefab;
    private List<TreeInstance> _treeInstancesList;

    private void OnEnable()
    {
        EventManager.Singleton.E_ChopableDestroyed += RemoveTerrainObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTerrainOriginal();

        _treeInstancesList = new List<TreeInstance>(_terrainData.treeInstances);
        InitTreeColliders();
    }

    private void OnDisable()
    {
        EventManager.Singleton.E_ChopableDestroyed -= RemoveTerrainObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitTreeColliders()
    {
        var terrainTrees = _terrainData.treeInstances;
        foreach (TreeInstance tree in terrainTrees)
        {
            float xPos = tree.position.x * _terrainData.size.x;
            float yPos = tree.position.y * _terrainData.size.y;
            float zPos = tree.position.z * _terrainData.size.z;
            Vector3 pos = new Vector3(xPos, yPos, zPos);
            TreePrefab.transform.localScale = new Vector3(tree.widthScale, tree.heightScale, tree.widthScale);
            TreePrefab.transform.rotation = Quaternion.AngleAxis(tree.rotation * Mathf.Rad2Deg, Vector3.up);
            var currentTree = Instantiate(TreePrefab, pos, Quaternion.identity);
            currentTree.treeData = tree;
        }
    }

    public void RemoveTerrainTree(TreeObject tree)
    {
        _treeInstancesList.Remove(tree.treeData);
        _terrainData.treeInstances = _treeInstancesList.ToArray();
    }

    public void RemoveTerrainObject(ChopableObject chopObj)
    {
        switch (chopObj.ChopableType)
        {
            case ChopableType.TREE:
                RemoveTerrainTree((TreeObject)chopObj);
                break;
        }
    }

    public void SetTerrainOriginal()
    {
        string TDApath = AssetDatabase.GetAssetPath(OriginalTerrainData);
        string TDApath_copy = "Assets/Terrain/TerrainData/TerrainDataCopy.asset";
        AssetDatabase.CopyAsset(TDApath, TDApath_copy);
        Terrain.activeTerrain.terrainData = AssetDatabase.LoadAssetAtPath<TerrainData>(TDApath_copy);
        _terrainData = Terrain.activeTerrain.terrainData;
    }

}
