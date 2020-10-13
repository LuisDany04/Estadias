using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemGFX : MonoBehaviour{
    public AIPath aiPath;
    Vector3 Flip;
    float FlipX;
    // Start is called before the first frame update
    void Start(){

        Flip = transform.localScale;
        FlipX = Flip.x;
    }

    // Update is called once per frame
    void Update(){

        if (aiPath.desiredVelocity.x >= 0.01f) {
            Flip.x = -FlipX;
        }
        else if (aiPath.desiredVelocity.x <= -0.01f) {
            Flip.x = FlipX;
        }
        transform.localScale = Flip;
    }
}
