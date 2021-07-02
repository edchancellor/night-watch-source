using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public int directional_int = 2;
    private float xdestinationleft = -5f;
    private float xdestinationright = 9.5f;
    public float height;
    public float speed;
    private bool diagonal_movement;
    private bool left;
    public bool should_i_move;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "deathblock")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.y;
        speed = 0.75f;
        diagonal_movement = false;
        left = true;
        should_i_move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (directional_int != 2)
        {
            if(directional_int == 0)
            {
                directional_int = 2;
                left = false;
                // move right
                StartCoroutine(tempright());
            }
            else if(directional_int == 1)
            {
                directional_int = 2;
                Debug.Log("flip");
                // move left and flip sprite
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                StartCoroutine(templeft());
            }
        }
        
    }

    public void move_up()
    {
        if(!diagonal_movement && should_i_move)
        {
            // You can only move up if you are below the top level
            if (transform.position.y < 2f)
            {
                diagonal_movement = true;
                StartCoroutine(diagonal_up());
            }
        }
    }

    public void move_down()
    {
        if(!diagonal_movement && should_i_move)
        {
            // You can only move up if you are above the bottom level
            if (transform.position.y > -3.5f)
            {
                diagonal_movement = true;
                StartCoroutine(diagonal_down());
            }
        }
    }

    IEnumerator diagonal_up()
    {
        // decrement the sorting order to an intermediate while moving diagonally
        int so = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        so = so - 1;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = so;

        // determine where we should move diagonally to
        int multiplier = 1;
        if (left)
        {
            multiplier = -1;
        }

        Vector3 currentPos = gameObject.transform.position;
        Vector3 nextPos = new Vector3(currentPos.x + (0.4f * multiplier), currentPos.y + 1f, currentPos.z);

        // move diagonally
        while(transform.position != nextPos && should_i_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            yield return null;
        }

        diagonal_movement = false;

        // decrement the sorting order once we have stopped moving diagonally
        if(should_i_move)
        {
            so = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            so = so - 2;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = so;
        }
        
        // change height
        height = transform.position.y;

        // Start moving again
        if (left)
        {
            StartCoroutine(templeft());
        }
        else
        {
            StartCoroutine(tempright());
        }
        yield return null;
    }

    IEnumerator diagonal_down()
    {
        // decrement the sorting order to an intermediate while moving diagonally
        int so = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        so = so + 2;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = so;

        // determine where we should move diagonally to
        int multiplier = 1;
        if (left)
        {
            multiplier = -1;
        }

        Vector3 currentPos = gameObject.transform.position;
        Vector3 nextPos = new Vector3(currentPos.x + (0.4f * multiplier), currentPos.y - 1f, currentPos.z);

        // move diagonally
        while(transform.position != nextPos && should_i_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            yield return null;
        }

        diagonal_movement = false;

        // decrement the sorting order once we have stopped moving diagonally
        if(should_i_move)
        {
            so = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            so = so + 1;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = so;
        }
        
        // change height
        height = transform.position.y;

        // Start moving again
        if (left)
        {
            StartCoroutine(templeft());
        }
        else
        {
            StartCoroutine(tempright());
        }
    }

    IEnumerator templeft()
    {
        while(transform.position.x > xdestinationleft && !diagonal_movement && should_i_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xdestinationleft, height, 0f), speed * Time.deltaTime);
            yield return null;
        }

        // delete gameobject if reached destination
        if (transform.position.x <= xdestinationleft)
        {
            Debug.Log("Reached left");
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        yield return null;
    }

    IEnumerator tempright()
    {
        while(transform.position.x < xdestinationright && !diagonal_movement && should_i_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xdestinationright, height, 0f), speed * Time.deltaTime);
            yield return null;
        }

        if (transform.position.x >= xdestinationright)
        {
            Debug.Log("Reached right");
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        yield return null;
    }

}
