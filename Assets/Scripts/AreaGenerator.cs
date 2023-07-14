using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaGenerator : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inferior;
    public GameObject superior;
    public GameObject lateral;
    public GameObject instPortal;
    public float chunkSize;
    public float chunkSizeX = 250;
    public int chuncksPerArea = 10;
    public int chunckCount = 1;
    public float multiplier = 2;
    public Waves waves;
    public int actualRow = 0;
    public int altura;
    public bool waitingGeneration = true;

    public int chance = 100;
    public GameObject[] gameObjectsArray;

    public bool temp = false;

    private void Start()
    {
        chunkSize += transform.position.z / multiplier;

        CreateInferior();
        CreateSuperior();

        chunkSize += 250;

        //CreateInitialObstacles();
    }
    void Update()
    {
        if ((target.position.z + (3200 * multiplier) > chunkSize * multiplier) && waitingGeneration)
        {
            waitingGeneration = false;

            if (chunckCount <= chuncksPerArea)
            {
                StartCoroutine(CreateInferiorCoroutine());
                if (chunckCount < chuncksPerArea)
                    StartCoroutine(CreateObstacles());
                StartCoroutine(CreateSuperiorCoroutine());
            }

            if (chunckCount > chuncksPerArea)
            {
                InstantiatePortals();
                CreateInferior();
                CreateSuperior();

                chunkSize += 250;
                CreateInferior();
                CreateSuperior();

                chunkSize += 250;
                CreateInferior();
                CreateSuperior();

                Destroy(this.gameObject);
            }
        }
    }


    public virtual void CreateInferior()
    {
        
    }

    public virtual IEnumerator CreateInferiorCoroutine()
    {
        
        yield return new WaitForSeconds(.5f);
    }

    public virtual void CreateSuperior()
    {
        
    }

    public virtual IEnumerator CreateSuperiorCoroutine()
    {
        yield return new WaitForSeconds(.5f);

        chunkSize += 250;
        chunckCount++;
        waitingGeneration = true;
    }

    public virtual void InstantiatePortals()
    {
        
    }

    public virtual void CreateLaterals()
    {
        
    }

    public virtual IEnumerator CreateLateralsCoroutine()
    {
        yield return new WaitForSeconds(.5f);
    }

    public virtual void CreateInitialObstacles()
    {
        int[] selectedRow = new int[3];

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gi = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gd = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
    }

    public virtual IEnumerator CreateObstacles()
    {

        int[] selectedRow = new int[3];

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gi = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gd = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
    }

    public virtual void CreateEntrance()
    {

    }
}
