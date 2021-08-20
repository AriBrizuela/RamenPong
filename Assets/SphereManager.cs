using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class SphereManager : MonoBehaviour
{
    Camera maincamera;
    SphereCollider collider;
    Rigidbody Rigidbody;
    bool didBounce = false;
    public float Speed = 1;
    public bool isLeft = true;
    public bool isUp = true;
    bool hasLaunched = false;
    
    void Awake()
    {

        collider = GetComponent<SphereCollider>();
        maincamera = Camera.main;
        Rigidbody = GetComponent<Rigidbody>();

    }

   
    void Update()
    {
        if (!hasLaunched) return;
        Vector3 min = maincamera.WorldToScreenPoint(collider.bounds.min);
        Vector3 max = maincamera.WorldToScreenPoint(collider.bounds.max);
        //width check
        if(min.x < 0)//left 
        {
            GameManager.instance.AddScore(1);
            hasLaunched = false;
        }
        if(max.x > Screen.width) //right
        {
            GameManager.instance.AddScore(0);
            hasLaunched = false;
        }
        //height check
        if (min.y < 0) //down
        {
            isUp = true;
        }
        if (max.y > Screen.height)//up
        {
            isUp = false;
        }
        if (didBounce)
        {
            isLeft = !isLeft;
            didBounce = false;
        }
            if (isLeft)
        {
            if (isUp) { Rigidbody.transform.position += (Vector3.left + Vector3.up) * Speed;

            }
            else { Rigidbody.transform.position += (Vector3.left + Vector3.down) * Speed; }
        }
        else
        {
            if (isUp)
            {
                Rigidbody.transform.position += (Vector3.right + Vector3.up) * Speed;

            }
            else { Rigidbody.transform.position += (Vector3.right + Vector3.down) * Speed; }
        }
        



    }
    private void OnCollisionEnter(Collision collision)
    {
        didBounce = true;
    }
    public void Launch()
    {
        if(!hasLaunched)
        {
            hasLaunched = true;
        }
    }
}
