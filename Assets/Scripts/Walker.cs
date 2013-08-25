using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {

	private IRagePixel ragePixel;

	public AudioClip arr;

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
	public WalkingState lastState = 0;

	private bool isAlive = true;
	private float timeToRestart = 2f;

	private float walkingSpeed = 15.0f;

	float timeFromArr = 15;

	void Start () {
		ragePixel = GetComponent<RagePixelSprite>();
		audio.PlayOneShot(arr);
	}
	
	void Update () {
		if (!isAlive) {
			timeToRestart -= Time.deltaTime;
			if (timeToRestart <= 0) {
				Application.LoadLevel(Application.loadedLevel);
			}

			return;
		}

		if (timeFromArr > 0) {
			timeFromArr -= Time.deltaTime;
		} else {
			timeFromArr = BothBoundsRandoms(10, 20);
			audio.PlayOneShot(arr);
		}

        int vertical = (int) Input.GetAxis("Vertical");
        int horizontal = (int) Input.GetAxis("Horizontal");

        lastState = 0;

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

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Enemy(Clone)") {
			if (!other.gameObject.GetComponent<AIEnemy>().isAlive) {
				return;
			}
			ragePixel.PlayNamedAnimation("DEATH", false);
			isAlive = false;
		}
    }

    static float BothBoundsRandoms(float lower, float upper) {
        float number = Random.Range(lower, upper);
        return number;
    }

}
