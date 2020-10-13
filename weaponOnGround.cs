using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponOnGround : MonoBehaviour
{
    animHandler anim;
    const string onGround = "OnGround";
    const string idle = "Idle";
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<animHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision) {
        anim.ChangeAnimationState(onGround);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        anim.ChangeAnimationState(onGround);
    }

    void OnTriggerExit2D(Collider2D collision) {
        anim.ChangeAnimationState(idle);
    }
}
