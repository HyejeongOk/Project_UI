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
    public int selectindex = -1;
    public Ease easeType;

    [Header("선물")]
    public GameObject Fadebg;   // 검정 배경
    public Gift gift;

    [Header("결과 UI")]
    public GameObject ResultPannel;
    public ParticleSystem Resultparticle;
    public GameObject Backbtn;

    // 카드 클릭하기
    public void OnCardClicked(int index)
    {
        selectindex = index;

        for(int i = 0; i < cards.Length; i++)
        {
            Transform card = cards[i].transform;

            if (i == index)
            {
                // 선택된 카드는 커진다
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);
            }

            else
            {
                // 그 외 카드는 작아진다
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

    // 결과창 열기
    public IEnumerator OpenResult_co()
    {

        yield return new WaitForSeconds(2f);
        // 선물 파티클 멈춤
        gift.particle.Stop();

        // 결과창 열기 
        ResultPannel.SetActive(true);

        // 파티클 생성
        Resultparticle.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        // 버튼 생성
        Backbtn.SetActive(true);
    }

    // BackBtn 클릭 시 fade 닫히고 원래대로 돌아옴
    public void OnClickBackBtn()
    {
        Fadebg.SetActive(false);

        //원상복귀
        // 1. 선택된 카드가 있으면 처리
        if(selectindex != -1)
        {
            // 2. 앞면은 비활성화, 뒷면은 활성화
            cardfronts[selectindex].SetActive(false);
            cardbacks[selectindex].SetActive(true);
        }

        // 3. 크기도 원래대로 돌아오게 하기
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.localScale = Vector3.one * 3.5f;
        }

        // 4. 인덱스 초기화
        selectindex = -1;

        // 5. 선택 버튼 비활성화
        selectBtn.gameObject.SetActive(false);


        // 6. 결과창  선물 원상복구
        // 닫힌 선물 활성화, 열린 선물 비활성화
        gift.particle.gameObject.SetActive(false);
        gift.GiftOpen.SetActive(false);
        gift.GiftClose.SetActive(true);

        // 결과창 비활성화
        ResultPannel.SetActive(false);
        Backbtn.SetActive(false);
    }    
}
