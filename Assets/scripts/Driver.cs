using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
 [SerializeField]float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float speedBoost = 30f;
    [SerializeField] float reduceSpeed = 15f;
 
   
    void Update()
    {
        float steerAmount = Input.GetAxisRaw("Horizontal")*steerSpeed *Time.deltaTime;
        float steerVertical = Input.GetAxisRaw("Vertical") * moveSpeed *Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, steerVertical, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="SpeedUp" )
        {
            moveSpeed = speedBoost;
            Debug.Log("picked speed boost");
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = reduceSpeed;
    
        Debug.Log("picked slow ");
    }

}
