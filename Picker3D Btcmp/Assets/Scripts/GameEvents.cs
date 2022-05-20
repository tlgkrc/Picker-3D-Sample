using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onFilledBoxCollisionEnter;

    public void FilledBoxCollisionEnter(int id)
    {
        if (onFilledBoxCollisionEnter != null)
        {
            onFilledBoxCollisionEnter(id);
        }
    }
}
