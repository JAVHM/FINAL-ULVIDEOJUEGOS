using UnityEngine;

public class LGen : MonoBehaviour
{
    public Transform target; // Referencia al objeto "target"
    public GameObject inst;
    public float chunkSize;
    public float chunkSizeX = 250;
    public float multiplier = 2;
    int actualRow = 0;
    public int chance = 100;

    private void Start()
    {
        /*GameObject g = Instantiate(gameObjectsArray[0], new Vector3(0, 0, 0), Quaternion.identity);
        GameObject gi = Instantiate(gameObjectsArray[0], new Vector3(-chunkSizeX * multiplier, 0, 0), Quaternion.identity);
        GameObject gd = Instantiate(gameObjectsArray[0], new Vector3(chunkSizeX * multiplier, 0, 0), Quaternion.identity);*/
    }
    void Update()
    {
        if (target.position.z + (400 * multiplier) > chunkSize  * multiplier)
        {
            int[] selectedRow = new int[3];
            selectedRow = GenerateMap(actualRow);
            
            int rand = Random.Range(0, 100);

            if(rand < chance){
                GameObject g = Instantiate(gameObjectsArray[selectedRow[1]], new Vector3(chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
            }
            rand = Random.Range(0, 100);
            if(rand < chance){
                GameObject gi = Instantiate(gameObjectsArray[selectedRow[0]], new Vector3(-chunkSizeX * multiplier / 2, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
            }
            rand = Random.Range(0, 100);
            if(rand < chance){
                GameObject gd = Instantiate(gameObjectsArray[selectedRow[2]], new Vector3(chunkSizeX * multiplier * 1.5f, 0, chunkSize * multiplier + (chunkSizeX * multiplier / 2)), Quaternion.identity);
            }
            
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

    void InstantiateRow()
    {

    }
}