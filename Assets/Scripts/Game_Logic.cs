using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Game_Logic : MonoBehaviour
{
    // Used for determining how much time there is in a night
    private int global_timer;
    private int high_score;
    private int current_night;
    private int last_viable_index;
    private List<GameObject> rocks = new List<GameObject>();
    private List<GameObject> boats = new List<GameObject>();
    public bool spawn_boats;
    private bool game_over;
    private bool End_Once;
    private bool spintime;
    private GameObject db;
    public GameObject transition;

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public GameObject Arrow5;
    public GameObject Arrow6;
    public GameObject Arrow7;
    public GameObject Arrow8;
    public GameObject Arrow9;
    public GameObject Arrow10;
    public GameObject Arrow11;
    public GameObject Arrow12;
    public GameObject Arrow13;
    public GameObject Arrow14;
    public GameObject Arrow15;
    public GameObject Arrow16;

    // All possible locations for rocks to spawn
    private Vector3[] col1 = {new Vector3(-1.9f, -4.1f, 0f), new Vector3(-1.9f, -3.1f, 0f), new Vector3(-1.9f, -2.1f, 0f), new Vector3(-1.9f, -1.1f, 0f), new Vector3(-1.9f, -0.1f, 0f), new Vector3(-1.9f, 0.9f, 0f), new Vector3(-1.9f, 1.9f, 0f), new Vector3(-1.9f, 2.9f, 0f)};
    private Vector3[] col2 = {new Vector3(-0.3f, -4.1f, 0f), new Vector3(-0.3f, -3.1f, 0f), new Vector3(-0.3f, -2.1f, 0f), new Vector3(-0.3f, -1.1f, 0f), new Vector3(-0.3f, -0.1f, 0f), new Vector3(-0.3f, 0.9f, 0f), new Vector3(-0.3f, 1.9f, 0f), new Vector3(-0.3f, 2.9f, 0f)};
    private Vector3[] col3 = {new Vector3(1.3f, -4.1f, 0f), new Vector3(1.3f, -3.1f, 0f), new Vector3(1.3f, -2.1f, 0f), new Vector3(1.3f, -1.1f, 0f), new Vector3(1.3f, -0.1f, 0f), new Vector3(1.3f, 0.9f, 0f), new Vector3(1.3f, 1.9f, 0f), new Vector3(1.3f, 2.9f, 0f)};
    private Vector3[] col4 = {new Vector3(2.9f, -4.1f, 0f), new Vector3(2.9f, -3.1f, 0f), new Vector3(2.9f, -2.1f, 0f), new Vector3(2.9f, -1.1f, 0f), new Vector3(2.9f, -0.1f, 0f), new Vector3(2.9f, 0.9f, 0f), new Vector3(2.9f, 1.9f, 0f), new Vector3(2.9f, 2.9f, 0f)};
    private Vector3[] col5 = {new Vector3(4.5f, -4.1f, 0f), new Vector3(4.5f, -3.1f, 0f), new Vector3(4.5f, -2.1f, 0f), new Vector3(4.5f, -1.1f, 0f), new Vector3(4.5f, -0.1f, 0f), new Vector3(4.5f, 0.9f, 0f), new Vector3(4.5f, 1.9f, 0f), new Vector3(4.5f, 2.9f, 0f)};
    private Vector3[] col6 = {new Vector3(6.1f, -4.1f, 0f), new Vector3(6.1f, -3.1f, 0f), new Vector3(6.1f, -2.1f, 0f), new Vector3(6.1f, -1.1f, 0f), new Vector3(6.1f, -0.1f, 0f), new Vector3(6.1f, 0.9f, 0f), new Vector3(6.1f, 1.9f, 0f), new Vector3(6.1f, 2.9f, 0f)};


    private Vector3[] row1 = {new Vector3(-1.9f, -4.1f, 0f), new Vector3(-0.3f, -4.1f, 0f), new Vector3(1.3f, -4.1f, 0f), new Vector3(2.9f, -4.1f, 0f), new Vector3(4.5f, -4.1f, 0f), new Vector3(6.1f, -4.1f, 0f)};
    private Vector3[] row2 = {new Vector3(-1.9f, -3.1f, 0f), new Vector3(-0.3f, -3.1f, 0f), new Vector3(1.3f, -3.1f, 0f), new Vector3(2.9f, -3.1f, 0f), new Vector3(4.5f, -3.1f, 0f), new Vector3(6.1f, -3.1f, 0f)};
    private Vector3[] row3 = {new Vector3(-1.9f, -2.1f, 0f), new Vector3(-0.3f, -2.1f, 0f), new Vector3(1.3f, -2.1f, 0f), new Vector3(2.9f, -2.1f, 0f), new Vector3(4.5f, -2.1f, 0f), new Vector3(6.1f, -2.1f, 0f)};
    private Vector3[] row4 = {new Vector3(-1.9f, -1.1f, 0f), new Vector3(-0.3f, -1.1f, 0f), new Vector3(1.3f, -1.1f, 0f), new Vector3(2.9f, -1.1f, 0f), new Vector3(4.5f, -1.1f, 0f), new Vector3(6.1f, -1.1f, 0f)};
    private Vector3[] row5 = {new Vector3(-1.9f, -0.1f, 0f), new Vector3(-0.3f, -0.1f, 0f), new Vector3(1.3f, -0.1f, 0f), new Vector3(2.9f, -0.1f, 0f), new Vector3(4.5f, -0.1f, 0f), new Vector3(6.1f, -0.1f, 0f)};
    private Vector3[] row6 = {new Vector3(-1.9f, 0.9f, 0f), new Vector3(-0.3f, 0.9f, 0f), new Vector3(1.3f, 0.9f, 0f), new Vector3(2.9f, 0.9f, 0f), new Vector3(4.5f, 0.9f, 0f), new Vector3(6.1f, 0.9f, 0f)};
    private Vector3[] row7 = {new Vector3(-1.9f, 1.9f, 0f), new Vector3(-0.3f, 1.9f, 0f), new Vector3(1.3f, 1.9f, 0f), new Vector3(2.9f, 1.9f, 0f), new Vector3(4.5f, 1.9f, 0f), new Vector3(6.1f, 1.9f, 0f)};
    private Vector3[] row8 = {new Vector3(-1.9f, 2.9f, 0f), new Vector3(-0.3f, 2.9f, 0f), new Vector3(1.3f, 2.9f, 0f), new Vector3(2.9f, 2.9f, 0f), new Vector3(4.5f, 2.9f, 0f), new Vector3(6.1f, 2.9f, 0f)};

    // Start is called before the first frame update
    void Start()
    {
        // Start the first round
        spawn_boats = false;
        high_score = 0;
        last_viable_index = -1000;
        Cursor.visible = false;
        game_over = false;
        End_Once = true;
        db = GameObject.Find("Deathblock");
        db.SetActive(false);
        // Make sure hint arrows are deactivated at start
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
        Arrow4.SetActive(false);
        Arrow5.SetActive(false);
        Arrow6.SetActive(false);
        Arrow7.SetActive(false);
        Arrow8.SetActive(false);
        Arrow9.SetActive(false);
        Arrow10.SetActive(false);
        Arrow11.SetActive(false);
        Arrow12.SetActive(false);
        Arrow13.SetActive(false);
        Arrow14.SetActive(false);
        Arrow15.SetActive(false);
        Arrow16.SetActive(false);
        Begin_Round(high_score,30,1,10);
        StartCoroutine(load_level());
    }

    IEnumerator load_level()
    {
        Color overlay_color = transition.GetComponent<Image>().color;
        overlay_color.a = 0.8f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.7f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.6f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.4f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.2f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.1f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // If boats are spawning, check if we are clicking on them
        if(spawn_boats)
        {
            // Left click moves the closest boat up
            if (Input.GetMouseButtonDown(0)) 
            {
                float shortest_dist = 1000f;
                GameObject closest_boat = null;
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousepos, 1f);
                foreach (var hitCollider in hitColliders)
                {
                    if(hitCollider.tag == "boat")
                    {
                        Vector3 location = hitCollider.gameObject.transform.position;
                        float distance = Mathf.Sqrt(((mousepos.x - location.x) * (mousepos.x - location.x)) + ((mousepos.y - location.y) * (mousepos.y - location.y)));
                        if (distance < shortest_dist)
                        {
                            shortest_dist = distance;
                            closest_boat = hitCollider.gameObject;
                        }
                    }
                }

                // Move the boat up!!
                if (closest_boat != null)
                {
                    Debug.Log("Move the boat up!");
                    closest_boat.gameObject.GetComponent<BoatBehaviour>().move_up();
                }

            }
            // Right click moves the closest boat down
            else if (Input.GetMouseButtonDown(1))
            {
                float shortest_dist = 1000f;
                GameObject closest_boat = null;
                Vector3 mousepos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousepos, 1f);
                foreach (var hitCollider in hitColliders)
                {
                    if(hitCollider.tag == "boat")
                    {
                        Vector3 location = hitCollider.gameObject.transform.position;
                        float distance = Mathf.Sqrt(((mousepos.x - location.x) * (mousepos.x - location.x)) + ((mousepos.y - location.y) * (mousepos.y - location.y)));
                        if (distance < shortest_dist)
                        {
                            shortest_dist = distance;
                            closest_boat = hitCollider.gameObject;
                        }
                    }
                }

                // Move the boat down!!
                if (closest_boat != null)
                {
                    Debug.Log("Move the boat down!");
                    closest_boat.gameObject.GetComponent<BoatBehaviour>().move_down();
                }
            }
        }
    }

    void Begin_Round(int score, int time, int night, float time_between_boats)
    {
        // Make sure music is playing
        AudioSource audio = GameObject.Find("Jukebox").GetComponent<AudioSource>();
        if (!audio.isPlaying)
        {
            audio.Play();
        }
        
        // Make sure beam is deactivated at start of round
        GameObject Beam = GameObject.Find("Beam");
        Beam.GetComponent<Light2D>().enabled = false;
        Beam.GetComponent<FollowMouse>().enabled = false;

        // Make sure phrase is invisible
        Text phrase = GameObject.Find("Phrase").GetComponent<Text>();
        phrase.enabled = false;

        // Make sure Timer animation is set to 'invisible'
        GameObject.Find("Timer").GetComponent<Animator>().SetInteger("TimerState", 0);

        // Make sure the timer itself is set to the correct time (e.g. 30)
        GameObject.Find("Time").GetComponent<Text>().text = time.ToString();
        global_timer = time;
        
        
        // Set the score as being the current score. This is zero if we are starting a new game.
        Text num_score = GameObject.Find("Numerical_Score").GetComponent<Text>();
        num_score.text = score.ToString();

        current_night = night;

        // LOGIC FOR SPAWNING ROCKS ON MAP HERE
        spawn_rocks(row1);
        spawn_rocks(row2);
        spawn_rocks(row3);
        spawn_rocks(row4);
        spawn_rocks(row5);
        spawn_rocks(row6);
        spawn_rocks(row7);
        spawn_rocks(row8);


        // Update the night number on the screen
        Text night_text = GameObject.Find("Night").GetComponent<Text>();
        night_text.text = "- Night " + night.ToString() + " -";


        // Turn the lights on!
        GameObject full_light = GameObject.Find("Full_Light");
        StartCoroutine(LightenSky(full_light, night, phrase, time_between_boats));
    }

    IEnumerator LightenSky(GameObject full_light, int night, Text phrase, float time_between_boats)
    {
        yield return new WaitForSeconds(0.5f);

        // Turn light on.
        Light2D light = full_light.GetComponent<Light2D>();
        light.intensity = 0.1f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.2f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.4f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.6f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.8f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 1f;

        // Wait.
        yield return new WaitForSeconds(3f);

        // Turn light off.
        light.intensity = 0.8f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.6f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.4f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.2f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0.1f;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 0f;
        yield return new WaitForSeconds(0.5f);

        // Display phrase
        phrase.text = "3";
        phrase.enabled = true;
        yield return new WaitForSeconds(1f);
        phrase.text = "2";
        yield return new WaitForSeconds(1f);
        phrase.text = "1";
        yield return new WaitForSeconds(1f);
        phrase.text = "B";
        yield return new WaitForSeconds(0.1f);
        phrase.text = "Be";
        yield return new WaitForSeconds(0.1f);
        phrase.text = "Beg";
        yield return new WaitForSeconds(0.1f);
        phrase.text = "Begi";
        yield return new WaitForSeconds(0.1f);
        phrase.text = "Begin";
        yield return new WaitForSeconds(0.1f);
        phrase.text = "Begin!";
        yield return new WaitForSeconds(0.5f);
        phrase.enabled = false;

        // Make beam visible
        GameObject Beam = GameObject.Find("Beam");
        Beam.GetComponent<FollowMouse>().enabled = true;
        yield return new WaitForSeconds(0.05f);
        Beam.GetComponent<Light2D>().enabled = true;

        // Start timer
        StartCoroutine(Countdown(night, phrase, time_between_boats));

        // Start Spawning boats
        spawn_boats = true;

        StartCoroutine(actualSpawnBoats(time_between_boats));

        // Spawn in first boat
        yield return new WaitForSeconds(1f);
        int row_index = Random.Range(0, 8);
        int direction = Random.Range(0,2);
        Debug.Log("boat in row " + row_index + " and in direction " + direction);
        float ycoord = -100f;
        float xcoord = -100f;
        int sorting_layer = 0;
        int[] arrow_possibilities = new int [2];
        int actual_arrow = 0;
        GameObject actual_game_arrow = Arrow1;
        switch (row_index)
        {
            case 0: ycoord = -4.1f;
                    sorting_layer = 24;
                    arrow_possibilities[0] = 8;
                    arrow_possibilities[1] = 16;
            break;
            case 1: ycoord = -3.1f;
                    sorting_layer = 21;
                    arrow_possibilities[0] = 7;
                    arrow_possibilities[1] = 15;
            break;
            case 2: ycoord = -2.1f;
                    sorting_layer = 18;
                    arrow_possibilities[0] = 6;
                    arrow_possibilities[1] = 14;
            break;
            case 3: ycoord = -1.1f;
                    sorting_layer = 15;
                    arrow_possibilities[0] = 5;
                    arrow_possibilities[1] = 13;
            break;
            case 4: ycoord = -0.1f;
                    sorting_layer = 12;
                    arrow_possibilities[0] = 4;
                    arrow_possibilities[1] = 12;
            break;
            case 5: ycoord = 0.9f;
                    sorting_layer = 9;
                    arrow_possibilities[0] = 3;
                    arrow_possibilities[1] = 11;
            break;
            case 6: ycoord = 1.9f;
                    sorting_layer = 6;
                    arrow_possibilities[0] = 2;
                    arrow_possibilities[1] = 10;
            break;
            case 7: ycoord = 2.9f;
                    sorting_layer = 3;
                    arrow_possibilities[0] = 1;
                    arrow_possibilities[1] = 9;
            break;
            default:
            break;
        }
        switch(direction)
        {
            case 0: xcoord = -5f;
                    actual_arrow = arrow_possibilities[0];
            break;
            case 1: xcoord = 9.5f;
                    actual_arrow = arrow_possibilities[1];
            break;
            default:
            break;
        }

        switch(actual_arrow)
        {
            case 1: actual_game_arrow = Arrow1;
            break;
            case 2: actual_game_arrow = Arrow2;
            break;
            case 3: actual_game_arrow = Arrow3;
            break;
            case 4: actual_game_arrow = Arrow4;
            break;
            case 5: actual_game_arrow = Arrow5;
            break;
            case 6: actual_game_arrow = Arrow6;
            break;
            case 7: actual_game_arrow = Arrow7;
            break;
            case 8: actual_game_arrow = Arrow8;
            break;
            case 9: actual_game_arrow = Arrow9;
            break;
            case 10: actual_game_arrow = Arrow10;
            break;
            case 11: actual_game_arrow = Arrow11;
            break;
            case 12: actual_game_arrow = Arrow12;
            break;
            case 13: actual_game_arrow = Arrow13;
            break;
            case 14: actual_game_arrow = Arrow14;
            break;
            case 15: actual_game_arrow = Arrow15;
            break;
            case 16: actual_game_arrow = Arrow16;
            break;
            default:
            break;
        }

        actual_game_arrow.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        actual_game_arrow.SetActive(false);

        GameObject boat = (GameObject)Resources.Load("Prefabs/Boat1", typeof(GameObject));
        GameObject actualboat = Instantiate(boat, new Vector3(xcoord, ycoord, 0f), Quaternion.identity);
        actualboat.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
        BoatBehaviour bh = actualboat.GetComponent<BoatBehaviour>();
        bh.directional_int = direction;
        boats.Add(actualboat); // All boats spawned are added to this list

        yield return null;
    }

    void spawn_rocks(Vector3[] row)
    {
        // Make sure that we do not spawn two consecutive rocks in the same index
        int row1_index = Random.Range(0, 6);
        while(row1_index == last_viable_index || row1_index == last_viable_index + 1 || row1_index == last_viable_index - 1)
        {
            row1_index = Random.Range(0, 6);
        }
        last_viable_index = row1_index;

        // Choose which type of rock
        int rock_type = Random.Range(0, 4);

        // Choose sorting layer
        int sorting_layer = 0;
        switch(row[row1_index].y)
        {
            case -4.1f: sorting_layer = 23;
            break;
            case -3.1f: sorting_layer = 20;
            break;
            case -2.1f: sorting_layer = 17;
            break;
            case -1.1f: sorting_layer = 14;
            break;
            case -0.1f: sorting_layer = 11;
            break;
            case 0.9f: sorting_layer = 8;
            break;
            case 1.9f: sorting_layer = 5;
            break;
            case 2.9f: sorting_layer = 2;
            break;
        }

        // Spawn in rock
        switch (rock_type)
        {
        case 0:
            // spawn 0
            GameObject rock1 = (GameObject)Resources.Load("Prefabs/Rocks1", typeof(GameObject));
            GameObject actualrock1 = Instantiate(rock1, row[row1_index], Quaternion.identity);
            actualrock1.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
            rocks.Add(actualrock1);
            break;
        case 1:
            // spawn 1
            GameObject rock2 = (GameObject)Resources.Load("Prefabs/Rocks2", typeof(GameObject));
            GameObject actualrock2 = Instantiate(rock2, row[row1_index], Quaternion.identity);
            actualrock2.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
            rocks.Add(actualrock2);
            break;
        case 2:
            // spawn 2
            GameObject rock3 = (GameObject)Resources.Load("Prefabs/Rocks3", typeof(GameObject));
            GameObject actualrock3 = Instantiate(rock3, row[row1_index], Quaternion.identity);
            actualrock3.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
            rocks.Add(actualrock3);
            break;
        case 3:
            // spawn 3
            GameObject rock4 = (GameObject)Resources.Load("Prefabs/Rocks4", typeof(GameObject));
            GameObject actualrock4 = Instantiate(rock4, row[row1_index], Quaternion.identity);
            actualrock4.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
            rocks.Add(actualrock4);
            break;
        default:
        break;
        }
    }

    IEnumerator actualSpawnBoats(float time_between_boats)
    {
        while(spawn_boats && global_timer > 5)
        {
            float random_interval = Random.Range(3.5f, time_between_boats);
            yield return new WaitForSeconds(random_interval);
            if(spawn_boats && global_timer > 5)
            {
                bool appropriate_spot = false;
                int row_index = 0;
                int direction = 0;
                float ycoord = -100f;
                float xcoord = -100f;
                int sorting_layer = 0;
                int[] arrow_possibilities = new int [2];
                int actual_arrow = 0;
                GameObject actual_game_arrow = Arrow1;

                while(!appropriate_spot && global_timer > 5)
                {
                    appropriate_spot = true;
                    row_index = Random.Range(0, 8);
                    direction = Random.Range(0,2);
                    int ray = 0;
                    Debug.Log("boat in row " + row_index + " and in direction " + direction);

                    switch (row_index)
                    {
                        case 0: ycoord = -4.1f;
                                sorting_layer = 24;
                                arrow_possibilities[0] = 8;
                                arrow_possibilities[1] = 16;
                        break;
                        case 1: ycoord = -3.1f;
                                sorting_layer = 21;
                                arrow_possibilities[0] = 7;
                                arrow_possibilities[1] = 15;
                        break;
                        case 2: ycoord = -2.1f;
                                sorting_layer = 18;
                                arrow_possibilities[0] = 6;
                                arrow_possibilities[1] = 14;
                        break;
                        case 3: ycoord = -1.1f;
                                sorting_layer = 15;
                                arrow_possibilities[0] = 5;
                                arrow_possibilities[1] = 13;
                        break;
                        case 4: ycoord = -0.1f;
                                sorting_layer = 12;
                                arrow_possibilities[0] = 4;
                                arrow_possibilities[1] = 12;
                        break;
                        case 5: ycoord = 0.9f;
                                sorting_layer = 9;
                                arrow_possibilities[0] = 3;
                                arrow_possibilities[1] = 11;
                        break;
                        case 6: ycoord = 1.9f;
                                sorting_layer = 6;
                                arrow_possibilities[0] = 2;
                                arrow_possibilities[1] = 10;
                        break;
                        case 7: ycoord = 2.9f;
                                sorting_layer = 3;
                                arrow_possibilities[0] = 1;
                                arrow_possibilities[1] = 9;
                        break;
                        default:
                        break;
                    }
                    switch(direction)
                    {
                        case 0: xcoord = -5f;
                                ray = 3;
                                actual_arrow = arrow_possibilities[0];
                        break;
                        case 1: xcoord = 9.5f;
                                ray = -3;
                                actual_arrow = arrow_possibilities[1];
                        break;
                        default:
                        break;
                    }

                    RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector3(xcoord,ycoord,0), new Vector3(ray, 0, 0));
                    foreach (RaycastHit2D obj in hit) 
                    {
                        if(obj.collider.tag == "boatcollision")
                        {
                            Debug.Log("something in the way");
                            appropriate_spot = false;
                        }
                    }
                }

                // May need logic for choosing boat here
                if(spawn_boats && global_timer > 5)
                {
                    switch(actual_arrow)
                    {
                        case 1: actual_game_arrow = Arrow1;
                        break;
                        case 2: actual_game_arrow = Arrow2;
                        break;
                        case 3: actual_game_arrow = Arrow3;
                        break;
                        case 4: actual_game_arrow = Arrow4;
                        break;
                        case 5: actual_game_arrow = Arrow5;
                        break;
                        case 6: actual_game_arrow = Arrow6;
                        break;
                        case 7: actual_game_arrow = Arrow7;
                        break;
                        case 8: actual_game_arrow = Arrow8;
                        break;
                        case 9: actual_game_arrow = Arrow9;
                        break;
                        case 10: actual_game_arrow = Arrow10;
                        break;
                        case 11: actual_game_arrow = Arrow11;
                        break;
                        case 12: actual_game_arrow = Arrow12;
                        break;
                        case 13: actual_game_arrow = Arrow13;
                        break;
                        case 14: actual_game_arrow = Arrow14;
                        break;
                        case 15: actual_game_arrow = Arrow15;
                        break;
                        case 16: actual_game_arrow = Arrow16;
                        break;
                        default:
                        break;
                    }

                    actual_game_arrow.SetActive(true);
                    yield return new WaitForSeconds(1.5f);
                    actual_game_arrow.SetActive(false);

                    GameObject boat = (GameObject)Resources.Load("Prefabs/Boat1", typeof(GameObject));
                    GameObject actualboat = Instantiate(boat, new Vector3(xcoord, ycoord, 0f), Quaternion.identity);
                    actualboat.GetComponent<SpriteRenderer>().sortingOrder = sorting_layer;
                    BoatBehaviour bh = actualboat.GetComponent<BoatBehaviour>();
                    bh.directional_int = direction;
                    boats.Add(actualboat); // All boats spawned are added to this list
                }
            }
        }
        Debug.Log("loop ended");
        yield return null;
    }

    IEnumerator Countdown(int night, Text phrase, float time_between_boats)
    {
        // Get the timer value on screen
        Text onscreen_time = GameObject.Find("Time").GetComponent<Text>();
        
        // Make sure Timer animation is set to 'visible'
        Animator anim = GameObject.Find("Timer").GetComponent<Animator>();
        anim.SetInteger("TimerState", 1);

        // Hack to synch up the animation and the actual timer
        yield return new WaitForSeconds(0.15f);

        while (global_timer > 0 && !game_over)
        {
            yield return new WaitForSeconds(1.016667f);
            //anim.SetInteger("TimerState", 0);
            global_timer = global_timer - 1;
            onscreen_time.text = global_timer.ToString();
            //anim.SetInteger("TimerState", 1);
            AnimatorClipInfo[] m_CurrentClipInfo = anim.GetCurrentAnimatorClipInfo(0);;
        }

        // Stop spawning boats

        if (!game_over)
        {
            spawn_boats = false;
            // Make beam inactive
                GameObject Beam = GameObject.Find("Beam");
                Beam.GetComponent<Light2D>().enabled = false;
                Beam.GetComponent<FollowMouse>().enabled = false;

            anim.SetInteger("TimerState", 0);

            // Update high score
            if (night > high_score)
            {
                high_score = night;
            }

            yield return new WaitForSeconds(1f);

            if (!game_over)
            {
                End_Once = false;

                // Make beam inactive
                //GameObject Beam = GameObject.Find("Beam");
                //Beam.GetComponent<Light2D>().enabled = false;
                //Beam.GetComponent<FollowMouse>().enabled = false;

                // Remove all rocks
                foreach (GameObject individual_rock in rocks) 
                {
                    Destroy(individual_rock);
                }
                rocks.Clear();

                // Remove all boats
                foreach (GameObject individual_boat in boats) 
                {
                    if(individual_boat != null)
                    {
                        Destroy(individual_boat);
                    }
                }
                boats.Clear();

                // final check on boats with deathblock
                db.SetActive(true);
                StartCoroutine(final_check(db));

                // Make sure hint arrows are deactivated at start
                Arrow1.SetActive(false);
                Arrow2.SetActive(false);
                Arrow3.SetActive(false);
                Arrow4.SetActive(false);
                Arrow5.SetActive(false);
                Arrow6.SetActive(false);
                Arrow7.SetActive(false);
                Arrow8.SetActive(false);
                Arrow9.SetActive(false);
                Arrow10.SetActive(false);
                Arrow11.SetActive(false);
                Arrow12.SetActive(false);
                Arrow13.SetActive(false);
                Arrow14.SetActive(false);
                Arrow15.SetActive(false);
                Arrow16.SetActive(false);

                yield return new WaitForSeconds(0.7f);

                // Display "Night X Complete" on screen
                phrase.text = "N";
                phrase.enabled = true;
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Ni";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Nig";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Nigh";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night ";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString();
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " ";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " C";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Co";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Com";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Comp";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Compl";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Comple";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Complet";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Complete";
                yield return new WaitForSeconds(0.1f);
                phrase.text = "Night " + night.ToString() + " Complete!";
                yield return new WaitForSeconds(1f);
                phrase.enabled = false;

                // Logic for determining how to increment boat and rock numbers...
                if(time_between_boats > 4f)
                {
                    time_between_boats = time_between_boats - 2f;
                }

                End_Once = true;
                Begin_Round(high_score, 30, night + 1, time_between_boats);
                yield return null;
            }
        }
        yield return null;
    }

    // Function called when a boat collides, from the BoatCollision script
    public void End_Round(Vector3 sunk_boat_pos, GameObject col, GameObject hitter)
    {
        if (End_Once)
        {
            End_Once = false;
            game_over = true;

            GameObject.Find("Jukebox").GetComponent<MusicSingleton>().StopMusic();

            if(col.GetComponent<SpriteRenderer>().sortingOrder == hitter.GetComponent<SpriteRenderer>().sortingOrder)
            {
                col.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }

            Animator anim = GameObject.Find("Timer").GetComponent<Animator>();
            anim.SetInteger("TimerState", 0);

            GameObject Beam = GameObject.Find("Beam");
            Beam.GetComponent<FollowMouse>().enabled = false;

            spawn_boats = false;
            foreach (GameObject individual_boat in boats) 
            {
                if(individual_boat != null)
                {
                    individual_boat.GetComponent<BoatBehaviour>().should_i_move = false;
                }
            }

            // Make sure hint arrows are deactivated at start
            Arrow1.SetActive(false);
            Arrow2.SetActive(false);
            Arrow3.SetActive(false);
            Arrow4.SetActive(false);
            Arrow5.SetActive(false);
            Arrow6.SetActive(false);
            Arrow7.SetActive(false);
            Arrow8.SetActive(false);
            Arrow9.SetActive(false);
            Arrow10.SetActive(false);
            Arrow11.SetActive(false);
            Arrow12.SetActive(false);
            Arrow13.SetActive(false);
            Arrow14.SetActive(false);
            Arrow15.SetActive(false);
            Arrow16.SetActive(false);

            StartCoroutine(LocateCollision(sunk_boat_pos, Beam));
        }
    }

    
    IEnumerator final_check(GameObject db)
    {
        float speedOfRotation = 200f;
        spintime = true;
        StartCoroutine(spintime_count());
        while(spintime)
        {
            db.transform.Rotate(new Vector3(0,0,1)*speedOfRotation*Time.deltaTime);
            yield return null;
        }
        db.SetActive(false);
        yield return null;
    }

    IEnumerator spintime_count()
    {
        yield return new WaitForSeconds(1f);
        spintime = false;
    }

    IEnumerator LocateCollision(Vector3 sunk_boat_pos, GameObject Beam)
    {
        yield return new WaitForSeconds(1f);

        Vector3 destination = new Vector3(sunk_boat_pos.x, sunk_boat_pos.y + 0.2f, sunk_boat_pos.z);

        while(Beam.transform.position != destination)
        {
            Beam.transform.position = Vector3.MoveTowards(Beam.transform.position, destination, 2.5f * Time.deltaTime);
            yield return null;
        }
        yield return null;

        yield return new WaitForSeconds(1f);

        // Make beam inactive
            Beam.GetComponent<Light2D>().enabled = false;

            yield return new WaitForSeconds(0.7f);

            // Remove all rocks
            foreach (GameObject individual_rock in rocks) 
            {
                Destroy(individual_rock);
            }
            rocks.Clear();

            // Remove all boats
            foreach (GameObject individual_boat in boats) 
            {
                if(individual_boat != null)
                {
                    Destroy(individual_boat);
                }
            }
            boats.Clear();

            // final check on boats with deathblock
            db.SetActive(true);
            StartCoroutine(final_check(db));

            Text phrase = GameObject.Find("Phrase").GetComponent<Text>();

            // Display "Night X Complete" on screen
            phrase.text = "G";
            phrase.enabled = true;
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Ga";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Gam";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game ";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game O";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game Ov";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game Ove";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game Over";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Game Over!";
            yield return new WaitForSeconds(1f);

            phrase.text = "";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "N";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Ni";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nig";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nigh";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Night";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights ";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights S";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Su";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Sur";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Surv";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survi";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Surviv";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survive";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survived";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survived:";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survived: ";
            yield return new WaitForSeconds(0.1f);
            phrase.text = "Nights Survived: " + (current_night - 1).ToString();
            yield return new WaitForSeconds(3f);
            phrase.enabled = false;
            game_over = false;
            End_Once = true;
            Text night_text = GameObject.Find("Night").GetComponent<Text>();
            night_text.text = "- Night 1 -";
            yield return new WaitForSeconds(1f);

            Begin_Round(high_score, 30, 1, 10);
            yield return null;
    }
}
