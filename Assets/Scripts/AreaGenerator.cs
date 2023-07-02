using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGenerator : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inferior;
    public GameObject superior;
    public GameObject instPortal;
    public float chunkSize;
    public float chunkSizeX = 250;
    public int chuncksPerArea = 10;
    public int chunckCount = 1;
    public float multiplier = 2;
    public Waves waves;
    public int actualRow = 0;
    public int altura = 1500;
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
        GameObject g = Instantiate(inferior, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;

        GameObject gi = Instantiate(inferior, new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gd = Instantiate(inferior, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;
    }

    private IEnumerator CreateInferiorCoroutine()
    {
        GameObject g = Instantiate(inferior, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;
        yield return new WaitForSeconds(.5f);

        GameObject gi = Instantiate(inferior, new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        GameObject gd = Instantiate(inferior, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);
    }

    public void CreateSuperior()
    {
        GameObject gU = Instantiate(superior, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;

        GameObject gUi = Instantiate(superior, new Vector3(-chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUi.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUi.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gUd = Instantiate(superior, new Vector3(chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUd.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUd.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUd.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
    }

    private IEnumerator CreateSuperiorCoroutine()
    {
        GameObject gU = Instantiate(superior, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;
        yield return new WaitForSeconds(.5f);

        GameObject gUi = Instantiate(superior, new Vector3(-chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUi.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUi.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        GameObject gUd = Instantiate(superior, new Vector3(chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUd.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUd.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUd.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        chunkSize += 250;
        chunckCount++;
        waitingGeneration = true;
    }

    public void InstantiatePortals()
    {
        GameObject g = Instantiate(instPortal, new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        GameObject gi = Instantiate(instPortal, new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        GameObject gd = Instantiate(instPortal, new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
    }

    public void CreateInitialObstacles()
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

    private IEnumerator CreateObstacles()
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
}
