using UnityEngine;

public class PlayerBase : MonoBehaviour
{
	void OnTriggerEnter()
	{
		PlayerController player = transform.parent.gameObject.GetComponent<PlayerController>();
		player.SetGrounded(true);
	}
}
