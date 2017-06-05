using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
    public float speedenemy;
    private Rigidbody2D myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void move_enemy()
    {
        myBody.velocity = new Vector2(0f, speedenemy);
    }
	void Update () {
        move_enemy();
	}
    public void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "border")
        {
            Destroy(gameObject);
        }
    }
}
