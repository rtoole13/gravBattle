using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float lifeTime;
    private float startTime;
	// Use this for initialization
	void Start ()
    {
        startTime = Time.time;    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Time.time - startTime > lifeTime)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);

        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<playerController>().SubtractHealth();
        }
    }

}
