using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Vector3 shootDirection = new Vector3();

	static float kReloadTime = 10;

	private float timeToNextShoot = kReloadTime;

	public TextMesh TimeToReload;

	public AudioClip audioShoot;
	public AudioClip audioFail;

	// private bool isFailPlay = false;
	private float failInterval = 0f;
	
	void Update () {

		if (timeToNextShoot <= 0) {
			// i can shoot!
			if (Input.GetButton("Fire1")) {
				timeToNextShoot = kReloadTime;

				Vector3 position = this.gameObject.transform.position;
				int state = (int) this.gameObject.GetComponent<Walker>().lastState;

				switch (state) {
					case 4:
						break;

					case 5:
						position.x = position.x + 8;
						break;

					case 6:
						position.y = position.y + 10;
						break;

					case 7:
						position.y = position.y + 10;
						position.x = position.x + 8;
						break;
					
				}
				GameObject bullet = (GameObject) Instantiate(Resources.Load("Prefabs/Bullet"), position, Quaternion.identity);

				bullet.GetComponent<BulletFly>().state = state;

				audio.PlayOneShot(audioShoot);
			}
			
			TimeToReload.text = "You can shoot!";

		} else {
			if (Input.GetButton("Fire1")) {
				if (failInterval<= 0) {
					audio.PlayOneShot(audioFail);
					failInterval = 0.5f;
				} else {
					//
				}
			}

			timeToNextShoot -= Time.deltaTime;
			TimeToReload.text = "" + timeToNextShoot;
		}
		failInterval -= Time.deltaTime;

	}
}

