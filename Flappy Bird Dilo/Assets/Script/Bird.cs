using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{

    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    private Rigidbody2D rigidbody2d;
    private Animator animator;

    [SerializeField] private int score;
    [SerializeField] private Text scoreText;
    [SerializeField] private UnityEvent OnAddPoint;

    [SerializeField] private Fireball fireball;

     [SerializeField] private int fireBallCount = 5;
     [SerializeField] private Text fireBallCountText;

    // Start is called before the first frame update
    void Start()
    {
        // mendapatkan komponen ketika game baru mulai
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        fireBallCountText.text = fireBallCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                // burung loncat
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Return))
            {
                DoFire();
            } 
        }

    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score.ToString();

        if (OnAddPoint != null)
        {
            // memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // menghentikan animasi burung ketika bersentuhan dengan objek lain
        animator.enabled = false;
    }

    public bool IsDead()
    {
        return isDead;
    }

    // membuat burung mati
    public void Dead()
    {
        // pengecekan jika belum mati dan value OnDead tidak sama dengan null
        if (!isDead && OnDead != null)
        {
            // memanggil semua event pada OnDead
            OnDead.Invoke();
        }

        // mengeset variabel dead menjadi true
        isDead = true;
    }

    void DoFire()
    {
        if (fireBallCount > 0)
        {

            Fireball newFireBall = Instantiate(fireball, transform.position, Quaternion.identity);
            if (newFireBall)
            {
                newFireBall.Fire();
                fireBallCount -= 1;
                fireBallCountText.text = fireBallCount.ToString();
            }
        }
    }

    void Jump()
    {
        // mengecek rigidbody atau tidak
        if (rigidbody2d)
        {
            // menghentikan kecepatan burung ketika jatuh
            rigidbody2d.velocity = Vector2.zero;

            // menambahkan gaya ke arah sumbu y agar burung meloncat
            rigidbody2d.AddForce(new Vector2(0, upForce));
        }

        // pengevekan Null variabel
        if (OnJump != null)
        {
            // menjalankan semua event OnJump event
            OnJump.Invoke();
        }
    }
}
