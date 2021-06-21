using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TailMovement : MonoBehaviour {
        public GameObject followObj;
        public Vector3 followObjPos;
        private Transform followObjComp;
        private List<Vector3> lastPos = new List<Vector3>();

        
    // Update is called once per frame
    //TODO: MAKE ANOTHER FUNCTION TO GLOBAL FUNCTION TO CALL ON SCUFFEDMOVEMENT -> Use transform.Translate - constant value += 5 * ... -> Foreach tail object with Find with tag 
    /*void Update() {
        lastPos = GameObject.Find("TailArray").GetComponent<tailCounter>().listPos;
        followObjPos = followObj.transform.position;
        followObjComp = followObj.GetComponent<Transform>();

        if(followObj.name == "ScuffedMan") {

            this.transform.position = followObjPos;// - new Vector3(this.transform.position.x * 0.1f, 0);
                        lastPos.Add(this.transform.position);
            //this.transform.position = followObjPos - new Vector3(this.transform.position.x * 0.1f, 0);
        } else {

            this.transform.position = lastPos.Last() - new Vector3(this.transform.position.x * 0.1f, 0);
                        lastPos.Add(this.transform.position);
            //TODO: SAVE POSITION of current tail and then use it for position of newxt TAKE LAST -1 in array
        }
        
            /*foreach (Vector3 item in lastPos)
            {
                Debug.Log(item + "-  This is last pos");
            }*/


        //this.transform.position = this.transform.position;
        //StartCoroutine(doThis());
        //Debug.Log("TAILS POSITION: " + this.transform.position + " FOLLOW OBJECT POSITION: " + followObjPos + " THIS IS TAIL: " + this.name);

        public void followFunc() {
            
        }
    }

/* IEnumerator doThis() {

}*/ 

// tail 1 goes to position of player before he moved tail 2 goes to tail 1 pos before it moved
//  tail1.position = scuffedman.position before he moved  
    