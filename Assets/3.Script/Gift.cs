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

    public UIManager ui_mgr;

    private void OnEnable()
    {
        animator = GetComponentInChildren<Animator>();
        animator.Play("Gift");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GiftClose.activeInHierarchy)
        {
            particle.Stop();
            particle.gameObject.SetActive(true);
            particle.Play();
            GiftOpen.SetActive(true);
            GiftClose.SetActive(false);

            StartCoroutine(ui_mgr.OpenResult_co());
            
        }
    }
}
