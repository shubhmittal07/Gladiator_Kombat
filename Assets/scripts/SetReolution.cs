using System.Collections.Generic;
using UnityEngine;


public class SetReolution : MonoBehaviour
{
    Resolution[] resolution;
    public TMPro.TMP_Dropdown res_drop;
    void Start()
    {
        resolution = Screen.resolutions;
        res_drop.ClearOptions();
        List<string> options = new List<string>();
        int CurrResIndex = 0;
        for(int i=0;i<resolution.Length;i++)
        {
            string option = resolution[i].width + "x" + resolution[i].height;
            options.Add(option);

            if(resolution[i].width == Screen.currentResolution.width &&resolution[i].height == Screen.currentResolution.height)
            {
                CurrResIndex = i;
            }
        }
        res_drop.AddOptions(options);
        res_drop.value = CurrResIndex;
        res_drop.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution resolutions = resolution[index];
        Screen.SetResolution(resolutions.width,resolutions.height,Screen.fullScreen);

    }
}
