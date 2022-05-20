using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreateManager : MonoBehaviour
{
    [SerializeField] List<LevelManagerSO> _totalLevelGameObject;
    private int _lastLevelIndex = 0;
    public int LastLevelIndex => _lastLevelIndex;
    private LevelManagerSO _currentLevel;
    private static Vector3 _instantiateLocation;

    private void Awake()
    {
        SetLevel(_lastLevelIndex);
    }
    
    public void SetLevel(int levelIndex)
    {
        int indexNumber = 0;
        _currentLevel = _totalLevelGameObject[levelIndex];
        foreach (GameObject path in _currentLevel.GetPaths())
        {
            Instantiate(path, _instantiateLocation + _currentLevel.GetOffsets()[indexNumber], Quaternion.identity);
            indexNumber++;
        }
        _instantiateLocation = _currentLevel.GetTotalOffset();
    }
    public void IncreaseLastLevelIndex()
    {
        _lastLevelIndex++;
    }
}
