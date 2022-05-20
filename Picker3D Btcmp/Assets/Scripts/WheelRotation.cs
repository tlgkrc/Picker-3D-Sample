using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] GameObject wheelL;
    [SerializeField] GameObject wheelR;

    private PlayerMovement _playerMovement;
    private float _rotationSpeed;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        RotationWheels();
    }
    void RotationWheels()
    {
        if (_playerMovement.IsStop == false)
        {
            _rotationSpeed = 5f;
        }
        else
        {
            _rotationSpeed = 0f;
            this.gameObject.SetActive(false);
        }
        wheelL.transform.Rotate(new Vector3(0f, _rotationSpeed, 0f), Space.Self);
        wheelR.transform.Rotate(new Vector3(0f, -_rotationSpeed, 0f), Space.Self);
    }
}
