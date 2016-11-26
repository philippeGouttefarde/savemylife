using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PressedButtonBehavior : MonoBehaviour {


    public Color defaultColor;
    public Color pressedColor;
    

    private bool isPressedState = false;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    private void ChangeButtonUI()
    {
        if(isPressedState)
        {
            image.color = pressedColor;
        } else
        {
            image.color = defaultColor;
        }
    }

    public void OnClick()
    {
        isPressedState = !isPressedState;
        ChangeButtonUI();
    }

    void OnMouseOver()
    {
        Debug.Log("TEST1");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("TEST2");
        }
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        print("I was clicked");
    }
}
