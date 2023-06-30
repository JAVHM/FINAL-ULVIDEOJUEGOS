using System.Collections;
using UnityEngine;

public class TGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public GameObject instSky;
    public GameObject instPortal;
    public float chunkSize;
    public float chunkSizeX = 250;
    public int chuncksPerArea = 10;
    public float multiplier = 2;
    public Waves waves;
    int actualRow = 0;
    public int altura = 1500;
    bool waitingGeneration = true;

    bool  temp = false;

    private void Start()
    {
        CreateInferior();
        CreateSuperior();

        chunkSize += 250;
        CreateInferior();
        CreateSuperior();
    }
    void Update()
    {
        if ((target.position.z + (3200 * multiplier) > chunkSize * multiplier) && waitingGeneration && chunkSize * multiplier <= 250 * multiplier * (chuncksPerArea + 3))
        {
            waitingGeneration = false;
            StartCoroutine(CreateInferiorCoroutine());

            StartCoroutine(CreateSuperiorCoroutine());

            if(chunkSize * multiplier >= 250 * multiplier * (chuncksPerArea + 3))
            {
                InstantiatePortals();
                chunkSize += 250;
                CreateInferior();
                CreateSuperior();

                chunkSize += 250;
                CreateInferior();
                CreateSuperior();
            }
        }
    }


    public void CreateInferior()
    {
        GameObject g = Instantiate(inst, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;

        GameObject gi = Instantiate(inst, new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gd = Instantiate(inst, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;
    }

    private IEnumerator CreateInferiorCoroutine()
    {
        GameObject g = Instantiate(inst, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;
        yield return new WaitForSeconds(.5f);

        GameObject gi = Instantiate(inst, new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        GameObject gd = Instantiate(inst, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);
    }

    public void CreateSuperior()
    {
        GameObject gU = Instantiate(instSky, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;

        GameObject gUi = Instantiate(instSky, new Vector3(-chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUi.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUi.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gUd = Instantiate(instSky, new Vector3(chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUd.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUd.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUd.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
    }

    private IEnumerator CreateSuperiorCoroutine()
    {
        GameObject gU = Instantiate(instSky, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;
        yield return new WaitForSeconds(.5f);

        GameObject gUi = Instantiate(instSky, new Vector3(-chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUi.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUi.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        GameObject gUd = Instantiate(instSky, new Vector3(chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUd.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUd.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUd.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
        yield return new WaitForSeconds(.5f);

        chunkSize += 250;
        waitingGeneration = true;
    }

    public void InstantiatePortals()
    {
        GameObject g = Instantiate(instPortal, new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        GameObject gi = Instantiate(instPortal, new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        GameObject gd = Instantiate(instPortal, new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
    }
}
