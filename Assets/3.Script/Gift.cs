using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private Animator animator;
    public ParticleSystem particle;
    public GameObject GiftClose;
    public GameObject GiftOpen;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.Play("Gift");
    }

    private void Start()
    {
        if(GiftClose.activeInHierarchy)
        {
            StartCoroutine(GiftParticle_co());
        }
    }

    private IEnumerator GiftParticle_co()
    {
        yield return new WaitForSeconds(2.5f);

        GiftOpen.SetActive(true);
        GiftClose.SetActive(false);
    }
}
