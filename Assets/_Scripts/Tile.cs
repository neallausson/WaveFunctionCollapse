using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public List<Shapes> PossiblesShapes = new List<Shapes>();

    void Start()
    {
        foreach (var shape in WaveFunctionCollapse.Instance.Shapes)
        {
            Shapes newShape = Instantiate(shape, this.gameObject.transform);
            newShape.OnClick.AddListener(() => SelectShape(new List<Shapes>() {newShape}));
            PossiblesShapes.Add(newShape);
        }
        UpdateTileVisual();
    }
    
    public void UpdateTileVisual()
    {
        if (PossiblesShapes.Count == 1)
        {
            PossiblesShapes[0].gameObject.transform.localPosition = Vector3.zero;
            PossiblesShapes[0].gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            for (int i = 0; i < PossiblesShapes.Count; i++)
            {
                PossiblesShapes[i].gameObject.transform.localPosition =
                    new Vector3(-1 + 0.25f + 0.5f * (i % 4), 0, 1 - 0.25f - (i / 4) * 0.5f);
                PossiblesShapes[i].gameObject.transform.localScale = Vector3.one*0.2f;
            }
        }
    }

    public void SelectShape(List<Shapes> shapeSelected)
    {
        int oldCount = PossiblesShapes.Count;
        for (int i = 0; i < PossiblesShapes.Count;)
        {
            if (!shapeSelected.Contains(PossiblesShapes[i]))
            {
                Destroy(PossiblesShapes[i].gameObject);
                PossiblesShapes.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        if (oldCount != PossiblesShapes.Count)
        {
            UpdateTileVisual();
            StartCoroutine(WaveFunctionCollapse.Instance.Map.Propagate(this));
        }
        
    }
}
