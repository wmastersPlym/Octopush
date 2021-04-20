using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyStickController : MonoBehaviour
{

    public GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = playerBody.transform.rotation;
        transform.eulerAngles += new Vector3(0, 0, 180f);
    }
}
