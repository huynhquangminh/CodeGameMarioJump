using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameControl : MonoBehaviour {

    public static GameControl instance;

    public int templive = 0;
    public int live = 3;
    public int tempshowplayer = 0;
   
    [SerializeField]
    private GameObject gameover;
    public int score = 0;
    [SerializeField]
    private Text textscore;
    [SerializeField]
    private Text textlive;
    [SerializeField]
    private Text textscoregameover;
    [SerializeField]
    private AudioClip audioclip_gameover;
    [SerializeField]
    private AudioSource audio;


    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void setscore(int n)
    {
        score = score + n;
        textscore.text = ""+score;
        textscoregameover.text = score.ToString();
    }
    public void setlive(int n)
    {
        live = live + n;
        textlive.text = live.ToString();
       
    }
    public void resertgame()
    {
        Application.LoadLevel("GamePlay");
        Time.timeScale = 1f;
       
     
    }
   public void showgameover()
    {
        audio.PlayOneShot(audioclip_gameover);
        gameover.SetActive(true);
        Time.timeScale = 0f;
    }
 
	
}
