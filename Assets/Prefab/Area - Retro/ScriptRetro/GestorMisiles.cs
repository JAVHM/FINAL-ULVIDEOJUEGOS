using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GestorMisiles : MonoBehaviour
{
    [SerializeField] private Transform[] puntoGeneracion;
    [SerializeField] private GameObject[] estrellaTeledirigida;
    // Start is called before the first frame update
    void Start()
    {
        Probabilidades();
    }

    private void Probabilidades()
    {
        Instantiate(estrellaTeledirigida[Random.Range(0, puntoGeneracion.Length)], 
            puntoGeneracion[Random.Range(0, puntoGeneracion.Length)].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
