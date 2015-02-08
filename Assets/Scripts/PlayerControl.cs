using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	public float speed = 4.3f; // dabartinis greitis
	public Sprite broken;
    public Sprite isskleista;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame // Fixed kad tai vyksta ne kiekvienam frame, pries tai apskaiciuoja, daugiau naudoja resursu //delta time yra ivykes pries praeita frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			this.gameObject.transform.Translate (Vector3.left * Time.deltaTime * speed);												
		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			this.gameObject.transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
	
	}



	
		
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Green") {
			this.gameObject.rigidbody2D.AddForce (new Vector2 (0, 150));

		} else if (other.gameObject.tag == "Red") {
			this.gameObject.rigidbody2D.AddForce (new Vector2 (0, 100));
			other.gameObject.GetComponent<SpriteRenderer> ().sprite = broken;
			other.gameObject.rigidbody2D.isKinematic = false;

		} else if (other.gameObject.tag == "White") {
			Destroy(other.gameObject);
		} else if (other.gameObject.tag == "Spring"){

			this.gameObject.rigidbody2D.AddForce(new Vector2 (0, 250));
            other.gameObject.GetComponent<SpriteRenderer>().sprite = isskleista;
               
	}
}
}

