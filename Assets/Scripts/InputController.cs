using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameObject spawnObject;
    public GameObject playerObject;
    private CircleCollider2D spawnCollider;

    private GameObject activeWell;
    private Vector3 playerDestination;
    private float startTime;
    private float journeyDistance;
    // Use this for initialization
    void Start ()
    {
        spawnCollider = spawnObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1;
            startTime = Time.time;
            journeyDistance = Vector3.Distance(playerObject.transform.position, mousePos);

            playerObject.transform.position = Vector3.Lerp(playerObject.transform.position, mousePos, Time.deltaTime);
            
        }
	    if (Input.GetMouseButtonUp(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1;
            
            if (activeWell == null)
            {
                activeWell = Instantiate(spawnObject, mousePos, Quaternion.identity) as GameObject;
            }
            else
            {
                activeWell.transform.position = mousePos;
            }   
        }
	}
    private bool CollidesWithSpawnObject(Vector3 pos, float radius)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(pos, radius);
        if (collisions.Length > 0)
        {
            foreach (Collider2D collision in collisions)
            {
                if (collision.gameObject.CompareTag(spawnObject.tag))
                {
                    Destroy(collision.gameObject);
                }
            }
            return true;
        }
        return false;
    }
}
