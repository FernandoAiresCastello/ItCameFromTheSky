using UnityEngine;

public class Player : MonoBehaviour
{
	public float moveSpeed = 2.0f;
	public float rotationSpeed = 100.0f;
	public float jumpHeight = 200.0f;
	public float fallLimit = -10.0f;
	public GameObject projectile;
	public Vector3 projectileOffset = new Vector3(0.0f, 0.25f, 0.0f);
	public int gold = 0;
	
	private Vector3 initialPos;
	private AudioSource footstepsAudio;
	private bool isGrounded = false;
	
	void Awake()
	{
		initialPos = transform.position;
	}
	
	void Start()
	{
        footstepsAudio = GetComponent<AudioSource>();
		footstepsAudio.loop = true;
        footstepsAudio.Stop();
	}
	
	void Update()
	{
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		bool walking = z != 0.0f;
		
		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		
		PlayFootsteps(walking);
		
		if (transform.position.y < fallLimit)
			Respawn();
		if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space))
			Jump();
		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
			Shoot();
	}
	
	void FixedUpdate()
	{
	}
	
	public void SetGrounded(bool grounded)
	{
		isGrounded = grounded;
	}
	
	void Jump()
	{
		if (isGrounded) {
			isGrounded = false;
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
		}
	}
	
	void Shoot()
	{
		GameObject p = Instantiate(projectile, transform.position + projectileOffset, transform.rotation);
		p.transform.localScale = this.transform.localScale;
		p.tag = "PlayerProjectile";
		SpriteRenderer sprite = p.GetComponent<SpriteRenderer>();
		sprite.color = this.GetComponent<SpriteRenderer>().color;
		
	}
	
	void Respawn()
	{
		transform.position = new Vector3(initialPos.x, 5.0f, initialPos.z);
	}
	
	void PlayFootsteps(bool play)
	{
		if (play && isGrounded) {
			if (!footstepsAudio.isPlaying)
				footstepsAudio.Play();
		}
		else
			footstepsAudio.Stop();
	}
}
