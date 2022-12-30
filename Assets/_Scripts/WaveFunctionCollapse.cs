using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunctionCollapse : MonoBehaviour
{
    public static WaveFunctionCollapse Instance { get; private set; }

    [SerializeField] public map Map;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    [SerializeField] public List<Shapes> Shapes;

    public static List<Shapes> ReturnMatchingShapes(Shapes targetShape, direction dir, List<Shapes> allShapes)
    {
        List<Shapes> matchingShapes = new List<Shapes>();

        Vector2 targetSide = GetSide(targetShape, dir);

        direction dirneighbors = (direction)(((int) dir + 2) % 4);

        Debug.Log(dir);
        foreach (var shape in allShapes)
        {
            if (targetSide == GetSide(shape,dirneighbors))
            {
                matchingShapes.Add(shape);
            }
        }
        Debug.Log(matchingShapes.Count);
        return matchingShapes;
    }
    
    public static List<Shapes> ReturnMatchingListShapes(List<Shapes> targetShapes, direction dir, List<Shapes> allShapes)
    {
        List<Shapes> matchingShapes = new List<Shapes>();

        foreach (var shape in targetShapes)
        {
            List<Shapes> res = ReturnMatchingShapes(shape, dir, allShapes);
            foreach (var resShape in res)
            {
                if (!matchingShapes.Contains(resShape))
                {
                    matchingShapes.Add(resShape);
                }
            }
        }
        
        Debug.Log(matchingShapes.Count);
        return matchingShapes;
    }

    public static Vector2 GetSide(Shapes targetShape, direction dir)
    {
        switch (dir)
        {
            case direction.West:
                return new Vector2(targetShape.objectShape[0], targetShape.objectShape[3]);
            case direction.North:
                return new Vector2(targetShape.objectShape[0], targetShape.objectShape[1]);
            case direction.East:
                return new Vector2(targetShape.objectShape[1], targetShape.objectShape[2]);
            case direction.South:
                return new Vector2(targetShape.objectShape[3], targetShape.objectShape[2]);
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }
    }
}
