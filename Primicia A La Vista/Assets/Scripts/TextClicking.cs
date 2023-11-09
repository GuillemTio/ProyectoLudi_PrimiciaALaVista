using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextClicking : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private TMP_Text text;
    public Camera m_Camera;
    public string correctWord;
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
                int l_StartCharacter = text.textInfo.wordInfo[index].firstCharacterIndex;
                int l_EndCharacter = text.textInfo.wordInfo[index].lastCharacterIndex;
                l_StartCharacter=text.textInfo.characterInfo[l_StartCharacter].index;
                l_EndCharacter = text.textInfo.characterInfo[l_EndCharacter].index;
                string l_Text = text.text;
                //Debug.Log("Rs " + text.textInfo.wordInfo[index].firstCharacterIndex + " - " + text.textInfo.wordInfo[index].lastCharacterIndex);
               
                //Debug.Log("aa " + l_Text);
                
                //text.textInfo.wordInfo[index].firstCharacterIndex;
                if (word == correctWord)
                {
                    //text.text = text.text.Replace(correctWord, "<color=" + correctColor + ">" + word + "</color>");
                    //text.text.Insert(text.textInfo.wordInfo[index].firstCharacterIndex, " <color=" + correctColor + ">");
                    //text.text.Insert(text.textInfo.wordInfo[index].lastCharacterIndex, "</color>");

                    l_Text = l_Text.Insert(l_EndCharacter + 1, "</color>");
                    l_Text = l_Text.Insert(l_StartCharacter, "<color=" + correctColor + ">");
                }
                else
                {
                    //text.text = text.text.Replace(word, "<color=" + wrongColor + ">" + word + "</color>");
                    //text.text.Insert(text.textInfo.wordInfo[index].firstCharacterIndex, " <color=" + wrongColor + ">");
                    //text.text.Insert(text.textInfo.wordInfo[index].lastCharacterIndex, "</color>");

                    l_Text = l_Text.Insert(l_EndCharacter + 1, "</color>");
                    l_Text = l_Text.Insert(l_StartCharacter, "<color=" + wrongColor + ">");
                }
                text.text = l_Text;

                //Debug.Log(text.textInfo.wordInfo[index].GetWord());

                //Application.OpenURL(gameObject.GetComponent<TextMeshProUGUI>().textInfo.linkInfo[index].GetLinkID());
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("aaaaa");
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
