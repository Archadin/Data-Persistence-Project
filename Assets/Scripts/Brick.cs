using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    
    public int PointValue;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1 :
                block.SetColor("_BaseColor", DataManager.instance.CurrentPalette.colors[2]);
                break;
            case 2:
                block.SetColor("_BaseColor", DataManager.instance.CurrentPalette.colors[1]);
                break;
            case 5:
                block.SetColor("_BaseColor", DataManager.instance.CurrentPalette.colors[0]);
                break;
            default:
                block.SetColor("_BaseColor", UnityEngine.Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);
        
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
