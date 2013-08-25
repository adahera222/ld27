using UnityEngine;
using System.Collections;

public class BulletFly : MonoBehaviour {

	public int state = 0;

	float bulletSpeed = 60;
	float flyTime = 30f;
	
	void Update () {

		switch (state) {
			case 4:
				//down
				// this.transform.Rotate(0f, 0f, 90f);
				this.rigidbody.velocity = new Vector3(0, -1 * bulletSpeed, 0);
				break;

			case 5:
				//up
				this.rigidbody.velocity = new Vector3(0, bulletSpeed, 0);
				break;

			case 6:
				//left
				this.rigidbody.velocity = new Vector3(-1 * bulletSpeed, 0, 0);
				break;

			case 7:
				//right
				this.rigidbody.velocity = new Vector3(bulletSpeed, 0, 0);
				break;
		}	

		if (flyTime > 0) {
			flyTime -= Time.deltaTime;
		} else {
			Destroy(this.gameObject);
		}
	}

}
