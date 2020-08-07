using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    // global variabel
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // melakukan pengecekan jika butung null atau mati
        if(bird == null || (bird != null && !bird.IsDead()))
        {
            // membuat pipa bergerak ke sebah kiri dengan kecepatan dari variabel speed
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    // method untuk menempatakan game objek pada posisi next ground
    public void SetNextGround(GameObject ground)
    {
        if(ground != null)
        {
            // menempatkan ground berikutnya pada posisi next ground
            ground.transform.position = nextPost.position;
        }
    }

    // Dipanggil ketika game object bersentuhan dengan game object yang lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Membuat burung mati ketika bersentuhan dengan game object ini
        if(bird != null && !bird.IsDead())
        {
            bird.Dead();
        }
    }
}
