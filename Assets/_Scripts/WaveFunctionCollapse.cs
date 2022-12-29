using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveFunctionCollapse : MonoBehaviour
{
    public static WaveFunctionCollapse Instance { get; private set; }
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
                Debug.Log(shape.objectShape[0]+","+shape.objectShape[1]+","+shape.objectShape[2]+","+shape.objectShape[3]);
            }
        }

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
                return new Vector2(targetShape.objectShape[2], targetShape.objectShape[3]);
            default:
                throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
        }
    }
}
