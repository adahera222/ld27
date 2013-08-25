using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	private bool isGameStarted = false;

	void Start () {
	
	}
	
	void Update () {
		if (isGameStarted) {
			return;
		}

		if (Input.GetButton("Fire1")) {
			isGameStarted = true;
			ShootAnimation();
		}
	}

	void ShootAnimation() {
		for (int i = 0; i < 1; ++i) {
			// float x = BothBoundsRandoms(0, 0);
			// float y = BothBoundsRandoms(0, 0);

			Vector3 position = new Vector3(-50, -50, 90);
			Instantiate(Resources.Load("Prefabs/Shoot"), position, Quaternion.identity);
		}
	}

	static float BothBoundsRandoms(float lower, float upper) {
        float number = Random.Range(lower, upper);
        return number;
    }

}
