using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpole : MonoBehaviour
{
    public GameObject cell;
    public int width = 10;
    public int hight = 10;
    public float cellSize = 1f;
    [SerializeField]
   

    public Transform Pole;
   
    private GameObject[,] grid = new GameObject[100, 100];

    void Awake()
    {
      

        float xPos = 0;
        for (int x = 0; x < width; x++)
        {
            float yPos = 0;
            for (int y = 0; y < hight; y++)
            {
                GameObject spriteGrid = (GameObject)Instantiate(cell);
                spriteGrid.transform.SetParent(Pole, false);
                spriteGrid.transform.position = new Vector3(spriteGrid.transform.position.x + xPos, 0,spriteGrid.transform.position.z + yPos);
                Debug.Log("Pos:" + xPos + ";" + yPos);
                grid[x, y] = spriteGrid;
                Debug.Log("Cell" + x + ";" + y);

                yPos += cellSize;
                yPos = Mathf.Round(yPos / cellSize) * cellSize;
            }
            xPos += cellSize;
            xPos = Mathf.Round(xPos / cellSize) * cellSize;
        }
    }

  

}
