using UnityEngine;
using System.Collections;

public class wallrun : MonoBehaviour {

 
    public static wallrun instance;
    public float speedwall;
    public int score = 0;
    public float temp = 0;
   
    private Rigidbody2D myBody;
    [SerializeField]
    private GameObject mushr, player;
    [SerializeField]
    private AudioClip audioclipshowplayer, audioclip_mariohello;
    [SerializeField]
    private AudioSource audio;

   
    void Awake()
    {
        MakeInstance();
        speedwall = 1.5f;
        myBody = GetComponent<Rigidbody2D>();
       
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void movewall()
    {
        if (GameControl.instance.score > 15 && GameControl.instance.score < 35)
            speedwall = 2;
        if (GameControl.instance.score > 35 && GameControl.instance.score <50)
            speedwall = 2.5f;
        if (GameControl.instance.score > 50 && GameControl.instance.score <70)
            speedwall = 2.8f;
        if (GameControl.instance.score > 70 && GameControl.instance.score < 90)
            speedwall = 3f;
        myBody.velocity = new Vector2(0f, speedwall);
    }


    // Use this for initialization
    void Start()
    {
       
        StartCoroutine(showmushroom());
        StartCoroutine(showplayer());
    }
	
	void FixedUpdate () { 
        movewall();
    }

    //void Update()
    //{
       
    //}


    IEnumerator showplayer()
    {

               // int time = (int)Time.time;
        if(GameControl.instance != null)
        {
            if(GameControl.instance.tempshowplayer == 2 )
            {
                audio.PlayOneShot(audioclip_mariohello);
                Vector3 temp = transform.position;
                temp.y += 0.5f;
                temp.x += Random.Range(-0.5f, 0.6f);
                Instantiate(player, temp, Quaternion.identity);
                yield return new WaitForSeconds(1);
                StartCoroutine(showplayer());
            }
            if(GameControl.instance.templive == 1)
            {
                audio.PlayOneShot(audioclipshowplayer);
                Vector3 temp = transform.position;
                temp.y += 0.5f;
                temp.x += Random.Range(-0.5f, 0.6f);
                Instantiate(player, temp, Quaternion.identity);
                GameControl.instance.templive = 0;
                yield return new WaitForSeconds(2);
                StartCoroutine(showplayer());
               
            }
        }
                
    }
    IEnumerator showmushroom()
    {
        int time = (int)Time.time;
            if (time %7 == 0)
            {
                
                Vector3 temp = transform.position;
                temp.y += 0.5f;
                temp.x += Random.Range(-0.5f, 0.6f);
                Instantiate(mushr, temp, Quaternion.identity);
                yield return new WaitForSeconds(1);
                StartCoroutine(showmushroom());
            }
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {
       

        if (target.tag == "border")
        {
            score++;
            if(GameControl.instance !=null)
            {
                GameControl.instance.setscore(score);
            }
            Destroy(gameObject);
        }
    }
}
