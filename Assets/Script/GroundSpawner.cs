using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GroundSpawner : MonoBehaviour
{
    //Menampung referensi ground yang ingin di buat
    [SerializeField] private Ground groundRef;

    //Menampung ground sebelumnya
    private Ground prevGround;

    // method ini akan membuat ground game object baru
    private void SpawnGround()
    {
        if(prevGround != null)
        {
            // duplikasi ground
            Ground newGround = Instantiate(groundRef);

            // mengaktifkan game object
            newGround.gameObject.SetActive(true);

            // mendapatkan new ground dengan posisi nextground dari prevground
            // agar posisinya sejajar dengan ground sebelumnya
            prevGround.SetNextGround(newGround.gameObject);
        }
    }

    // method ini akan dipanggil ketika terdapat game object lain yang memiliki
    // komponen collider keluar dari area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // cari komponen ground dari object yang keluar dari area
        Ground ground = collision.GetComponent<Ground>();

        // cek apakah ground null
        if(ground)
        {
            // mengisi variabel prevGround
            prevGround = ground;

            // membuat ground baru
            SpawnGround();
        }
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
