using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalGenerator : AreaGenerator
{
    private void Start()
    {
        chunkSize += transform.position.z / multiplier;

        CreateInferior();
        CreateLaterals();
        CreateEntrance();
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
                StartCoroutine(CreateLateralsCoroutine());
                if (chunckCount < chuncksPerArea)
                    StartCoroutine(CreateObstacles());
                StartCoroutine(CreateSuperiorCoroutine());
            }

            if (chunckCount > chuncksPerArea)
            {
                InstantiatePortals();
                CreateInferior();
                CreateLaterals();
                CreateSuperior();

                chunkSize += 250;
                CreateInferior();
                CreateLaterals();
                CreateSuperior();

                chunkSize += 250;
                CreateInferior();
                CreateLaterals();
                CreateSuperior();

                Destroy(this.gameObject);
            }
        }
    }


    public void CreateInferior()
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
    }

    public void CreateLaterals()
    {
        GameObject gi = Instantiate(lateral, new Vector3(0, chunkSizeX * multiplier * 2, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier*2, 1, multiplier*2);
        gi.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gd = Instantiate(lateral, new Vector3(chunkSizeX * multiplier, -1000, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier*2, 1, multiplier*2);
        gd.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;

        /*GameObject gi1 = Instantiate(lateral, new Vector3(0, chunkSizeX * multiplier * 2, chunkSize * multiplier), Quaternion.identity);
        gi1.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        gi1.GetComponent<Waves>().offSetY += (int)chunkSize;*/
        //gi1.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        /*GameObject gd1 = Instantiate(lateral, new Vector3(chunkSizeX * multiplier, chunkSizeX * multiplier, chunkSize * multiplier), Quaternion.identity);
        gd1.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        gd1.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd1.GetComponent<Waves>().offSetX -= (int)chunkSizeX;*/
    }

    private IEnumerator CreateLateralsCoroutine()
    {
        GameObject gi = Instantiate(lateral, new Vector3(0, chunkSizeX * multiplier * 2, chunkSize * multiplier*2), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier*2, 1, multiplier*2);
        gi.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.3f);

        GameObject gd = Instantiate(lateral, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier*2), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier*2, 1, multiplier*2);
        gd.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;

        /*GameObject gi1 = Instantiate(lateral, new Vector3(0, chunkSizeX * multiplier * 2, chunkSize * multiplier), Quaternion.identity);
        gi1.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        gi1.GetComponent<Waves>().offSetY += (int)chunkSize;
        //gi1.GetComponent<Waves>().offSetX -= (int)chunkSizeX;*/
        //yield return new WaitForSeconds(.3f);

        /*GameObject gd1 = Instantiate(lateral, new Vector3(chunkSizeX * multiplier, chunkSizeX * multiplier, chunkSize * multiplier), Quaternion.identity);
        gd1.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        gd1.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd1.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.3f);*/
    }

    public void CreateSuperior()
    {
        GameObject gU = Instantiate(superior, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;
    }

    private IEnumerator CreateSuperiorCoroutine()
    {
        GameObject gU = Instantiate(superior, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;
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
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier / 2, chunkSizeX * multiplier , chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
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
            GameObject g = Instantiate(gameObjectsArray[Random.Range(0, gameObjectsArray.Length)], new Vector3(chunkSizeX * multiplier / 2, chunkSizeX * multiplier , chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
    }

    public virtual void CreateEntrance()
    {
        GameObject gi = Instantiate(lateral, new Vector3(-chunkSizeX * multiplier * 2, chunkSizeX * multiplier * 2, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier * 2, 1, multiplier * 2);
        gi.transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gd = Instantiate(lateral, new Vector3(chunkSizeX * multiplier * 3, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier * 2, 1, multiplier * 2);
        gd.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 90));
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;
    }
}