using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class FollowMouse : MonoBehaviour {

     Vector3 currentPos;
     Vector3 delta;
     Vector3 lastPos;
 
     // Use this for initialization
     void Start () 
     {
        currentPos = currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
        lastPos = currentPos;
        delta = currentPos - lastPos;
     }
     
     // Update is called once per frame
     void Update () 
     {

        /*currentPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
        delta = currentPos - lastPos;
        lastPos = currentPos;

        float diffX = transform.position.x + delta.x;
        float diffY = transform.position.y + delta.y;

        Vector3 beamPos = transform.position;

        if(diffX > -4.31 && diffX < 8.76)
        {
            beamPos.x = diffX;
        }

        if(diffY > -4.87 && diffY < 3.7)
        {
            beamPos.y = diffY;
        }

        transform.position = beamPos;

        Debug.Log(beamPos);*/
        
         
         Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.position.z)));
         newPos.z = transform.position.z;
         transform.position = newPos;
     }
 }

