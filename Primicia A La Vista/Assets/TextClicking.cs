using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextClicking : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private TMP_Text text;
    public Camera m_Camera;
    string correctWord = "carrer";
    string correctColor = "#4cbb17";
    string wrongColor = "#e32636";

    private void Update()
    {



        //Debug.Log(TMP_TextUtilities.IsIntersectingRectTransform(text.rectTransform, Input.mousePosition, m_Camera));
        if (Input.GetMouseButtonDown(0))
        {

            int index = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);
            if (index > -1)
            {
                string word = text.textInfo.wordInfo[index].GetWord();
                if (word == correctWord)
                {
                    text.text = text.text.Replace(correctWord, "<color=" + correctColor + ">" + word + "</color>");
                }
                else
                {
                    text.text = text.text.Replace(word, "<color=" + wrongColor + ">" + word + "</color>");
                }

                Debug.Log(text.textInfo.wordInfo[index].GetWord());

                //Application.OpenURL(gameObject.GetComponent<TextMeshProUGUI>().textInfo.linkInfo[index].GetLinkID());
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("aaaaa");
        //    if (eventData.button == PointerEventData.InputButton.Left)
        //    {
        //        Debug.Log("aaaaa");
        //        int index = TMP_TextUtilities.FindIntersectingWord(text.gameObject.GetComponent<TextMeshProUGUI>(), Input.mousePosition, null);
        //        if (index > -1)
        //        {
        //            Debug.Log("hola, index = "+index);
        //            //Application.OpenURL(gameObject.GetComponent<TextMeshProUGUI>().textInfo.linkInfo[index].GetLinkID());
        //        }
        //    }
    }
    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
    //    if (linkIndex > -1)
    //    {
    //        TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
    //        //Application.OpenURL(linkInfo.GetLinkID());
    //        Debug.Log(linkInfo);
    //    }
    //}
}
