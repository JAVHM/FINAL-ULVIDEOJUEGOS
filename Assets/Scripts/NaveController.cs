using UnityEngine;

public class NaveController : MonoBehaviour
{
    public float velocidadMovimientoX = 5f;
    public float velocidadMovimientoY = 5f;
    public float velocidadMovimientoZ = 5f; // Velocidad de movimiento de la nave
    public float velocidadMovimientoZMax = 100f;
    public float velocidadMovimientoYMax = 100f;
    public float velocidadMovimientoXMax = 100f;
    public float accelerationTime = 2f; // Tiempo de aceleración en segundos
    private float currentSpeedZ;
    private float currentSpeedY;
    private float currentSpeedX;// Velocidad actual de la nave
    private float timeElapsed; // Tiempo transcurrido desde que se presionó la tecla hacia arriba

    // Update se llama una vez por frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            currentSpeedZ = Mathf.SmoothStep(currentSpeedZ, velocidadMovimientoZMax, timeElapsed / accelerationTime);
            currentSpeedY = Mathf.SmoothStep(currentSpeedY, velocidadMovimientoYMax, timeElapsed / accelerationTime);
            currentSpeedX = Mathf.SmoothStep(currentSpeedX, velocidadMovimientoXMax, timeElapsed / accelerationTime);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            // Restablecer gradualmente la velocidad a la velocidad normal en 2 segundos
            currentSpeedZ = Mathf.SmoothStep(currentSpeedZ, velocidadMovimientoZ, timeElapsed / accelerationTime);
            currentSpeedY = Mathf.SmoothStep(currentSpeedY, velocidadMovimientoY, timeElapsed / accelerationTime);
            currentSpeedX = Mathf.SmoothStep(currentSpeedX, velocidadMovimientoX, timeElapsed / accelerationTime);
            timeElapsed += Time.deltaTime;
        }

        // Movimiento vertical con W y S
        float movimientoVertical = Input.GetAxis("Vertical") * currentSpeedY * Time.deltaTime;
        transform.Translate(Vector3.up * movimientoVertical);

        // Movimiento horizontal con A y D
        float movimientoHorizontal = Input.GetAxis("Horizontal") * currentSpeedX * Time.deltaTime;

        // Movimiento hacia adelante en el eje Z
        transform.Translate(Vector3.forward * currentSpeedZ * Time.deltaTime);

        transform.Translate(Vector3.right * movimientoHorizontal );
    }
}
