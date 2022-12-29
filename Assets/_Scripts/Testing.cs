using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField]private Shapes _shapesTested;
    // Start is called before the first frame update

    private List<GameObject> possibleW = new List<GameObject>();
    private List<GameObject> possibleN = new List<GameObject>();
    private List<GameObject> possibleE = new List<GameObject>();
    private List<GameObject> possibleS = new List<GameObject>();
    
    void Start()
    {
        Debug.Log(_shapesTested.PossibleNeighborsW.Count);
        Debug.Log(_shapesTested.PossibleNeighborsN.Count);
        Debug.Log(_shapesTested.PossibleNeighborsE.Count);
        Debug.Log(_shapesTested.PossibleNeighborsS.Count);
        
        ShowPossibilities(_shapesTested.PossibleNeighborsW,possibleW,new Vector3(-2, 0, 0),new Vector3(-0.5f, 0,0));
        ShowPossibilities(_shapesTested.PossibleNeighborsN,possibleN,new Vector3(0, 0, 2),new Vector3(0, 0, 0.5f));
        ShowPossibilities(_shapesTested.PossibleNeighborsE,possibleE,new Vector3(2, 0, 0),new Vector3(0.5f, 0, 0));
        ShowPossibilities(_shapesTested.PossibleNeighborsS,possibleS,new Vector3(0, 0, -2),new Vector3(0, 0, -0.5f));
    }

    public void ShowPossibilities(List<Shapes> possibleNeighbors,List<GameObject> listGameObjects, Vector3 basePosition, Vector3 offset)
    {
        foreach (var possibleNei in possibleNeighbors)
        {
            GameObject newShape = Instantiate(possibleNei, this.gameObject.transform).gameObject;
            listGameObjects.Add(newShape);
            newShape.transform.position = basePosition + ((listGameObjects.Count - 1) * offset);
            newShape.transform.localScale = Vector3.one*0.2f;
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
