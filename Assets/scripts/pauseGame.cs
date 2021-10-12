using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    private float timer=0f;
    public float additive=0.1f;

    public IEnumerator pause(float dur)
    {
        timer =0f;
        while(timer<dur)
        {
            timer += additive;
            Time.timeScale = 0;
            yield return null;
        }
        Time.timeScale = 1;

    }
}
