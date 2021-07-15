using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text myText;
    [TextArea]
    public string MyTextArea;

    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        myText.text = MyTextArea;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myText.text = "";
    }
}