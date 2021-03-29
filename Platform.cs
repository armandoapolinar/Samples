using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] public float speed = 1;

    float leftLimit = -50;
    

    
    void Update()
    {
        transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        if(transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
    }
}
