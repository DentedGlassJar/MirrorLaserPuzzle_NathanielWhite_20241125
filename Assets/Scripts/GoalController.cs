using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public GameObject goalObj;
    int goalHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        goalHealth = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Health: {goalHealth}");
        if (goalHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("GoalTag"))
        {
            goalHealth =- 1;
        }
    }
}
