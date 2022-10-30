using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea(15,20)][SerializeField] string _content = "";
    [SerializeField] string _header = "";
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(_content,_header);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();

    }
}
