using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

		public float speed = 6.0F;
		public float jumpSpeed = 2.0F; 
		public float gravity = 2.5F;
		private Vector3 moveDirection = Vector3.zero;

	public GameObject Spawn;
	public bool Dead = true;
	public int DeathCounter = -1;

	public bool Powered = true;
	public int Jump_Counter = 0;
	public float cooldown = 5f;
	public float defaultcool = 5f;
	public float delay = 1f;

	public float Thrust = 3f;
	public CharacterController controller;

	public float CamRotSpeed = 3f;

	public bool jumping = false;

	public CharacterController CharCtrl;

	public Animator anim;

	public AudioSource source;
	public AudioClip Jumpfx, PowerUpfx, PowerDownfx, Magnetfx, Buttonfx, Powerfx, Doorfx; 

	void Start()
	{

		CharCtrl = GetComponent<CharacterController>();

	}

	void Update() {
		cooldown -= Time.deltaTime;
		delay -= Time.deltaTime;
		if (cooldown < 0f)
			Jump_Counter = 0;
		if (controller.isGrounded && delay < 0f) {
			jumping = false;
			anim.SetBool ("Jumping", false);
		}
		//float mouseInputX = Input.GetAxis ("Mouse X");
		//float mouseInputY = Input.GetAxis ("Mouse Y");
		//Vector3 Look = new Vector3 (0, mouseInputX, 0);
		//transform.Rotate (Look * CamRotSpeed);

		//if(Input.GetKeyDown("escape")
				//Application.Quit();
			
	}

	void FixedUpdate()
	{
		if (!Dead) {
			

			if (controller.isGrounded || jumping) {
				
//				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
//				moveDirection = transform.TransformDirection (moveDirection);
//
//				moveDirection *= speed;

				Vector3 NextDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
				if (NextDir != Vector3.zero) {
					transform.rotation = Quaternion.LookRotation (NextDir);
					anim.SetFloat("Speed", 0.2f);
				} else
					anim.SetFloat("Speed", 0f);
				CharCtrl.Move(NextDir * speed);


			}

			if (Input.GetButton ("Jump") && delay < 0) {
				delay = 0.5f;
				jumping = true;
				source.clip = Jumpfx;
				source.Play ();
				anim.SetBool ("Jumping", true);
				Debug.Log ("Pressed Jump");

				if (Powered && Jump_Counter >= 0 && Jump_Counter <= 1) {

					Debug.Log ("Call Jumping");

					moveDirection.y = jumpSpeed;
					Jump_Counter++;
					cooldown = defaultcool;
				} else if (!Powered && controller.isGrounded || Jump_Counter <= 1) {
					
					moveDirection.y = jumpSpeed;
					Jump_Counter++;
					cooldown = defaultcool;
				}

			}
			//Applying gravity to the controller
			moveDirection.y -= gravity * Time.deltaTime;
			//Making the character move
			controller.Move (moveDirection * Time.deltaTime);
		} 
		else
			Respawn ();
	}

	public void Respawn() 
	{
		DeathCounter++;
		this.transform.position = Spawn.transform.position;
		Dead = false;
	}


}



