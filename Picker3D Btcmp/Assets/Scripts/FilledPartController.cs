using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FilledPartController : MonoBehaviour
{
    public int Id;
    void Start()
    {
        GameEvents.current.onFilledBoxCollisionEnter += OnCompletePath;
    }

    private void OnCompletePath(int id)
    {
        if (id == this.Id)
        {
            this.gameObject.transform.DOMoveY(0, 0.5f, false);
        }
        
    }
}
