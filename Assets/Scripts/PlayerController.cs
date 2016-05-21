using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private int count;

	public Text scoreText;
	public Text winText;

	public float speed;
	
	void Start () {
		count = 0;
		setScoreText ();
		winText.text = "";
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D objectTouched) {
		if (objectTouched.gameObject.CompareTag ("PickUp")) {
			objectTouched.gameObject.SetActive (false);
			count++;
			setScoreText ();
			checkIfWonAndUpdateText ();
		}
	}

	void setScoreText() {
		scoreText.text = "Score: " + count.ToString ();
	}

	void checkIfWonAndUpdateText() {
		if (count >= 8) {
			winText.text = "You Win!";
		}
	}
}
