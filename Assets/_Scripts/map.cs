using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public int Number_columns;
    public int Number_rows;

    private int sideLenght = 2;

    [SerializeField] private Tile PrefabTile;

    private List<Tile> ListTiles = new List<Tile>();
    void Start()
    {
        instanceTile();
    }

    private void instanceTile()
    {
        for (int i = 0; i < Number_rows; i++)
        {
            for (int j = 0; j < Number_columns; j++)
            {
                Tile newTile = Instantiate(PrefabTile, this.gameObject.transform);
                ListTiles.Add(newTile);
                newTile.gameObject.transform.localPosition = new Vector3(
                    -(sideLenght * Number_rows / 2) + i * sideLenght + sideLenght / 2, 0,
                    -(sideLenght * Number_rows / 2) + j * sideLenght + sideLenght / 2);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
