using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
		var x = Input.GetAxis("Horizontal") * 100;
        var y = Input.GetAxis("Vertical") * 100;
        this.rigidbody.AddForce(x, y, 0);
	}
}
