using UnityEngine;
using System.Collections;

public class GameSceneCreator : MonoBehaviour {

	static public int startEnemiesCount = 18;

	public float levelWidth = 800;
	public float levelHeight = 500;

	void Start () {
		for (int i = 0; i < startEnemiesCount; ++i) {
			CreateEnemy();
		}
	}

	void CreateEnemy() {
		float x = BothBoundsRandoms(60, 200);
		float y = BothBoundsRandoms(600, 800);

		Debug.Log("x = " + x + ", y = " + y);

		Vector3 position = new Vector3(x, y, 0);
		Instantiate(Resources.Load("Prefabs/Enemy"), position, Quaternion.identity);

	}

	static float BothBoundsRandoms(float lower, float upper) {
        float number = Random.Range(lower, upper);
        return number;
    }

}
