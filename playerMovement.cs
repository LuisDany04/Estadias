using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{

    public float speed;
    public float diagonalSpeed;
    Vector3 newScale;
    float newScaleX;
    bool InputEnabled = true;
    Animator anim;
    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        newScale = transform.localScale;
        newScaleX = newScale.x;
    }

    // Update is called once per frame
    void Update(){
        if (InputEnabled) {

            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            //Movement
            if (inputX != 0 && inputY != 0) {
                transform.Translate(inputX * (speed-1) * Time.deltaTime, 0f, 0f);
                transform.Translate(0f, inputY * (speed-1) * Time.deltaTime, 0f);
            }
            else {
                transform.Translate(inputX * speed * Time.deltaTime, 0f, 0f);
                transform.Translate(0f, inputY * speed * Time.deltaTime, 0f);
            }

            //Flip
            if (inputX > 0) newScale.x = newScaleX;
            if (inputX < 0) newScale.x = -newScaleX;
            transform.localScale = newScale;

            //Animation detection
            if (inputX != 0 || inputY != 0) {
                anim.SetBool("Moving", true);
            }
            else if (inputX == 0 && inputY == 0) {
                anim.SetBool("Moving", false);
            }
        }

    }
}
