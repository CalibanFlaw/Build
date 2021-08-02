using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(0, 0);

    private Build[,] grid;
    private Build flying;
    private Camera mainCam;
    public bool building;

    private void Awake()
    {
        grid = new Build[GridSize.x, GridSize.y];
        mainCam = Camera.main;
    }
    public void StartBuild(Build buildPref)
    {
        if(flying != null)
        {
            Destroy(flying);
        }
        flying = Instantiate(buildPref);
        building = true;
    }

    private void Update()
    {
        if(flying != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if(groundPlane.Raycast(ray, out float position))
            {
                Vector3 WP = ray.GetPoint(position);
                int x = Mathf.RoundToInt(WP.x);
                int z = Mathf.RoundToInt(WP.z);

                bool gran = true;

                if (x < 0 || x > GridSize.x - flying.Size.x) gran = false;
                if (z < 0 || z > GridSize.y - flying.Size.y) gran = false;

                if (gran && PlaceTaken(x, z)) gran = false;

                flying.transform.position = new Vector3(x, 0, z);

                if (gran&&Input.GetMouseButtonDown(0))
                {
                    building = false;
                    Place(x, z);
                } 
            }
        }
    }

    private bool PlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flying.Size.x; x++)
        {
            for (int y = 0; y < flying.Size.y; y++)
            {
               if( grid[placeX + x, placeY + y]!= null) return true;
            }
        }
        return false;
    }

    private void Place(int placeX, int placeY)
    {
        for(int x = 0; x<flying.Size.x; x++)
        {
            for(int y = 0; y<flying.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flying;
            }
        }
        flying = null;
    }
}
