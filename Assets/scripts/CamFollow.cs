using UnityEngine;
using System.Collections.Generic;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    private Vector3 pos;
    public Vector3 vel;
    public float speed;
    public Vector3 offset;
    
    void Start()
    {
        offset = transform.position - (player.position + enemy.position);

    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        pos = (player.position+enemy.position)+offset;
        transform.position  = Vector3.SmoothDamp(transform.position,pos,ref vel,speed);
    }
}
