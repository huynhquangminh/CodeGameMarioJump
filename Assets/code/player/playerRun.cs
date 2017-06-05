using UnityEngine;
using System.Collections;

public class playerRun : MonoBehaviour {
   
    public float maxvelocity;
   
    private Rigidbody2D myBody;
    private Animator anim;
  

   
    [SerializeField]
    private AudioClip audiocliplive, audioclip_mariodie;
    [SerializeField]
    private AudioSource audio;
    public int live =0;

    private Vector2 leftFingerPos = Vector2.zero;
    private Vector2 leftFingerLastPos = Vector2.zero;
    private Vector2 leftFingerMovedBy = Vector2.zero;

    public float slideMagnitudeX = 0.0f;
    public float slideMagnitudetemp = 0.0f;
    public float speedplayer = 15;
    void Awake()
    {
        
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      
       
    }
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(FlashThePlayer(3, 0.2f));
    }
	// Update is called once per frame
	void FixedUpdate () {
        // move for key PC
       Movekey();

        // move for action touch mobile
       // MoveplayerforTouch();
        MoveplayerforTouch4();
    }

    public void MoveplayerforTouch4()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if ( touch.phase == TouchPhase.Moved) // cham li vao mang hinh 
            {
                if (touch.position.x < Screen.width * 0.5f) // duy chuyen ve ben trai 
                {

                    Vector3 temp = transform.localScale;
                    temp.x = -0.4f;
                    transform.localScale = temp;
                    anim.SetBool("walk", true);
                    // transform.Translate(-Vector3.right * Time.deltaTime * speedplayer);
                    myBody.velocity = new Vector2(-5, 0);
                }
                else
                {
                    if (touch.position.x > Screen.width * 0.5f) // duy chuyen ve ben phai 
                    {
                        Vector3 temp = transform.localScale;
                        temp.x = 0.4f;
                        transform.localScale = temp;
                        anim.SetBool("walk", true);
                        myBody.velocity = new Vector2(5, 0);
                        //transform.Translate(Vector3.right * Time.deltaTime * speedplayer);
                    }
                }
            }
            else if(touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                anim.SetBool("walk", false);
            }
        }
       
    }
   
    public void Movekey()
    {
        float forxeX = 0f;
        float h = Input.GetAxisRaw("Horizontal"); //-1 0 1
        float vel = Mathf.Abs(myBody.velocity.x);
        if (h > 0)
        {
           
            if (vel < maxvelocity)
            {
                forxeX = speedplayer;
               
            }
               
            Vector3 temp = transform.localScale;
            temp.x = 0.4f;
            transform.localScale = temp;
            anim.SetBool("walk", true);
        }
        else if (h < 0)
             {
           
            if (vel < maxvelocity)
            {
               
                forxeX = -speedplayer;
            }
               
            Vector3 temp = transform.localScale;
            temp.x = -0.4f;
            transform.localScale = temp;
            anim.SetBool("walk", true);
             }
        if (h== 0)
        {
            anim.SetBool("walk", false);
        }
       
        myBody.AddForce(new Vector2(h*speedplayer, 4));
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.tag == "Live")
        {
            live=1;
            audio.PlayOneShot(audiocliplive);
            if (GameControl.instance != null)
            {
                GameControl.instance.setlive(live);
            }

            Destroy(target.gameObject);
        }

        if (target.collider.tag == "Enemy")
        {
            audio.PlayOneShot(audioclip_mariodie);
            if (GameControl.instance != null)
            {
                if (GameControl.instance.live == 0)
                {
                    GameControl.instance.showgameover();
                    Destroy(gameObject);
                }
                else
                {

                    GameControl.instance.setlive(-1);
                    // FlashThePlayer(3, 0.5f);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
       
       
        if (target.tag == "Enemy2")
        {

            audio.PlayOneShot(audioclip_mariodie);
            if (GameControl.instance.live== 0)
            {
                GameControl.instance.showgameover();
            }
            else
            {
                GameControl.instance.templive = 1;
                GameControl.instance.setlive(-1);
            }
            Destroy(gameObject);
        }
    }
    

}
