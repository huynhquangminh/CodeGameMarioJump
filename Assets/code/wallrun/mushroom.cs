using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class mushroom : MonoBehaviour {

  
    public int live = 0;
  

   
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "border")
        {

            Destroy(gameObject);

        }
    }
}
