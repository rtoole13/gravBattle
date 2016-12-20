using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class playerController : MonoBehaviour {

    public int totalHealth;
    private int currentHealth;
	// Use this for initialization
	void Start ()
    {
        currentHealth = totalHealth;
	}
	
	// Update is called once per frame
	void Update () {
	    if(currentHealth < 1)
        {
            End();
        }
	}

    private void End()
    {
        Debug.Log("You died.");
        currentHealth = totalHealth;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SubtractHealth()
    {
        currentHealth -= 1;
        Debug.Log("Health Remaining: " + currentHealth);
    }
}
