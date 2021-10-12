using System.Collections.Generic;
using UnityEngine;

public class CamFollow2 : MonoBehaviour
{
    public List<Transform> targets;
    private Vector3 centroid;
    public Vector3 offset = new Vector3(0.06f,1.73f,-8.19f);
    private Vector3 newPosition;
    private Vector3 vel;
    public float smoothTime;
    void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return;
        }
        centroid = GetCentroid();
        newPosition = centroid + offset;
        transform.position = Vector3.SmoothDamp(transform.position,newPosition,ref vel,smoothTime);
        
    }
    void Update()
    {
        if(targets[0]==null)
        {
            targets.Remove(targets[0]);
        }
    }
   

    Vector3 GetCentroid()
    {
        if(targets.Count == 1)
        {
           return targets[0].position;
        }
        var bounds = new Bounds(targets[0].position,Vector3.zero);
        for(int i=0;i<targets.Count;i++)
        {
            bounds.Encapsulate(targets[i].position);
            CheckList();

        }
        return bounds.center;  
    }

    void CheckList()
    {
        for(int i=0;i<targets.Count;i++)
        {
            if(targets[i]==null)
            {
                targets.Remove(targets[i]);
            }
        }
    }
}
