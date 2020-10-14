using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{

    public bool InputEnabled = true;
    public bool holding;
    float inputX;
    float inputY;
    public float speed;
    public float diagonalSpeed;
    Vector3 newScale;
    float newScaleX;

    playerBase playerState;


    //Animation
    Animator anim;
    private string currentState;
    const string Idle = "Idle";
    const string Moving = "Moving";
    const string wpMoving = "weaponMoving";
    const string wpIdle = "weaponIdle";

    void Start(){
        anim = GetComponent<Animator>();
        newScale = transform.localScale;
        newScaleX = newScale.x;
        playerState = GetComponent<playerBase>();
    }

    // Update is called once per frame
    void Update(){
            
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if (InputEnabled) {

            switch (holding) {
                case true:
                    //Movement
                    if (inputX != 0 && inputY != 0) {
                        transform.Translate(inputX * (speed - 1) * Time.deltaTime, 0f, 0f);
                        transform.Translate(0f, inputY * (speed - 1) * Time.deltaTime, 0f);
                    }
                    else if (inputX != 0 || inputY != 0) {
                        transform.Translate(inputX * speed * Time.deltaTime, 0f, 0f);
                        transform.Translate(0f, inputY * speed * Time.deltaTime, 0f);
                        ChangeAnimationState(wpMoving);
                    }
                    //Animation detection
                    if (inputX == 0 && inputY == 0) {
                        ChangeAnimationState(wpIdle);
                    }
                    break;
                case false:
                    //Movement
                    if (inputX != 0 && inputY != 0) {
                        transform.Translate(inputX * (speed - 1) * Time.deltaTime, 0f, 0f);
                        transform.Translate(0f, inputY * (speed - 1) * Time.deltaTime, 0f);
                    }
                    else if (inputX != 0 || inputY != 0) {
                        transform.Translate(inputX * speed * Time.deltaTime, 0f, 0f);
                        transform.Translate(0f, inputY * speed * Time.deltaTime, 0f);
                        ChangeAnimationState(Moving);
                    }

                    //Animation detection
                    if (inputX == 0 && inputY == 0) {
                        ChangeAnimationState(Idle);
                    }
                    break;
            }
            //Flip
            if (inputX > 0) newScale.x = newScaleX;
            if (inputX < 0) newScale.x = -newScaleX;
            transform.localScale = newScale;
        }
        
    }

    public void ChangeAnimationState(string newState) {
        if (currentState == newState) return;
        anim.Play(newState);
        currentState = newState;
    }
}
