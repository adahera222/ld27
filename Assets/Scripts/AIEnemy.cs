﻿using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {

	public IRagePixel ragePixel;

	public enum WalkingState {
		Rest = 0, 
		WalkRight, 
		WalkLeft
	};

	public bool isAlive = true;

	public int direction = 0;

	public WalkingState walkingState = WalkingState.Rest;

	static private float kOneDirectionTime = 5;

	private float oneDirectionTime = 0;

	private float movementSpeed = 25f;

	private float timeAfterDeath = 0;

	public AudioClip death;

	void Start() {
		ragePixel = GetComponent<RagePixelSprite>();
		ragePixel.PlayNamedAnimation("WALK", false);
	}
	
	void Update() {
		// ragePixel.SetHorizontalFlip(true);
		if (!isAlive) {
			this.rigidbody.velocity = new Vector3(0, 0, 0);
			timeAfterDeath += Time.deltaTime;
			if (timeAfterDeath > 5) {
				Destroy(this.gameObject);
			}
			return;
		}

		if (oneDirectionTime <= 0) {
			ChangeDirection();
		} else {
			oneDirectionTime -= Time.deltaTime;
		}

		GameObject Hero = GameObject.FindWithTag("Hero");
		float d = Vector3.Distance(Hero.transform.position, this.gameObject.transform.position);

		if (d < 150) {
			Vector3 enemyPosition = this.gameObject.transform.position;
			Vector3 heroPosition = Hero.transform.position;

			Vector3 diff = heroPosition - enemyPosition;

			this.rigidbody.velocity = diff / 5;

			int dir = (int) this.rigidbody.velocity.x;
			switch (dir) {
				case 0:
					ragePixel.SetHorizontalFlip(false);
					break;

				case 1:
					ragePixel.SetHorizontalFlip(true);
					break;
			}
		}
	}

	void ChangeDirection() {
		direction = Random.Range(0, 3);
		switch (direction) {
			case 0:
				// ragePixel.SetHorizontalFlip(false);
				this.rigidbody.velocity = new Vector3(-movementSpeed, 0, 0);
				break;

			case 1:
				// ragePixel.SetHorizontalFlip(true);
				this.rigidbody.velocity = new Vector3(movementSpeed, 0, 0);
				break;

			case 2:
				this.rigidbody.velocity = new Vector3(0, movementSpeed, 0);
				break;

			case 3:
				this.rigidbody.velocity = new Vector3(0, -movementSpeed, 0);
				break;
		}
		oneDirectionTime = kOneDirectionTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Bullet(Clone)") {
			Destroy(other.gameObject);

			ragePixel.PlayNamedAnimation("DEATH", false);
			isAlive = false;
			audio.PlayOneShot(death);

			GameObject Hero = GameObject.FindWithTag("Hero");
			Vector3 position = Hero.transform.position;
			Camera.mainCamera.GetComponent<GameSceneCreator>().CreateEnemyNearBy(position);
		} else {
			ChangeDirection();
		}
    }

}
