using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PaddleManager : MonoBehaviour
{
    [System.Serializable]
    public class playercontrols
    {
        public KeyCode up;
        public KeyCode down;
        public KeyCode fire;
    }
    [SerializeField] int playerID;
    BoxCollider collider;
    Camera maincamera;
    Rigidbody Rigidbody;
    public float speed = 1;
    public bool IsAI = false;
    Vector3 spawnPosition;
    [SerializeField] int Score;

    public void ResetPosition()
    {
        Rigidbody.transform.position = spawnPosition;
    }
    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        maincamera = Camera.main;
        Rigidbody = GetComponent<Rigidbody>();
        spawnPosition = Rigidbody.transform.position;
    }
    private void Update() 
    
    {
        Vector3 min = maincamera.WorldToScreenPoint(collider.bounds.min);
        Vector3 max = maincamera.WorldToScreenPoint(collider.bounds.max);
        if (!IsAI)
        {
            if(Input.GetKey(GameManager.instance.PlayerControls[playerID].down)) //go down
            {
                if (min.y > 0)
                { Rigidbody.transform.position += Vector3.down * speed; }
            }
            if (Input.GetKey(GameManager.instance.PlayerControls[playerID].up)) //go Up
            {
                if(max.y < Screen.height) 
                { Rigidbody.transform.position += Vector3.up * speed; } 
            }
            if (Input.GetKeyUp(GameManager.instance.PlayerControls[playerID].fire)) //fire
            {
                GameManager.instance.sphere.Launch();
            }
        }
    }
    public int GetScore()
    {
        return Score;
    }
    public void AddPoint()
    {
        Score += 1;
    }
}
