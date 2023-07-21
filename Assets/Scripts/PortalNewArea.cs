using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class PortalNewArea : MonoBehaviour
{
    public GameObject generator;
    bool canInst = true;

    public Transform target; // Objeto de referencia para calcular la distancia
    public Color colorOG; // Color cuando la distancia es 0

    public Light dls;
    public Light dli;
    public Color dlsColor;
    public Color dliColor;

    public AreaSO areaSO;
    public GameObject Boss1;

    private void Start()
    {
        //target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcula la distancia entre los dos objetos
            float distancia = Vector3.Distance(transform.position, target.position);

            // Calcula el valor de interpolación para la transición gradual
            float interpolacion = Mathf.Clamp01(distancia / (750 * 30));

            // Realiza la mezcla de colores utilizando la interpolación
            Color colorMezclado = Color.Lerp(colorOG, areaSO.fogColor, interpolacion);

            Color colorMezcladoDLS = Color.Lerp(dlsColor, areaSO.superiorColor, interpolacion);
            Color colorMezcladoDLI = Color.Lerp(dliColor, areaSO.inferiorColor, interpolacion);

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

            // Instanciar el objeto y asignarle la posición del objeto padre
            GameObject newObject = Instantiate(generator, new Vector3(spawnPosition.x, spawnPosition.y,spawnPosition.z + 750 * 30), Quaternion.identity);

            AreaGenerator a = newObject.GetComponent<AreaGenerator>();
            a.target = other.gameObject.transform;
            other.transform.parent.
            gameObject.GetComponent<Delimitator>().
            UpdateLimits(new Vector2(-a.chunkSizeX * a.multiplier, a.chunkSizeX * a.multiplier * 2), new Vector2(0, a.altura), a.chunkSizeX * a.multiplier * 3);
            other.transform.parent.gameObject.GetComponent<Delimitator>().needChange = true;

            //newObject.GetComponent<AreaGenerator>().target = other.gameObject.transform;
            target = other.gameObject.transform;
            colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor;

            if (Boss1 != null)
            {
                GameObject boss = Instantiate(Boss1, new Vector3(4000, 750, target.position.z + 2000), Quaternion.identity);
                boss.GetComponent<BossMovement>().target = target;
                boss.GetComponentInChildren<EyeFollow>().target = target;
            }
        }
    }

    private IEnumerator ChangeColorCoroutine()
    {
        AudioManager.instance.updateBGMusic(areaSO.nombrecancion);
        AudioManager.instance.Play(areaSO.dialogo);
        if (areaSO.hasFog == false)
        {
            Camera.main.gameObject.GetComponent<Fog>().enabled = false;
        }
        else
        {
            Camera.main.gameObject.GetComponent<Fog>().enabled = true;
        }
        float elapsedTime = 0f;

        dls = GameObject.Find("SuperiorDL").GetComponent<Light>();
        dli = GameObject.Find("InferiorDL").GetComponent<Light>();

        Color initial = Camera.main.gameObject.GetComponent<Fog>().fogColor;
        Color currentColor = initial;

        Color initialDLS = dls.color;
        Color currentColorDLS = initialDLS;

        Color initialDLI = dli.color;
        Color currentColorDLI = initialDLI;

        while (elapsedTime < 2)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / 2;

            // Interpolate the color between startColor and targetColor
            currentColor = Color.Lerp(initial, areaSO.fogColor, t);
            currentColor = Color.Lerp(initial, areaSO.fogColor, t);

            // Apply the color to the object
            colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor = currentColor;

            // Interpolate the color between startColor and targetColor
            currentColorDLS = Color.Lerp(initialDLS, areaSO.superiorColor, t);
            currentColorDLS = Color.Lerp(initialDLS, areaSO.superiorColor, t);

            // Apply the color to the object
            dlsColor = dls.color = currentColorDLS;

            // Interpolate the color between startColor and targetColor
            currentColorDLI = Color.Lerp(initialDLI, areaSO.inferiorColor, t);
            currentColorDLI = Color.Lerp(initialDLI, areaSO.inferiorColor, t);

            // Apply the color to the object
            dliColor = dli.color = currentColorDLI;

            yield return null;
        }

        // Ensure the final color is exactly the targetColor
        colorOG = Camera.main.gameObject.GetComponent<Fog>().fogColor = areaSO.fogColor;
        dlsColor = dls.color = areaSO.superiorColor;
        dliColor = dli.color = areaSO.inferiorColor;        
        Destroy(this.gameObject);
    }
}
