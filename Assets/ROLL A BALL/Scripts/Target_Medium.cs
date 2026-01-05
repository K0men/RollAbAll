using UnityEngine;

public class Target_Medium : MonoBehaviour
{
    [SerializeField] private int _targertValue = 1;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player_Collect>() != null)
        {
            other.gameObject.GetComponent<Player_Collect>().UpdateScore(_targertValue);
            Destroy(gameObject);
        }
    }
}