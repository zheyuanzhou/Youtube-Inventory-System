using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

//STEP 03 Remove Button
public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler//STEP 04
{
    public int buttonID;
    private Item thisItem;

    public ToolTips tooltips;//STEP 04
    private Vector2 position;

    private Item GetThisItem()
    {
        for(int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem = GameManager.instance.items[i];
            }
        }

        return thisItem;
    }

    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem());
    }

    //STEP 04
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();//STEP 04

        if (thisItem != null)
        {
            Debug.Log("ENTER " + thisItem.itemName + " SLOT");
            Debug.Log("Description:" + thisItem.itemDes + ". Price: " + thisItem.itemPrice);

            tooltips.ShowTooltip();
            //tooltips.UpdateTooltip(thisItem.itemDes);//MARKER SIMPLE VERSION DISPLAY CORRECT INFO
            tooltips.UpdateTooltip(GetDetailText(thisItem));//HELPER FUNCTION 

            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltips.SetPosition(position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(thisItem != null)
        {
            Debug.Log("EXIT " + thisItem.itemName + " SLOT");

            tooltips.HideTooltip();
            tooltips.UpdateTooltip("");//CLEAR
        }
    }

    //HELPER This METHOD can help us return one series of string
    private string GetDetailText(Item _item)
    {
        if(_item == null) {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<color=black><size=40>Item:</size></color> <color=orange><size=50>{0}</size></color>\n\n", _item.itemName);

            stringBuilder.AppendFormat("<size=40><color=black>Sell Price:</color></size> <color=red><size=50>{0}</size></color>\n\n" +
                "<size=40>Description:</size> <size=45><color=grey>{1}</color></size>\n\n", _item.itemPrice, _item.itemDes);

            return stringBuilder.ToString();
        }
    }

}
