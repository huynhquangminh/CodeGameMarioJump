using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    
    [SerializeField]
    private GameObject wall, wall2, enemy;
    private BoxCollider2D box;
    private float y;
    Vector3 location1, location2, location3;
    public float khoangcach;

    void Awake()
    {
      
        box = GetComponent<BoxCollider2D>();

    }
	// Use this for initialization
	void Start () {
        StartCoroutine(spawnerwall1());
        StartCoroutine(spawnerwall2());
        StartCoroutine(spawnerenemy());
       
    }
	
	// Update is called once per frame
	void Update () {
     
    }

    public int distance(Vector3 location1, Vector3 location2)
    {
        khoangcach = Mathf.Sqrt(Mathf.Pow(location1.x - location2.x, 2) + Mathf.Pow(location1.y - location2.y, 2));
        if (khoangcach >= 2)
            return 1;
         return 0;
    }

    IEnumerator spawnerwall1()
    {

        GameControl.instance.tempshowplayer++;
        if (GameControl.instance.tempshowplayer == 15)
            GameControl.instance.tempshowplayer = 3;
        yield return new WaitForSeconds(1f);
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
         location1 = transform.position;
        location1.x = Random.Range(minX, maxX);
        int kq = 0;
        while (kq == 0)
        {
            location1.x = Random.Range(minX, maxX);
            kq = distance(location1, location3);
        }
        kq = 0;
        while (kq == 0)
        {
            location1.x = Random.Range(minX, maxX);
            kq = distance(location1, location2);
        }

        Instantiate(wall, location1, Quaternion.identity);
        StartCoroutine(spawnerwall1());
       
    }
    IEnumerator spawnerwall2()
    {
        yield return new WaitForSeconds(Random.Range(3f, 5f));
        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;
        location2 = transform.position;
        location2.x = Random.Range(minX, maxX);
        int kq = 0;
        while (kq == 0)
        {
            location2.x = Random.Range(minX, maxX);
            kq = distance(location1, location2);
        }
        kq = 0;
        while (kq == 0)
        {
            location2.x = Random.Range(minX, maxX);
            kq = distance(location2, location3);
        }
        Instantiate(wall2, location2, Quaternion.identity);
        StartCoroutine(spawnerwall2());

    }
    IEnumerator spawnerenemy()
    {
        yield return new WaitForSeconds(3);
        float minx = -box.bounds.size.x / 2f; 
        float maxx = box.bounds.size.x / 2f;
        location3 = transform.position;
        location3.x = Random.Range(minx, maxx);
        int kq = 0;
        while (kq == 0)
        {
            location3.x = Random.Range(minx, maxx);
            kq = distance(location1, location3);
        }
        kq = 0;
        while (kq == 0)
        {
            location3.x = Random.Range(minx, maxx);
            kq = distance(location2, location3);
        }
        Instantiate(enemy, location3, Quaternion.identity);
        StartCoroutine(spawnerenemy());
    }
}
