using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PortalNewArea : MonoBehaviour
{
    public GameObject generator;
    bool canInst = true;

    public Transform target; // Objeto de referencia para calcular la distancia
    public Color colorOG; // Color cuando la distancia es 0
    public Color colorMayor500; // Color cuando la distancia es mayor a 500 en el eje Z


    private void Update()
    {
        if (target != null)
        {
            // Calcula la distancia entre los dos objetos
            float distancia = Vector3.Distance(transform.position, target.position);

            // Calcula el valor de interpolación para la transición gradual
            float interpolacion = Mathf.Clamp01(distancia / (750 * 30));

            // Realiza la mezcla de colores utilizando la interpolación
            Color colorMezclado = Color.Lerp(colorOG, colorMayor500, interpolacion);

            Camera.main.gameObject.GetComponent<Fog>().fogColor = colorMezclado;

            if (distancia > (750 * 30) + 1)
            {
                StartCoroutine(ChangeColorCoroutine());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canInst)
        {
            canInst = false;
            // Obtener la posición del objeto padre
            Vector3 spawnPosition = transform.position;

            // Hacer algo cuando el objeto "Player" toque el objeto "Plane"
            //Debug.Log("¡El jugador ha tocado el plano! " + spawnPosition);

            // Instanciar el objeto y asignarle la posición del objeto padre
            GameObject newObject = Instantiate(generator, new Vector3(spawnPosition.x, spawnPosition.y,spawnPosition.z + 750 * 30), Quaternion.identity);

            if (newObject.GetComponent<CloacaGenerator>() != null)
            {
                newObject.GetComponent<CloacaGenerator>().target = other.gameObject.transform;
            }
            else if (newObject.GetComponent<HorizontalGenerator>() != null)
            {
                HorizontalGenerator hg  = newObject.GetComponent<HorizontalGenerator>();
                hg.target = other.gameObject.transform;
                other.transform.parent.
                gameObject.GetComponent<Delimitator>().
                UpdateLimits(new Vector2(- hg.chunkSizeX * hg.multiplier, hg.chunkSizeX * hg.multiplier * 2), new Vector2(0, hg.altura), hg.chunkSizeX * hg.multiplier * 3);
                other.transform.parent.gameObject.GetComponent<Delimitator>().needChange = true;
            }
            else if (newObject.GetComponent<VerticalGenerator>() != null)
            {
                newObject.GetComponent<VerticalGenerator>().target = other.gameObject.transform;
            }

            //newObject.GetComponent<AreaGenerator>().target = other.gameObject.transform;
            target = other.gameObject.transform;
            colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor;
        }
    }

    private IEnumerator ChangeColorCoroutine()
    {
        float elapsedTime = 0f;

        Color initial = Camera.main.gameObject.GetComponent<Fog>().fogColor;
        Color currentColor = initial;

        while (elapsedTime < 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 2;

            // Interpolate the color between startColor and targetColor
            currentColor = Color.Lerp(initial, colorMayor500, t);

            // Apply the color to the object
            colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor = currentColor;

            yield return null;
        }

        // Ensure the final color is exactly the targetColor
        colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor = colorMayor500;
        Destroy(this.gameObject);
    }
}
