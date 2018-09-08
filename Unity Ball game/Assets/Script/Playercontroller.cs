using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Playercontroller : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText; 
	public Text winText;
	public Slider healthBar;
	public float MaxHealth = 100;
	public Text lose;
	public Transform HealthBar;

	private float currentHealth;
	private float HBOffset = 2; 

	void Start() {

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		lose.text = "";
		currentHealth = MaxHealth;
		healthBar.value = currentHealth / MaxHealth;
	}

	void Update()
	{
		PositionHealthBar ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);


	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick up"))
			{
				other.gameObject.SetActive(false);
			    count += 1;
			    currentHealth += 10;
				healthBar.value = currentHealth / MaxHealth;
			    SetCountText ();
			}

	}
	void SetCountText    ()
	{
		countText.text = "Score: " + count.ToString ();
		if (count == 14) {
			winText.text = "YOU WON!!!";
			Destroy (gameObject);
		}
	}

	public void Damage(float amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp (currentHealth, 0, MaxHealth);

		healthBar.value = currentHealth / MaxHealth;

		if(currentHealth==0)
		{
			lose.text = "YOU LOST!!!";
			Destroy (gameObject);
		}
	}

	void PositionHealthBar()
	{
		Vector3 currentposition = transform.position;

		HealthBar.position = new Vector3 (currentposition.x, currentposition.y + HBOffset, currentposition.z);
		HealthBar.LookAt (Camera.main.transform);
	}
}


