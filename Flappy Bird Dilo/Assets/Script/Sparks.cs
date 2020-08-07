using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sparks : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private UnityEvent OnExplode;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowSparks()
    {
        gameObject.SetActive(true);
        if(animator)
        {
            animator.enabled = true;
            OnExplode.Invoke();
        }

    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }
}
