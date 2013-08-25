using UnityEngine;
using System.Collections;

public class GameSceneCreator : MonoBehaviour {

	static public int startEnemiesCount = 87;

	public float levelWidth = 800;
	public float levelHeight = 500;

	public AudioClip clip;

	void Start () {
		audio.loop = true;
		audio.clip = clip;
		audio.Play();
		for (int i = 0; i < startEnemiesCount; ++i) {
			CreateEnemy();
		}
	}

	void CreateEnemy() {
		float x = BothBoundsRandoms(60, 100);
		float y = BothBoundsRandoms(700, 1000);

		Vector3 position = new Vector3(x, y, 0);
		Instantiate(Resources.Load("Prefabs/Enemy"), position, Quaternion.identity);
	}

	public void CreateEnemyNearBy(Vector3 position) {
		int f = (int) BothBoundsRandoms(0, 4);

		switch (f) {
			case 0:
				position.x = position.x + 100;
				break;

			case 1:
				position.x = position.x - 100;
				break;

			case 2:
				position.y = position.y + 100;
				break;

			case 3:
				position.y = position.y - 100;
				break;
		}

		Instantiate(Resources.Load("Prefabs/Enemy"), position, Quaternion.identity);
	}

	static float BothBoundsRandoms(float lower, float upper) {
        float number = Random.Range(lower, upper);
        return number;
    }

}
