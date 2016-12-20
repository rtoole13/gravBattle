using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameObject spawnObject;
    public GameObject playerObject;

    private GameObject activeWell;
    private Vector3 playerDestination;
    private float startTime;
    private float journeyDistance;
    public float playerSpeed;
    
    // Use this for initialization
    void Start ()
    {
        playerDestination = playerObject.transform.position;
        journeyDistance = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 1;

            playerDestination = mousePos;
            startTime = Time.time;
            journeyDistance = Vector3.Distance(playerObject.transform.position, mousePos);
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

    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * playerSpeed;
        float fracJourney = distCovered / journeyDistance;
        playerObject.transform.position = Vector3.Lerp(playerObject.transform.position, playerDestination, fracJourney);
    }
}
