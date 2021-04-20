using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float submergedOpacity;
    public float floatingOpacity;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void submerge()
    {
        setOpacity(submergedOpacity);
        sr.sortingLayerName = "Forground";
    }

    public void surface()
    {
        setOpacity(floatingOpacity);
        sr.sortingLayerName = "BelowPlayer";
    }


    private void setOpacity(float a)
    {
        Color color = sr.color;
        color.a = a;
        sr.color = color;
    }
}
