using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Vector3 shootDirection = new Vector3();

	static float kReloadTime = 1;

	private float timeToNextShoot = kReloadTime;

	public TextMesh TimeToReload;

	void Start () {
		// Vector3 position = new Vector3(x, y, 0);
		// Instantiate(Resources.Load("Prefabs/Bullet"), position, Quaternion.identity);
	}
	
	void Update () {

		if (timeToNextShoot <= 0) {
			// i can shoot!
			if (Input.GetButton("Fire1")) {
				timeToNextShoot = kReloadTime;

				Vector3 position = this.gameObject.transform.position;
				GameObject bullet = (GameObject) Instantiate(Resources.Load("Prefabs/Bullet"), position, Quaternion.identity);

				int state = (int) this.gameObject.GetComponent<Walker>().lastState;

				bullet.GetComponent<BulletFly>().state = state;
			}

			TimeToReload.text = "You can shoot!";

		} else {
			timeToNextShoot -= Time.deltaTime;
			TimeToReload.text = "" + timeToNextShoot;
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
