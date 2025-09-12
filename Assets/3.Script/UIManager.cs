using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("카드")]
    public GameObject[] cards;
    public GameObject[] cardbacks;
    public GameObject[] cardfronts;
    public ParticleSystem[] particle;

    public Button selectBtn;    // 선택하기 버튼

    public GameObject Fadebg;   // 검정 배경

    public int selectindex = -1;
    public Ease easeType;

    // 카드 클릭하기
    public void OnCardClicked(int index)
    {
        selectindex = index;

        for(int i = 0; i < cards.Length; i++)
        {
            Transform card = cards[i].transform;

            if(i == index)
            {
                // 커진다
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);

            }

            else
            {
                // 작아진다
                card.DOScale(Vector3.one * 1.5f, 1f).SetEase(easeType);
            }
        }

        // 버튼 활성화
        selectBtn.gameObject.SetActive(true);
    }

    // 카드 선택 후 버튼 클릭 시
    public void OnSelectBtnClicked()
    {
        if(selectindex == -1)
        {
            return;
        }

        StartCoroutine(RevealCard_co());
    }

    private IEnumerator RevealCard_co()
    {
        // 선택된 파티클만 꺼내기
        var selectParticle = particle[selectindex];

        // 파티클 껐다가 다시 재생
        selectParticle.gameObject.SetActive(true);
        selectParticle.Stop();

        yield return new WaitForSeconds(0.1f);

        selectParticle.Play();

        // 앞면 활성화, 뒷면 비활성화
        cardfronts[selectindex].SetActive(true);
        cardbacks[selectindex].SetActive(false);

        // 버튼 비활성화
        selectBtn.gameObject.SetActive(false);

        // 파티클 비활성화
        yield return new WaitForSeconds(1f);
        selectParticle.gameObject.SetActive(false);

        // Fade 전환
        yield return new WaitForSeconds(1f);
        Fadebg.SetActive(true);
    }
}
