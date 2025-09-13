using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gift : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GiftClose.activeInHierarchy)
        {
            particle.gameObject.SetActive(true);
            GiftOpen.SetActive(true);
            GiftClose.SetActive(false);
        }
    }
}
