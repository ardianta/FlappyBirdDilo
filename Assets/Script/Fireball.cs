using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Fireball : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    [SerializeField] private float fireSpeed = 10f;

    [SerializeField] private Sparks sparks;

    [SerializeField] private UnityEvent OnFire;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Fire()
    {
        gameObject.SetActive(true);
        OnFire.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pipe pipe = collision.gameObject.GetComponent<Pipe>();
        if (pipe != null)
        {   
            Debug.Log("Fireball: Collision with Pipe");
            Sparks newSpark = Instantiate(sparks, transform.position, Quaternion.identity);
            newSpark.ShowSparks();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * fireSpeed * Time.deltaTime, Space.World);
    }
}
