using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] private GameObject lastCreatedPlatform;
    
    
    float lastPlatformWidth;


 
    void Update()
    {
        //Create a new platform when the previous one reaches 0
        if(lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {
            float randomSpaceInBetweenPlatforms = Random.Range(2, 5);
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + randomSpaceInBetweenPlatforms, 0,0);
            int randomPlatform = Random.Range(0,platformPrefab.Length);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
