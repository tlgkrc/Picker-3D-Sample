using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    ScoreManager scoreManager;
    LevelCreateManager levelCreateManager;

    private float _moveSpeed = 6f;
    public bool IsStop;
    private GameObject _playerGameObject;
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] float swerveSpeed = 0.5f;
    public static bool IsGameStart;
    [SerializeField] GameObject startPanel;
    private bool isFinishedLevel = false;

    private void Awake()    
    {
        _playerGameObject = this.gameObject;
        _swerveInputSystem = _playerGameObject.GetComponent<SwerveInputSystem>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelCreateManager = FindObjectOfType<LevelCreateManager>();
    }
    private void Start()
    {
        IsGameStart = false;
    }


    private void Update()
    {
        if (_swerveInputSystem.tap)
        {
            CloseStartPanel();
            VerticalMovement();
            HorizontalMove();
        }
    }
    void VerticalMovement()
    {
        
        if (IsStop== false)
        {
            if (isFinishedLevel ==true)
            {
                Vector3 startMove = _playerGameObject.transform.position;
                _playerGameObject.transform.DOMove(startMove + new Vector3(0,0,scoreManager.GetLevelScore()*3), 2f);
                isFinishedLevel = false;
                scoreManager.SetToZeroLevelScore();
                levelCreateManager.IncreaseLastLevelIndex();
                levelCreateManager.SetLevel(levelCreateManager.LastLevelIndex);
            }
            else
            {
                _playerGameObject.transform.Translate(0, 0, _moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            _playerGameObject.transform.Translate(0, 0, 0);
            IsStop = true;
        }
    }
    void HorizontalMove()
    {
        var pos = _playerGameObject.transform.position;
        pos.x = Mathf.Clamp(_playerGameObject.transform.position.x ,-3.5f,3.5f);
        _playerGameObject.transform.position = pos;

        float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
        transform.Translate(swerveAmount, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            IsStop = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BiggerScale")
        {
            _playerGameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f).SetEase(Ease.InOutSine);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ScorePath")
        {
            isFinishedLevel = true;
            other.gameObject.SetActive(false);
        }
    }
    private void CloseStartPanel()
    {
        startPanel.gameObject.SetActive(false);
    }
}
