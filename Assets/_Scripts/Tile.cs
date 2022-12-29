using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private List<Shapes> possiblesShapes = new List<Shapes>();

    void Start()
    {
        foreach (var shape in WaveFunctionCollapse.Instance.Shapes)
        {
            possiblesShapes.Add(Instantiate(shape,this.gameObject.transform));
        }
        UpdateTileVisual();
    }
    
    public void UpdateTileVisual()
    {
        if (possiblesShapes.Count == 1)
        {
            possiblesShapes[0].gameObject.transform.localPosition = Vector3.zero;
            possiblesShapes[0].gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            for (int i = 0; i < possiblesShapes.Count; i++)
            {
                possiblesShapes[i].gameObject.transform.localPosition =
                    new Vector3(-1 + 0.25f + 0.5f * (i % 4), 0, 1 - 0.25f - (i / 4) * 0.5f);
                possiblesShapes[i].gameObject.transform.localScale = Vector3.one*0.2f;
            }
        }
    }
}
