using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectManager : MonoBehaviour
{
    private int _size;
    void Start()
    {
        _size = this.gameObject.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        Clamp();
    }
    void Clamp()
    {
        for (int i = 0; i < _size; i++)
        {
            GameObject childGameObject = this.gameObject.transform.GetChild(i).gameObject;
            var pos = childGameObject.transform.position;
            pos.y = Mathf.Clamp(childGameObject.transform.position.y, -5f, 0.5f);
            childGameObject.transform.position = pos;
        }
    }
}
