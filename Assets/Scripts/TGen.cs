using UnityEngine;

public class TGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public float chunkSize;
    public float chunkSizeX = 250;
    public float multiplier = 2;
    public Waves waves;
    int actualRow = 0;

    private void Start()
    {

    }
    void Update()
    {
        if (target.position.z + (400 * multiplier) > chunkSize  * multiplier)
        {
            int[] selectedRow = new int[3];
            selectedRow = GenerateMap(actualRow);

            GameObject g = Instantiate(gameObjectsArray[selectedRow[1]], new Vector3(0, 0, chunkSize * multiplier), Quaternion.identity);
            g.GetComponent<Waves>().offSetY += (int)chunkSize;

            GameObject gi = Instantiate(gameObjectsArray[selectedRow[0]], new Vector3(-chunkSizeX * multiplier, 0, chunkSize * multiplier ), Quaternion.identity);
            gi.GetComponent<Waves>().offSetY += (int)chunkSize;
            gi.GetComponent<Waves>().offSetX -= (int)chunkSizeX;
            GameObject gd = Instantiate(gameObjectsArray[selectedRow[2]], new Vector3(chunkSizeX * multiplier, 0, chunkSize * multiplier), Quaternion.identity);
            gd.GetComponent<Waves>().offSetY += (int)chunkSize;
            gd.GetComponent<Waves>().offSetX += (int)chunkSizeX;

            /*GameObject gi2 = Instantiate(inst, transform.position + new Vector3(-chunkSizeX * multiplier * 2, 0, chunkSize * multiplier), Quaternion.identity);
            gi2.GetComponent<Waves>().offSetY += (int)chunkSize * 2;
            gi2.GetComponent<Waves>().offSetX -= (int)chunkSizeX * 2;
            GameObject gd2 = Instantiate(inst, transform.position + new Vector3(chunkSizeX * multiplier * 2 , 0, chunkSize * multiplier), Quaternion.identity);
            gd2.GetComponent<Waves>().offSetY += (int)chunkSize * 2;
            gd2.GetComponent<Waves>().offSetX += (int)chunkSizeX * 2;*/

            chunkSize += 250;
        }
    }
    public GameObject[] gameObjectsArray;
    public int[,] map;

    public int[] GenerateMap(int rowSelected)
    {
        int rows = 3;
        int columns = 10;

        map = new int[rows, columns];

        int totalObjects = gameObjectsArray.Length;

        // Llenar la matriz con los valores correspondientes a los índices de los GameObjects
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                int randomIndex = Random.Range(0, totalObjects);
                map[row, col] = randomIndex;
            }
        }

        // Retornar una fila aleatoria de la matriz
        int[] selectedRow = new int[columns];
        for (int col = 0; col < columns; col++)
        {
            selectedRow[col] = map[rowSelected, col];
        }

        return selectedRow;
    }

    void InstantiateRow()
    {

    }
}
