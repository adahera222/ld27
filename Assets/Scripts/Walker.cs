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

	public WalkingState walkingState = WalkingState.RestDown;

	public float walkingSpeed = 8.0f;

	void Start () {
		ragePixel = GetComponent<RagePixelSprite>();
	}
	
	void Update () {
		// if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxisRaw("Horizontal") < 0)) {
        //     state = WalkingState.WalkLeft;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow) || (Input.GetAxisRaw("Horizontal") > 0)) {
        //     state = WalkingState.WalkRight;
        // }
        // else {
        //     state = WalkingState.Standing;
        // }
        // if (Input.GetButton("Jump")) {
        //     Debug.Log("JUMP!!!");
        // }

        // Debug.Log("Horizontal axis " + Input.GetAxisRaw("Horizontal").ToString());

        // Vector3 moveDirection = new Vector3();
        
        // switch (state) {
        //     case(WalkingState.Standing):
        //         ragePixel.SetHorizontalFlip(false);
        //         ragePixel.PlayNamedAnimation("STAY", false);
        //         break;

        //     case (WalkingState.WalkLeft):
        //         ragePixel.SetHorizontalFlip(true);
        //         ragePixel.PlayNamedAnimation("WALK", false);
        //         moveDirection = new Vector3(-1f, 0f, 0f);
        //         break;

        //     case (WalkingState.WalkRight):
        //         ragePixel.SetHorizontalFlip(false);
        //         ragePixel.PlayNamedAnimation("WALK", false);
        //         moveDirection = new Vector3(1f, 0f, 0f);
        //         break;
        // }

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

        var x = Input.GetAxis("Horizontal") * 100;
        var y = Input.GetAxis("Vertical") * 100;
        // // transform.Translate(x, y, 0);
        this.rigidbody.AddForce(x, y, 0);
	}
}
