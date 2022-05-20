using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Level", fileName = "New Level Create")]
public class LevelManagerSO : ScriptableObject
{
    [Header("For Creator")]
    [SerializeField] int _levelNumber;

    [SerializeField] List<GameObject> _paths;

    [SerializeField] List<Vector3> _offsetOfPaths = new List<Vector3>();

    public List<GameObject> GetPaths()
    {
        return _paths;
    }
    public List<Vector3> GetOffsets()
    {
        return _offsetOfPaths;
    }
    /**
     *  Created a position next level where will be instantiated
     */
    public Vector3 GetTotalOffset()
    {
        Vector3 totalOffset = Vector3.zero;
        totalOffset = (_offsetOfPaths[_offsetOfPaths.Count-1] + 
            (_offsetOfPaths[_offsetOfPaths.Count-1]- _offsetOfPaths[_offsetOfPaths.Count - 2]));

        return totalOffset;
    }
    
}