using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponOnGround : MonoBehaviour
{
    playerBase playerState;
    playerMovement playerMov;
    animHandler anim;
    const string onGround = "OnGround";
    const string idle = "Idle";
    GameObject player;
    Vector3 newPos;
    float side;
    // Start is called before the first frame update
    void Start(){
        Physics2D.IgnoreLayerCollision(8, 11);
        player = GameObject.FindGameObjectWithTag("Player");
        playerState = player.GetComponent<playerBase>();
        playerMov = player.GetComponent<playerMovement>();
        anim = GetComponent<animHandler>();
    }

    // Update is called once per frame
    void Update(){
        side = player.transform.localScale.x > 0 ? 1 : -1;
    }

    void OnTriggerStay2D(Collider2D collision) {
        anim.ChangeAnimationState(onGround);
        if (Input.GetKeyDown("e")) {
            Debug.Log("Se presiono E");
            newPos = player.transform.position;
            if ( side > 0) {
                newPos.x += -0.45f;
                newPos.y += 0.07f;
            }
            else if ( side < 0){
                newPos.x += 0.45f;
                newPos.y += 0.07f;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            transform.position = newPos;
            transform.parent = player.transform;
            playerMov.holding = true;
            Physics2D.IgnoreLayerCollision(8, 9);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        anim.ChangeAnimationState(onGround);
    }

    void OnTriggerExit2D(Collider2D collision) {
        anim.ChangeAnimationState(idle);
    }
}

