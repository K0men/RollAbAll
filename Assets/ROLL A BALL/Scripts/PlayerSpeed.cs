using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostedSpeed = 10f;
    public float boostDuration = 3f; // durée en secondes

    private float currentSpeed;
    private bool isBoosted = false;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Exemple de mouvement simple
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        transform.Translate(move * currentSpeed * Time.deltaTime);
    }

    public void ActivateSpeedBoost()
    {
        if (!isBoosted)
        {
            StartCoroutine(SpeedBoostCoroutine());
        }
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        isBoosted = true;
        currentSpeed = boostedSpeed;

        yield return new WaitForSeconds(boostDuration);

        currentSpeed = normalSpeed;
        isBoosted = false;
    }
}
