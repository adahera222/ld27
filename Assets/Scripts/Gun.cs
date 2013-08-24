using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Vector3 shootDirection = new Vector3();

	private float timeToNextShoot = 10;

	void Start () {
		// Vector3 position = new Vector3(x, y, 0);
		// Instantiate(Resources.Load("Prefabs/Bullet"), position, Quaternion.identity);
	}
	
	void Update () {
		if (timeToNextShoot <= 0) {
			// i can shoot!
			if (Input.GetButton("Fire1")) {
				timeToNextShoot = 10;
			}


		} else {
			timeToNextShoot -= Time.deltaTime;
		}
	}
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
