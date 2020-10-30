using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixToParent : MonoBehaviour
{

    private Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.position;
    }
}
