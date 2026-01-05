using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.ActivateSpeedBoost();
            }

            Destroy(gameObject);
        }
    }
}
