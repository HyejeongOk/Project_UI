using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("ī��")]
    public GameObject[] cards;
    public GameObject[] cardbacks;
    public GameObject[] cardfronts;

    public Button selectBtn;    // �����ϱ� ��ư

    public int selectindex = -1;
    public Ease easeType;

    // ī�� Ŭ���ϱ�
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
                // Ŀ����
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);

            }

            else
            {
                // �۾�����
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);
            }
        }

        // ��ư Ȱ��ȭ
        selectBtn.gameObject.SetActive(true);
    }

    // ī�� ���� �� ��ư Ŭ�� ��
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

        // �ո� Ȱ��ȭ, �޸� ��Ȱ��ȭ
        cardfronts[selectindex].SetActive(true);
        cardbacks[selectindex].SetActive(false);

        // ��ư ��Ȱ��ȭ
        selectBtn.gameObject.SetActive(false);
    }
}
