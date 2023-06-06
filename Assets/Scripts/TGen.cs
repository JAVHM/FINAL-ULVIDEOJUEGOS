using UnityEngine;

public class TGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public float chunkSize;
    public Waves waves;

    private void Start()
    {

    }
    void Update()
    {
        if (target.position.z > chunkSize - 300)
        {
            GameObject g = Instantiate(inst, transform.position + new Vector3(0, 0, chunkSize), Quaternion.identity);
            g.GetComponent<Waves>().offSetY += (int)chunkSize; ;
            chunkSize += 250;
            Debug.Log("Next Chunk | " + chunkSize); 
        }
    }
}
