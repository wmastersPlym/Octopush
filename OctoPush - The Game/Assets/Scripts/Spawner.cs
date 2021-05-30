using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float delay;

    public bool useRandVel;

    private void Start()
    {
        StartCoroutine(waitToSpawn());
    }

    IEnumerator waitToSpawn()
    {
        yield return new WaitForSeconds(delay);

        Spawn();

        StartCoroutine(waitToSpawn());
        
    }

    private void Spawn()
    {
        GameObject newObject = Instantiate(objectToSpawn);
        newObject.transform.position = gameObject.transform.position;

        if(useRandVel)
            newObject.GetComponent<Rigidbody2D>().velocity = getRandVel();

        newObject.transform.parent = this.transform;
    }

    private Vector3 getRandVel()
    {
        Random rand;
        return new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f));
    }
}
