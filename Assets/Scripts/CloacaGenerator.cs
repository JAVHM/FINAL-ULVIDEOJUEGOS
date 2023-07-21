using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloacaGenerator : AreaGenerator
{
    public GameObject Entrance;

    private void Start()
    {
        chunkSize += transform.position.z / multiplier;

        CreateEntrance();

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
            }

            if (chunckCount > chuncksPerArea)
            {
                InstantiatePortals();
                CreateInferior();

                chunkSize += 250;
                CreateInferior();

                chunkSize += 250;
                CreateInferior();

                Destroy(this.gameObject);
            }
        }
    }


    public override void CreateInferior()
    {
        GameObject g = Instantiate(inferior, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;
    }

    public override IEnumerator CreateInferiorCoroutine()
    {
        GameObject g = Instantiate(inferior, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;
        yield return new WaitForSeconds(.5f);

        chunkSize += 250;
        chunckCount++;
        waitingGeneration = true;
    }


    public override void InstantiatePortals()
    {
        GameObject g = Instantiate(instPortal, new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
    }

    public override void CreateInitialObstacles()
    {
        int[] selectedRow = new int[3];

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
    }

    public override IEnumerator CreateObstacles()
    {

        int[] selectedRow = new int[3];

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
            //g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        }
        yield return new WaitForSeconds(.5f);
    }

    public override void CreateEntrance()
    {
        GameObject g = Instantiate(Entrance, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;
    }

    public override IEnumerator CreateEndCoroutine()
    {
        InstantiatePortals();
        yield return new WaitForSeconds(.4f);
        CreateInferior(); yield return new WaitForSeconds(.4f);
        CreateLaterals(); yield return new WaitForSeconds(.4f);

        chunkSize += 250;
        CreateInferior(); yield return new WaitForSeconds(.4f);
        CreateLaterals(); yield return new WaitForSeconds(.4f);

        chunkSize += 250;
        CreateInferior(); yield return new WaitForSeconds(.4f);
        CreateLaterals(); yield return new WaitForSeconds(.4f);

        Destroy(this.gameObject);
    }
}
