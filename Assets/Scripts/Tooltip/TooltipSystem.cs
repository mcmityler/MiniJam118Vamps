using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem _current;
    public TooltipScript tooltip;

    void Awake(){
        _current = this;
        Hide();
    }
    public static void Show(string content = "", string header = ""){
        _current.tooltip.SetText(content,header);
        _current.tooltip.gameObject.SetActive(true);
    }
    public static void Hide(){
        _current.tooltip.gameObject.SetActive(false);
    }
}
