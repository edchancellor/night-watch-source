using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Logic : MonoBehaviour
{
    public GameObject N;
    public GameObject I;
    public GameObject G;
    public GameObject H;
    public GameObject T;
    public GameObject W;
    public GameObject A;
    public GameObject T_2;
    public GameObject C;
    public GameObject H_2;
    public GameObject click;
    public GameObject click2;
    public GameObject instructions_overlay;
    public GameObject transition;
    private bool overlay_visible;
    private bool ready_to_start;
    private bool transitioning;
    private bool click_available;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        overlay_visible = false;
        ready_to_start = false;
        transitioning = false;
        click_available = false;

        Color overlay_color = instructions_overlay.GetComponent<Image>().color;
        overlay_color.a = 0f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        Color Ncolor = N.GetComponent<Text>().color;
        Ncolor.a = 0f;
        N.GetComponent<Text>().color = Ncolor;
        I.GetComponent<Text>().color = Ncolor;
        G.GetComponent<Text>().color = Ncolor;
        H.GetComponent<Text>().color = Ncolor;
        T.GetComponent<Text>().color = Ncolor;
        W.GetComponent<Text>().color = Ncolor;
        A.GetComponent<Text>().color = Ncolor;
        T_2.GetComponent<Text>().color = Ncolor;
        C.GetComponent<Text>().color = Ncolor;
        H_2.GetComponent<Text>().color = Ncolor;
        click.SetActive(false);
        click2.SetActive(false);
        StartCoroutine(Transition_in());
        StartCoroutine(Initialise());
        StartCoroutine(clicker(click));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) 
        {
            if (!overlay_visible && click_available)
            {
                overlay_visible = true;
                StartCoroutine(Instructions());
            }

            if(ready_to_start)
            {
                ready_to_start = false;
                transitioning = true;
                StartCoroutine(start_game());
            }
        }
    }

    IEnumerator Transition_in()
    {
        Color transition_color = transition.GetComponent<Image>().color;
        transition_color.a = 0.8f;
        transition.GetComponent<Image>().color = transition_color;
        yield return new WaitForSeconds(0.1f);
        transition_color.a = 0.6f;
        transition.GetComponent<Image>().color = transition_color;
        yield return new WaitForSeconds(0.1f);
        transition_color.a = 0.4f;
        transition.GetComponent<Image>().color = transition_color;
        yield return new WaitForSeconds(0.1f);
        transition_color.a = 0.2f;
        transition.GetComponent<Image>().color = transition_color;
        yield return new WaitForSeconds(0.1f);
        transition_color.a = 0.1f;
        transition.GetComponent<Image>().color = transition_color;
        yield return new WaitForSeconds(0.1f);
        transition_color.a = 0f;
        transition.GetComponent<Image>().color = transition_color;

    }

    IEnumerator start_game()
    {
        Color overlay_color = transition.GetComponent<Image>().color;
        overlay_color.a = 0.1f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.2f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.4f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.6f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.8f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 1f;
        transition.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadSceneAsync("Game");
    }

    IEnumerator Instructions()
    {
        // Add overlay
        Color overlay_color = instructions_overlay.GetComponent<Image>().color;
        overlay_color.a = 0.1f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.2f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.4f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.6f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 0.8f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);
        overlay_color.a = 1f;
        instructions_overlay.GetComponent<Image>().color = overlay_color;
        yield return new WaitForSeconds(0.1f);

        // Instructions
        GameObject inst = GameObject.Find("-Instructions-");
        Text insttext = inst.GetComponent<Text>();
        Color instcol = insttext.color;
        instcol.a = 0f;
        insttext.color = instcol;
        insttext.text = "- Instructions -";
        yield return new WaitForSeconds(0.1f);
        instcol.a = 0.1f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.1f);
        instcol.a = 0.2f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.1f);
        instcol.a = 0.4f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.1f);
        instcol.a = 0.6f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.1f);
        instcol.a = 0.8f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.1f);
        instcol.a = 1f;
        insttext.color = instcol;
        yield return new WaitForSeconds(0.25f);

        // mouse
        GameObject mouse = GameObject.Find("Mouse");
        Text mousetext = mouse.GetComponent<Text>();
        Color mousecol = mousetext.color;
        mousecol.a = 0f;
        mousetext.color = mousecol;
        mousetext.text = "Use the Mouse to Search for Boats.";
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.2f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.4f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.6f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.8f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.25f);

        // up
        GameObject up = GameObject.Find("Up");
        mousetext = up.GetComponent<Text>();
        mousecol = mousetext.color;
        mousecol.a = 0f;
        mousetext.color = mousecol;
        mousetext.text = "Left Click to Send Boats Up.";
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.2f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.4f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.6f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.8f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.25f);

        // down
        GameObject down = GameObject.Find("Down");
        mousetext = down.GetComponent<Text>();
        mousecol = mousetext.color;
        mousecol.a = 0f;
        mousetext.color = mousecol;
        mousetext.text = "Right Click to Send Boats Down.";
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.2f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.4f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.6f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.8f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.25f);

        // Survive
        GameObject survive = GameObject.Find("Survive");
        mousetext = survive.GetComponent<Text>();
        mousecol = mousetext.color;
        mousecol.a = 0f;
        mousetext.color = mousecol;
        mousetext.text = "Survive as Long as Possible!";
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.2f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.4f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.6f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 0.8f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.1f);
        mousecol.a = 1f;
        mousetext.color = mousecol;
        yield return new WaitForSeconds(0.5f);


        StartCoroutine(clicker(click2));
        yield return new WaitForSeconds(0.75f);
        ready_to_start = true;

        
        yield return null;
    }

    IEnumerator clicker(GameObject toclick)
    {
        yield return new WaitForSeconds(0.75f);
        if(!click_available)
        {
            click_available = true;
        }
        if(!transitioning)
        {
            toclick.SetActive(true);
        }
        yield return new WaitForSeconds(0.75f);
        toclick.SetActive(false);
        StartCoroutine(clicker(toclick));
    }

    IEnumerator Initialise()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(N));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(I));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(G));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(H));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(T));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(W));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(A));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(T_2));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(C));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Fader(H_2));
    }

    IEnumerator Fader(GameObject Letter)
    {
        Color Letter_color = Letter.GetComponent<Text>().color;
        Letter_color.a = 0.1f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.2f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.4f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.6f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.8f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 1f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.425f);

        Letter_color.a = 0.8f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.6f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.4f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.2f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.1f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0.1f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.15f);

        Letter_color.a = 0f;
        Letter.GetComponent<Text>().color = Letter_color;
        yield return new WaitForSeconds(0.425f);

        StartCoroutine(Fader(Letter));
    }
}
