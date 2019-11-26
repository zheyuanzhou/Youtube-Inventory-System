using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//STEP 04 ONCE MOUSE HOVER, We can know the Item Detail INFORMATION
public class ToolTips : MonoBehaviour
{
    public Text detailText;

    private void Start()
    {
        HideTooltip();
    }

    public void SetPosition(Vector2 _pos)
    {
        transform.localPosition = _pos;
    }

    public void ShowTooltip()
    {
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public void UpdateTooltip(string _detailText)
    {
        detailText.text = _detailText;
    }
}
