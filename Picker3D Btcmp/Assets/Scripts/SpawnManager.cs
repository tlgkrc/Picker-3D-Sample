using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject collectableObject;
    private void Start()
    {
        Instantiate(collectableObject, this.gameObject.transform.position, Quaternion.identity,this.gameObject.transform);
    }
}
