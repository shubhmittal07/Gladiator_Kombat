using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_crawler : MonoBehaviour
{
    public Transform[] menu_positions;
    private int pos_index=0;
    public Transform select_pos;
    public AudioSource menu_audio;
    public AudioClip hover_audio;
    public AudioClip select_audio;
    public GameObject help_screen;
    public bool isOperable=true;
    public GameObject settings;
    bool setOn=false;
    // Update is called once per frame
    void Update()
    {
        select_pos.position = menu_positions[pos_index].position;
        if(Input.GetKeyDown(KeyCode.UpArrow)&&isOperable)
        {
            menu_audio.PlayOneShot(hover_audio);
            pos_index--;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)&&isOperable)
        {
            menu_audio.PlayOneShot(hover_audio);
            pos_index++;
        }
        if(pos_index>2)
        {
            pos_index=0;
        }
        if(pos_index<0)
        {
            pos_index=2;
        }
        if(Input.GetButtonDown("Submit")&&isOperable)
        {
            menu_audio.PlayOneShot(select_audio);
            if(pos_index==0)
            {
                SceneManager.LoadSceneAsync(1);
            }
            else if(pos_index == 1 && !setOn)
            {
                setOn = true;
                settings.SetActive(true);
                isOperable = false;
            }
            else if(pos_index == 2)
            {
                Application.Quit();
            }

        }
        if(setOn && Input.GetKeyDown(KeyCode.Q))
        {
            
            settings.SetActive(false);
            isOperable = true;
            setOn = false;
        }
        if(Input.GetKeyDown(KeyCode.H) && isOperable)
        {
            help_screen.SetActive(true);
            isOperable = false;
        }
        if(Input.GetKeyDown(KeyCode.F) && !isOperable)
        {
            isOperable = true;
            help_screen.SetActive(false);
        }
    }
}
