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

	public float walkingSpeed = 8.0f;

	void Start () {
		ragePixel = GetComponent<RagePixelSprite>();
	}
	
	void Update () {

        int vertical = (int) Input.GetAxis("Vertical");
        int horizontal = (int) Input.GetAxis("Horizontal");

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

        // transform.Translate(moveDirection * Time.deltaTime * walkingSpeed);

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

        this.rigidbody.AddForce(horizontal * 8, vertical * 8, 0);
	}
}
