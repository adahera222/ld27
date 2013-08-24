using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {

	private IRagePixel ragePixel;

	public enum WalkingState {
		RestDown = 0,
		RestUp,
		RestLeft,
		RestRight,
		WalkDown,
		WalkUp,
		WalkLeft,
		WalkRight,
	};

	public WalkingState state = WalkingState.RestDown;

	private float walkingSpeed = 18.0f;

	void Start () {
		ragePixel = GetComponent<RagePixelSprite>();
	}
	
	void Update () {

        int vertical = (int) Input.GetAxis("Vertical");
        int horizontal = (int) Input.GetAxis("Horizontal");

        WalkingState lastState = 0;

        switch (vertical) {
        	case 1:
        		state = WalkingState.WalkUp;
        		break;

        	case -1:
        		state = WalkingState.WalkDown;
        		break;

        	default:
        		break;
        }

        switch (horizontal) {
        	case 1:
        		state = WalkingState.WalkRight;
        		break;

        	case -1:
        		state = WalkingState.WalkLeft;
        		break;

        	default:
        		break;
        }

        lastState = state;
        
        switch (state) {
            case(WalkingState.RestDown):
                ragePixel.PlayNamedAnimation("REST_DOWN", false);
                break;

            case (WalkingState.RestUp):
                ragePixel.PlayNamedAnimation("REST_UP", false);
                break;

            case (WalkingState.RestLeft):
                ragePixel.PlayNamedAnimation("REST_LEFT", false);
                break;

            case (WalkingState.RestRight):
                ragePixel.PlayNamedAnimation("REST_RIGHT", false);
                break;

            case(WalkingState.WalkDown):
                ragePixel.PlayNamedAnimation("WALK_DOWN", false);
                break;

            case (WalkingState.WalkUp):
                ragePixel.PlayNamedAnimation("WALK_UP", false);
                break;

            case (WalkingState.WalkLeft):
                ragePixel.PlayNamedAnimation("WALK_LEFT", false);
                break;

            case (WalkingState.WalkRight):
                ragePixel.PlayNamedAnimation("WALK_RIGHT", false);
                break;
        }

        // if (Input.GetButton("Fire1")) {
        //     // Debug.Log("FIRE 1!!!");
        //     this.audio.clip = [];
        //     this.audio.Play(0);
        // }
        // if (Input.GetButton("Fire2")) {
        //     // Debug.Log("FIRE 2!!!");
        //     //change 
        // }
        // if (Input.GetButton("Fire3")) {
        //     Debug.Log("FIRE 3!!!");
        // }
        // if (Input.GetButton("Jump")) {
        //     Debug.Log("JUMP!!!");
        // }

        if (vertical == 0 && horizontal == 0) {
        	this.rigidbody.velocity = new Vector3(0f, 0f, 0f);

        	switch (lastState) {
        		case(WalkingState.WalkDown):
                	ragePixel.PlayNamedAnimation("REST_DOWN", false);
                	break;

            	case (WalkingState.WalkUp):
                	ragePixel.PlayNamedAnimation("REST_UP", false);
                	break;

            	case (WalkingState.WalkLeft):
                	ragePixel.PlayNamedAnimation("REST_LEFT", false);
                	break;

            	case (WalkingState.WalkRight):
                	ragePixel.PlayNamedAnimation("REST_RIGHT", false);
                	break;
        	}
        } else {
        	this.rigidbody.velocity = new Vector3(horizontal * walkingSpeed, vertical * walkingSpeed, 0);	
        }


	}

	// function ApplyForce (body : Rigidbody) {
	// 	var direction : Vector3 = body.transform.position - transform.position;
	// 	body.AddForceAtPosition(direction.normalized, transform.position);
	// }
}
