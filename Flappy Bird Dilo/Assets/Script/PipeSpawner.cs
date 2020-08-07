using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, PipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize = 1f;
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;
    private Coroutine CR_Spawn;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    void StartSpawn()
    {
        //Menjalankan Fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        // hentikan Coroutine
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        // duplikasi obj pipeUp dan putar 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));
        newPipeUp.gameObject.SetActive(true);

        // duplikasi game obj pipeDown dan ambil posisinya sendiri
        Pipe newPipeDown = Instantiate(PipeDown, transform.position, Quaternion.identity);
        newPipeDown.gameObject.SetActive(true);

        holeSize = Random.Range(0.3f, 1.5f);

        newPipeUp.transform.position += Vector3.up * holeSize;
        newPipeDown.transform.position += Vector3.down * holeSize;

        // menetapkan posisi piupa yang telah dibentuk agar posisinya menyesuaikan dengan fungsi sin
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position,Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            // kalau burung mati, hentikan pembuatan pipa
            if (bird.IsDead())
            {
                StopSpawn();
            }

            // buat pipa baru
            SpawnPipe();

            // menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
