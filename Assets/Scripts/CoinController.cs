using UnityEngine;

public class CoinController : MonoBehaviour {

    public float rotationSpeed = 100f;
    public int coinValue = 1; // Cuántos puntos da cada moneda

    void Update()
    {
        // Rotación de la moneda
        float angle = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * angle, Space.World);
    }

}