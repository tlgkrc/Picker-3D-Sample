using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

/**
 * Here we define actions such as updating score text according to index of triggered area.
 * In hierarchy , the object which this script is attached
 */
public class TriggerArea : MonoBehaviour
{
    private int _counter;
    public int id;
    PlayerMovement playerMovement;
    ScoreManager scoreManager;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        scoreManager.IncreaseLevelScore();
        scoreManager.IncreaseScore();   
        _counter++;
        GameObject scoreGameObject = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        scoreGameObject.GetComponent<TextMeshProUGUI>().text = _counter + "/" + this.gameObject.name;

        int border = int.Parse(this.gameObject.name);
        if (_counter >= border)
        {
            playerMovement.IsStop = false;
            scoreGameObject.SetActive(false);
            _counter = border;
            GameEvents.current.FilledBoxCollisionEnter(id);
            OpenGate();
            DestroyWall();
            collision.gameObject.transform.parent.gameObject.SetActive(false);
        }
        
    }
    private void OpenGate()
    {
        GameObject gate = this.transform.parent.GetChild(0).gameObject;
        gate.gameObject.transform.GetChild(0).DORotate(new Vector3(0f, 0f, 90f), 2f);
        gate.gameObject.transform.GetChild(1).DORotate(new Vector3(0f, 0f, -90f), 2f);
    }
    private void DestroyWall()
    {
        GameObject wall = this.transform.parent.GetChild(1).gameObject;
        wall.SetActive(false);
    }
}
