using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject projectile;
	public float jumpHeight = 200.0f;
	
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
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 100.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		
		if (z != 0.0f) {
			if (!footstepsAudio.isPlaying) {
				footstepsAudio.Play();
			}
		}
		else {
			footstepsAudio.Stop();
		}
		
		if (transform.position.y < -10.0f) {
			transform.position = new Vector3(initialPos.x, 5.0f, initialPos.z);
		}
		
		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl)) {
			Instantiate(projectile, transform.position, transform.rotation);
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isGrounded) {
				isGrounded = false;
				GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
			}
		}
		if (Input.GetKeyDown("t")) {
			GameObject.Find("DialogBox").GetComponent<DialogBox>().Hide();
		}
		if (Input.GetKeyDown("h")) {
			GameObject.Find("DialogBox").GetComponent<DialogBox>().Show();
		}
	}
	
	public void SetGrounded(bool grounded)
	{
		isGrounded = grounded;
	}	
}
