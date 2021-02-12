using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixToParent : MonoBehaviour
{
    public float initRotationZ;
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
        Quaternion targetRotation = parent.rotation;
        targetRotation.Set(targetRotation.x, targetRotation.y, targetRotation.z - 90f, targetRotation.w); //+= initRotationZ;
        //targetRotation.z -= 90;
        transform.rotation = targetRotation;
    }
}
