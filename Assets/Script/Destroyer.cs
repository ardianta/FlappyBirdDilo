using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // hapus game objek saat bersentuhan
        Destroy(collider.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
