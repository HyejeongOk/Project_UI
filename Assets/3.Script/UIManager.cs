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

    public Button selectBtn;    // 선택하기 버튼

    public int selectindex = -1;
    public Ease easeType;

    // 카드 클릭하기
    public void OnCardClicked(int index)
    {
        if(selectindex == -1)
        {
            return;
        }

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
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);
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

        StartCoroutine(RevealCard());
    }

    private IEnumerator RevealCard()
    {
        yield return new WaitForSeconds(0.5f);

        // 앞면 활성화, 뒷면 비활성화
        cardfronts[selectindex].SetActive(true);
        cardbacks[selectindex].SetActive(false);

        // 버튼 비활성화
        selectBtn.gameObject.SetActive(false);
    }
}
