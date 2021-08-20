using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    public static GameManager instance;
    public List<PaddleManager.playercontrols> PlayerControls;
    public SphereManager sphere;
    public List<PaddleManager> Players;
    public List<TextMeshProUGUI> ScoreText;
    private void Awake()
    {
        instance = this;
        if (sphere == null)
        {
            sphere = FindObjectOfType<SphereManager>();
        }
        if (Players == null || !Players.Any()) 
        {
            Players = new List<PaddleManager>();
            Players.AddRange(FindObjectsOfType<PaddleManager>());
            foreach(var score in ScoreText)
            {
                score.text = "0";
            }
        }
      
    }
    public void AddScore(int player)
    {
        Players[player].AddPoint();
        ScoreText[player].text = Players[player].GetScore().ToString();
        ResetBallAndPlayerPositions();
    }
    void ResetBallAndPlayerPositions()
    {
        sphere.transform.position = Vector3.zero;
        foreach (PaddleManager paddle in Players)
        {
            paddle.ResetPosition();
        }
    }
}