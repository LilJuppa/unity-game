using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    public RectTransform tooltipPanel;
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI description;
    public TextMeshProUGUI state;



    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {

        Cursor.visible = true;
        gameObject.SetActive(false);
    }

 
    
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.x += 40;
        mousePosition.y += -90;

        tooltipPanel.position = mousePosition;

    }

    public void SetAndShowToolTip(string name, string descri, string curState)
    {

        Vector3 mousePosition = Input.mousePosition;

        mousePosition.x += 40;
        mousePosition.y += -90;

        tooltipPanel.position = mousePosition;
        gameObject.SetActive(true);

            textComponent.text = name;
            description.text = descri;
            if (state)
                state.text = curState;



    }

    public void HideToolTip()
    {


        gameObject.SetActive(false);
        //Vector3 farPosition = new Vector3(1000f, 1000f, 0f);
        //tooltipPanel.position = farPosition;
        textComponent.text = string.Empty;
        description.text = string.Empty;
        if (state)
            state.text = string.Empty;


    }
    
    


}
