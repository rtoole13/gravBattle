using UnityEngine;
using System.Collections;

public class gravWellController : MonoBehaviour {

    public float gravityRadius;
    public float gravityConstant;
    private Rigidbody2D myBody;

	// Use this for initialization
	void Start ()
    {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, gravityRadius);

        foreach (Collider2D collider in collisions)
        {
            Rigidbody2D otherBody = collider.GetComponent<Rigidbody2D>();
            if (otherBody == null || otherBody == myBody)
            {
                continue;
            }
            Vector3 distance = otherBody.transform.position - transform.position;
            if  (distance.sqrMagnitude > 0)
            {
                float force = -gravityConstant * otherBody.mass * myBody.mass / distance.sqrMagnitude;
                otherBody.AddForce(distance.normalized * force);
            }
        }
	}
}
