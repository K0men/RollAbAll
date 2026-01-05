using UnityEngine;

public class DestroySound : MonoBehaviour
{
    public AudioClip destroyClip;
    public float volume = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(
                destroyClip,
                transform.position,
                volume
            );

            Destroy(gameObject);
        }
    }
}
