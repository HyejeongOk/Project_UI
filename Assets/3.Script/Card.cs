using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public int cardIndex;
    public UIManager ui_mgr;

    public void OnPointerClick(PointerEventData eventData)
    {
        ui_mgr.OnCardClicked(cardIndex);
        Debug.Log("카드 클릭");
    }
}
