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
                newTile.gameObject.transform.localScale = Vector3.one*0.8f;
                newTile.gameObject.transform.localPosition = new Vector3(
                    -(sideLenght * Number_rows / 2) + i * sideLenght + sideLenght / 2, 0,
                    -(sideLenght * Number_rows / 2) + j * sideLenght + sideLenght / 2);
            }
        }
    }
    
    public void MakeAChoice()
    {
        int selectedPos = Random.Range(0, ListTiles.Count);
        for (int i = 0; i < ListTiles.Count; i++)
        {
            if (ListTiles[selectedPos].PossiblesShapes.Count == 1)
            {
                selectedPos = i;
            }
            else if (ListTiles[i].PossiblesShapes.Count < ListTiles[selectedPos].PossiblesShapes.Count && ListTiles[i].PossiblesShapes.Count!=1)
            {
                selectedPos = i;
            }
        }
        Debug.Log("Less entropy :" + ListTiles[selectedPos].PossiblesShapes.Count);
        ListTiles[selectedPos].SelectShape(new List<Shapes>() {ListTiles[selectedPos].PossiblesShapes[Random.Range(0,ListTiles[selectedPos].PossiblesShapes.Count)]});
    }

    public int MakeAChoiceReturnEntropy()
    {
        int selectedPos = Random.Range(0, ListTiles.Count);
        for (int i = 0; i < ListTiles.Count; i++)
        {
            if (ListTiles[selectedPos].PossiblesShapes.Count == 1)
            {
                selectedPos = i;
            }
            else if (ListTiles[i].PossiblesShapes.Count < ListTiles[selectedPos].PossiblesShapes.Count && ListTiles[i].PossiblesShapes.Count!=1)
            {
                selectedPos = i;
            }
        }

        int minEntropy = ListTiles[selectedPos].PossiblesShapes.Count;
        Debug.Log("Less entropy :" + minEntropy);
        ListTiles[selectedPos].SelectShape(new List<Shapes>() {ListTiles[selectedPos].PossiblesShapes[Random.Range(0,ListTiles[selectedPos].PossiblesShapes.Count)]});
        return minEntropy;
    }

    public void Resolve()
    {
        StartCoroutine(ResolveDelay());
    }

    public IEnumerator ResolveDelay()
    {
        int minEntropy = MakeAChoiceReturnEntropy();
        Debug.Log("MinEntropy : "+minEntropy);
        while (minEntropy != 1)
        {
            yield return new WaitForSeconds(0f);
            minEntropy = MakeAChoiceReturnEntropy();
            Debug.Log("MinEntropy : "+minEntropy);
        }
    }

    public void Propagate(Tile tile)
    {
        int pos = GetPos(tile);
        
        //West
        int westPos = pos - Number_rows;
        if (westPos>=0)
        {
            ListTiles[westPos].SelectShape(WaveFunctionCollapse.ReturnMatchingListShapes(
                tile.PossiblesShapes, 
                direction.West,
                ListTiles[westPos].PossiblesShapes));
        }
        //North
        int northPos = pos + 1;
        if (northPos<=Number_rows*Number_columns && (northPos)%Number_rows !=0)
        {
            ListTiles[northPos].SelectShape(WaveFunctionCollapse.ReturnMatchingListShapes(
                tile.PossiblesShapes, 
                direction.North,
                ListTiles[northPos].PossiblesShapes));
        }
        //East
        int eastPos = pos + Number_rows;
        if (eastPos<=Number_rows*Number_columns-1 )
        {
            ListTiles[eastPos].SelectShape(WaveFunctionCollapse.ReturnMatchingListShapes(
                tile.PossiblesShapes, 
                direction.East,
                ListTiles[eastPos].PossiblesShapes));
        }
        //South
        int southPos = pos - 1;
        if (southPos>=0 && (pos)%Number_rows !=0)
        {
            ListTiles[southPos].SelectShape(WaveFunctionCollapse.ReturnMatchingListShapes(
                tile.PossiblesShapes, 
                direction.South,
                ListTiles[southPos].PossiblesShapes));
        }
    }

    private int GetPos(Tile tile)
    {
        for (int i = 0; i < ListTiles.Count; i++)
        {
            if (tile == ListTiles[i])
            {
                return i;
            }
        }

        return 0;
    }

    
}
