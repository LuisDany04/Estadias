using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemAtkk : MonoBehaviour
{
    AIPath enemAI;
    animHandler anim;

    const string atkk = "spiderAtkk";
    // Start is called before the first frame update
    void Start()
    {
        enemAI = GetComponent<AIPath>();
        anim = GetComponent<animHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemAI.reachedEndOfPath == true) {
            enemAI.canMove = false;
            anim.ChangeAnimationState(atkk);
        }
    }


}
