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

    public GameObject Fadebg;   // ���� ���

    public int selectindex = -1;
    public Ease easeType;

    // ī�� Ŭ���ϱ�
    public void OnCardClicked(int index)
    {
        selectindex = index;

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
}
