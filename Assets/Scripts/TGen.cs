using UnityEngine;

public class TGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public GameObject instSky;
    public float chunkSize;
    public float chunkSizeX = 250;
    public float multiplier = 2;
    public Waves waves;
    int actualRow = 0;
    public int altura = 1500;

    private void Start()
    {
        CreateInferior();
        CreateSuperior();
    }
    void Update()
    {
        if (target.position.z + (500 * multiplier) > chunkSize  * multiplier)
        {
            CreateInferior();

            CreateSuperior();

            chunkSize += 250;
        }
    }


    public void CreateInferior()
    {
        GameObject g = Instantiate(inst, new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
        g.transform.localScale = new Vector3(multiplier, 1, multiplier);
        g.GetComponent<Waves>().offSetY += (int)chunkSize;

        /*GameObject gi = Instantiate(inst, new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gi.GetComponent<Waves>().offSetY += (int)chunkSize;
        gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gd = Instantiate(inst, new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
        gd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gd.GetComponent<Waves>().offSetY += (int)chunkSize;
        gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;*/
    }

    public void CreateSuperior()
    {
        GameObject gU = Instantiate(instSky, new Vector3(0, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gU.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gU.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gU.GetComponent<Waves>().offSetY -= (int)chunkSize;

        /*GameObject gUi = Instantiate(instSky, new Vector3(-chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUi.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUi.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUi.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;

        GameObject gUd = Instantiate(inst, new Vector3(chunkSizeX * multiplier, altura, chunkSize * multiplier + chunkSizeX * multiplier), Quaternion.identity);
        gUd.transform.localScale = new Vector3(multiplier, 1, multiplier);
        gUd.transform.rotation = Quaternion.Euler(-180, 0, 0);
        gUd.GetComponent<Waves>().offSetY -= (int)chunkSize;
        gUd.GetComponent<Waves>().offSetX -= (int)chunkSizeX;*/
    }
}
