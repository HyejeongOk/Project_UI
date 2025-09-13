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
    public ParticleSystem[] particle;
    public Button selectBtn;    // �����ϱ� ��ư
    public int selectindex = -1;
    public Ease easeType;

    [Header("����")]
    public GameObject Fadebg;   // ���� ���
    public Gift gift;

    [Header("��� UI")]
    public GameObject ResultPannel;
    public ParticleSystem Resultparticle;
    public GameObject Backbtn;

    // ī�� Ŭ���ϱ�
    public void OnCardClicked(int index)
    {
        selectindex = index;

        for(int i = 0; i < cards.Length; i++)
        {
            Transform card = cards[i].transform;

            if (i == index)
            {
                // ���õ� ī��� Ŀ����
                card.DOScale(Vector3.one * 5f, 1f).SetEase(easeType);
            }

            else
            {
                // �� �� ī��� �۾�����
                card.DOScale(Vector3.one * 1.5f, 1f).SetEase(easeType);
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

        StartCoroutine(RevealCard_co());
    }

    private IEnumerator RevealCard_co()
    {
        // ���õ� ��ƼŬ�� ������
        var selectParticle = particle[selectindex];

        // ��ƼŬ ���ٰ� �ٽ� ���
        selectParticle.gameObject.SetActive(true);
        selectParticle.Stop();

        yield return new WaitForSeconds(0.1f);

        selectParticle.Play();

        // �ո� Ȱ��ȭ, �޸� ��Ȱ��ȭ
        cardfronts[selectindex].SetActive(true);
        cardbacks[selectindex].SetActive(false);

        // ��ư ��Ȱ��ȭ
        selectBtn.gameObject.SetActive(false);

        // ��ƼŬ ��Ȱ��ȭ
        yield return new WaitForSeconds(1f);
        selectParticle.gameObject.SetActive(false);

        // Fade ��ȯ
        yield return new WaitForSeconds(1f);
        Fadebg.SetActive(true);
    }

    // ���â ����
    public IEnumerator OpenResult_co()
    {

        yield return new WaitForSeconds(2f);
        // ���� ��ƼŬ ����
        gift.particle.Stop();

        // ���â ���� 
        ResultPannel.SetActive(true);

        // ��ƼŬ ����
        Resultparticle.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        // ��ư ����
        Backbtn.SetActive(true);
    }

    // BackBtn Ŭ�� �� fade ������ ������� ���ƿ�
    public void OnClickBackBtn()
    {
        Fadebg.SetActive(false);

        //���󺹱�
        // 1. ���õ� ī�尡 ������ ó��
        if(selectindex != -1)
        {
            // 2. �ո��� ��Ȱ��ȭ, �޸��� Ȱ��ȭ
            cardfronts[selectindex].SetActive(false);
            cardbacks[selectindex].SetActive(true);
        }

        // 3. ũ�⵵ ������� ���ƿ��� �ϱ�
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.localScale = Vector3.one * 3.5f;
        }

        // 4. �ε��� �ʱ�ȭ
        selectindex = -1;

        // 5. ���� ��ư ��Ȱ��ȭ
        selectBtn.gameObject.SetActive(false);


        // 6. ���â  ���� ���󺹱�
        // ���� ���� Ȱ��ȭ, ���� ���� ��Ȱ��ȭ
        gift.particle.gameObject.SetActive(false);
        gift.GiftOpen.SetActive(false);
        gift.GiftClose.SetActive(true);

        // ���â ��Ȱ��ȭ
        ResultPannel.SetActive(false);
        Backbtn.SetActive(false);
    }    
}
