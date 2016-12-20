using UnityEngine;
using System.Collections;
using System;

public class SpawnController : MonoBehaviour {

    public GameObject spawnObject;
    public Vector3 spawnVelocity;
    public float interval;
    public Vector3 spawnPos;
        
    private float startTime;
    
	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;
        spawnPos.z = 1; //In case forgotten.
        spawnVelocity.z = 0; //In case forgotten.
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (Time.time - startTime > interval)
        {
            startTime = Time.time;
            SpawnObject();
        }
	}

    private void SpawnObject()
    {
        var spawned = Instantiate(spawnObject, spawnPos, Quaternion.identity) as GameObject;
        spawned.GetComponent<Rigidbody2D>().velocity = spawnVelocity;
    }
}
