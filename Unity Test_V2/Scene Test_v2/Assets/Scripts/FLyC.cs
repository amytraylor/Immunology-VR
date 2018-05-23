using UnityEngine;
using System.Collections;

public class FLyC : MonoBehaviour {
	public float rotateSpeed = 25.0f;
	public float speed;
	private float trueSpeed;
	// Use this for initialization
	void Start () {
		trueSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
		var transAmount = speed * Time.deltaTime;
		var rotateAmount = rotateSpeed * Time.deltaTime;

		float x = transform.rotation.eulerAngles.x;
		float y = transform.rotation.eulerAngles.y;

		if (Input.GetKey("up")) {
			transform.Rotate(rotateAmount, 0, 0);	

		}
		if (Input.GetKey("down")) {
			transform.Rotate(-rotateAmount, 0, 0);	
		}
		if (Input.GetKey("left")) {
			transform.Rotate(0, -rotateAmount, 0);
		}
		if (Input.GetKey("right")) {
			transform.Rotate(0, rotateAmount, 0);
		}

		if (Input.GetKey ("s")) {
			trueSpeed = -speed;
			GetComponent<Rigidbody> ().velocity = new Vector3 (trueSpeed*Mathf.Sin(y/180f*3.1415926f),
				trueSpeed*Mathf.Sin(x/180f*3.1415926f),
				trueSpeed*(Mathf.Cos(y/180f*3.1415926f)*Mathf.Cos(x/180f*3.1415926f)));
			//transform.Translate(0, 0, (transAmount * (-1))); 
		}

		if (Input.GetKey ("w")) {
			//transform.Translate(0, 0, (transAmount * 1 ));
			trueSpeed=speed;		
			GetComponent<Rigidbody> ().velocity = new Vector3 (trueSpeed*Mathf.Sin(y/180f*3.1415926f),
				trueSpeed*Mathf.Sin(x/180f*3.1415926f),
				trueSpeed*(Mathf.Cos(y/180f*3.1415926f)*Mathf.Cos(x/180f*3.1415926f)));
		}

	}
}