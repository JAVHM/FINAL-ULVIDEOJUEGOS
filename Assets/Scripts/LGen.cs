using System.Collections;
using UnityEngine;

public class LGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public float chunkSize;
    public float chunkSizeX = 250;
    public int chuncksPerArea = 10;
    public float multiplier = 2;
    int actualRow = 0;
    public int chance = 100;
    bool temp = true;

    private void Start()
    {
        /*GameObject g = Instantiate(gameObjectsArray[0], new Vector3(0, 0, 0), Quaternion.identity);
        GameObject gi = Instantiate(gameObjectsArray[0], new Vector3(-chunkSizeX * multiplier, 0, 0), Quaternion.identity);
        GameObject gd = Instantiate(gameObjectsArray[0], new Vector3(chunkSizeX * multiplier, 0, 0), Quaternion.identity);*/
        chunkSize += 250;
        CreateObstacles();
        chunkSize += 250;
    }
    void Update()
    {
        Debug.Log(chunkSize * multiplier);
        if ((target.position.z + (3200 * multiplier) > chunkSize * multiplier) && temp && chunkSize * multiplier <= 250 * multiplier * chuncksPerArea)
        {
            temp = false;
            StartCoroutine(CreateCoroutine());
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

        // Llenar la matriz con los valores correspondientes a los �ndices de los GameObjects
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

    public int[] GetRow(int rowSelected)
    {
        int columns = 10;
        // Retornar una fila aleatoria de la matriz
        int[] selectedRow = new int[columns];
        for (int col = 0; col < columns; col++)
        {
            selectedRow[col] = map[rowSelected, col];
        }

        return selectedRow;
    }

    public void CreateObstacles()
    {
        int[] selectedRow = new int[3];
        selectedRow = GenerateMap(actualRow);

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[selectedRow[1]], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gi = Instantiate(gameObjectsArray[selectedRow[0]], new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gd = Instantiate(gameObjectsArray[selectedRow[2]], new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
    }

    private IEnumerator CreateCoroutine()
    {
        
        int[] selectedRow = new int[3];
        selectedRow = GenerateMap(actualRow);

        int rand = Random.Range(0, 100);

        if (rand < chance)
        {
            GameObject g = Instantiate(gameObjectsArray[selectedRow[1]], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gi = Instantiate(gameObjectsArray[selectedRow[0]], new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
        rand = Random.Range(0, 100);
        if (rand < chance)
        {
            GameObject gd = Instantiate(gameObjectsArray[selectedRow[2]], new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);

        chunkSize += 250;
        temp = true;
    }
}
