using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {

	private IRagePixel ragePixel;

	private float distanseToHero = 0;

	public enum WalkingState {
		Rest = 0, 
		WalkRight, 
		WalkLeft
	};

	public WalkingState walkingState = WalkingState.Rest;

	private float walkingSpeed = 22.0f;

	private float x = -15f;
	private float y = 0f;

	float time = 0;
	float maxTime = 6f;

	void Start() {
		ragePixel = GetComponent<RagePixelSprite>();
	}
	
	void Update() {

		if (x > 0) {
			walkingState = WalkingState.WalkRight;
		} else if (x < 0) {
			walkingState = WalkingState.WalkLeft;
		} else {
			walkingState = WalkingState.Rest;
		}
		time += Time.deltaTime;
		if (time >= maxTime) {
			x = -x;
			// y = y * (-1);
			time = 0;
		}

		// this.rigidbody.velocity = new Vector3(x, y, 0);

		// switch (walkingState) {
		// 	case WalkingState.Rest:
  //               ragePixel.PlayNamedAnimation("REST", false);
		// 		break;

		// 	case WalkingState.WalkRight:
		// 		ragePixel.SetHorizontalFlip(true);
  //               ragePixel.PlayNamedAnimation("WALK", false);
		// 		break;

		// 	case WalkingState.WalkLeft:
		// 		ragePixel.SetHorizontalFlip(false);
  //               ragePixel.PlayNamedAnimation("WALK", false);
		// 		break;				
		// }



		GameObject Hero = GameObject.FindWithTag("Hero");
		float d = Vector3.Distance(Hero.transform.position, this.gameObject.transform.position);

		Vector3 enemyPosition = this.gameObject.transform.position;
		Vector3 heroPosition = Hero.transform.position;

		Vector3 diff = heroPosition - enemyPosition;

		// this.rigidbody.velocity = diff;

		


		// if (calculateVector3ToHero != new Vector3(0f, 0f, 0f)) {
		// 	//
		// }

		// if (Input.GetKey(KeyCode.LeftArrow))
  //       {
  //           state = WalkingState.WalkLeft;
  //       }
  //       else if (Input.GetKey(KeyCode.RightArrow))
  //       {
  //           state = WalkingState.WalkRight;
  //       }
  //       else
  //       {
  //           state = WalkingState.Standing;
  //       }

  //       Vector3 moveDirection = new Vector3();
        
  //       switch (state)
  //       {
  //           case(WalkingState.Standing):
  //               ragePixel.SetHorizontalFlip(false);
                // ragePixel.PlayNamedAnimation("WALK", false);
  //               break;

  //           case (WalkingState.WalkLeft):
  //               ragePixel.SetHorizontalFlip(true);
  //               ragePixel.PlayNamedAnimation("WALK", false);
  //               moveDirection = new Vector3(-1f, 0f, 0f);
  //               break;

  //           case (WalkingState.WalkRight):
  //               ragePixel.SetHorizontalFlip(false);
  //               ragePixel.PlayNamedAnimation("WALK", false);
  //               moveDirection = new Vector3(1f, 0f, 0f);
  //               break;
  //       }

  //       transform.Translate(moveDirection * Time.deltaTime * walkingSpeed);
	}

	float CalculateVector3ToHero() {
		return 0f;
	}

	float CalculateVector3ToFood() {
		return 0f;
	}
}
