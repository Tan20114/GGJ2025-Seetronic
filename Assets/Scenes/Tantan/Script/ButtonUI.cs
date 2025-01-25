using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image holder;
    [SerializeField] Animator animPlayer;

    private void Start()
    {
        holder.color = new Color(1, 1, 1, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        animPlayer.SetBool("isHover", true);
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animPlayer.SetBool("isHover", false);
        Debug.Log("Mouse Exit");
    }
}
