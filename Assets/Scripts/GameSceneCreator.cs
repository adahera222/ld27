using UnityEngine;
using System.Collections;

public class GameSceneCreator : MonoBehaviour {

	public int startEnemiesCount = 18;

	public float levelWidth = 800;
	public float levelHeight = 500;

	void Start () {
		for (int i = 0; i < startEnemiesCount; ++i) {
			CreateEnemy();
		}
	}

	void CreateEnemy() {
		float x = BothBoundsRandoms(0, levelWidth);
		float y = BothBoundsRandoms(0, levelHeight);

		Vector3 position = new Vector3(x, y, 0);
		Instantiate(Resources.Load("Prefabs/Enemy"), position, Quaternion.identity);

	}

	static float BothBoundsRandoms(float lower, float upper) {
        float number = Random.Range(lower, upper);
        return number;
    }

}
