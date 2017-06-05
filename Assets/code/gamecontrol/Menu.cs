using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
   
    public static Menu instance1;
    public int temp;
    [SerializeField]
    private AudioClip audioclip_click;
    [SerializeField]
    private AudioSource audio;
    void Awake()
    {
        temp = 0;
        MakeInstance();
        
    }

    void MakeInstance()
    {
        if (instance1 == null)
        {
            instance1 = this;
        }
    }
    void Start ()
    {
        
    }
    public void clickplaygame()
    {
        audio.PlayOneShot(audioclip_click);
        Application.LoadLevel("GamePlay");
        temp = 1;
        //Debug.Log("" + temp);

    }
    public void clickexitgame()
    {
        audio.PlayOneShot(audioclip_click);
        Application.Quit();
    }
}
