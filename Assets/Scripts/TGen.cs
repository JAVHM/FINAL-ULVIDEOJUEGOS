using UnityEngine;

public class TGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public float chunkSize;
    public float chunkSizeX = 250;
    public float multiplier = 2;
    public Waves waves;

    private void Start()
    {

    }
    void Update()
    {
        if (target.position.z + (400 * multiplier) > chunkSize  * multiplier)
        {
            GameObject g = Instantiate(inst, transform.position + new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
            g.GetComponent<Waves>().offSetY += (int)chunkSize;

            GameObject gi = Instantiate(inst, transform.position + new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier ), Quaternion.identity);
            gi.GetComponent<Waves>().offSetY += (int)chunkSize;
            gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
            GameObject gd = Instantiate(inst, transform.position + new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
            gd.GetComponent<Waves>().offSetY += (int)chunkSize;
            gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;

            chunkSize += 250;
        }
    }
}
