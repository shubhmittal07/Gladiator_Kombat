using System.Collections;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
    public float rotation_speed;
    public IEnumerator Shake(float dur,float power) 
    {
        Vector3 startPos = transform.localPosition;
        float elapsed =0f;
        while(elapsed<dur)
        {
            elapsed += Time.deltaTime;
            float moveX = Random.Range(-1f,1f)*power;
            float moveY = Random.Range(-1f,1f)*power;
            transform.localPosition = new Vector3(moveX,moveY,startPos.z);
            yield return null;
        }
        transform.localPosition = startPos;
        
    }

    
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*rotation_speed);
    }
}
