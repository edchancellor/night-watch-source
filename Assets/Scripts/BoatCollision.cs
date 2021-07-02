using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        bool should_i_spawn = GameObject.Find("Game_Logic").GetComponent<Game_Logic>().spawn_boats;
        if (col.tag == "boatcollision" && should_i_spawn)
        {
            Debug.Log("I should sink");
            if (col.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                col.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            }
            GameObject.Find("Game_Logic").GetComponent<Game_Logic>().End_Round(transform.position, col.gameObject.transform.parent.gameObject, gameObject.transform.parent.gameObject);
        }
        else if(col.tag == "rock" && should_i_spawn)
        {
            Debug.Log("I should sink");
            if (col.gameObject.transform.position.y < gameObject.transform.position.y)
            {
                col.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            }
            GameObject.Find("Game_Logic").GetComponent<Game_Logic>().End_Round(transform.position, col.gameObject, gameObject.transform.parent.gameObject);
        }
    }
}
