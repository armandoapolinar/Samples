using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackdroScroll : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderers;
    [SerializeField] float speed = 1;
     float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderers.GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        offset += Time.deltaTime * speed;
        renderers.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
