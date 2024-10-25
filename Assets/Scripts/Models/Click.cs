using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ClickAction
{
    void DealClick();
}
public class Click : MonoBehaviour
{
    ClickAction clickAction;
    public void setClickAction(ClickAction clickAction)
    {
        this.clickAction = clickAction;
    }
    void OnMouseDown()
    {
        clickAction.DealClick();
    }
}