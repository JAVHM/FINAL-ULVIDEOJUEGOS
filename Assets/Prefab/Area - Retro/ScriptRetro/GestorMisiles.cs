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
        StartCoroutine(Probabilidades());
    }

    private IEnumerator Probabilidades()
    {
        for(int i = 0; i < 4; i++)
        {
            Instantiate(estrellaTeledirigida[i], puntoGeneracion[i].position, Quaternion.identity);
            yield return new WaitForSeconds(0.7f);
        }
    }

}
