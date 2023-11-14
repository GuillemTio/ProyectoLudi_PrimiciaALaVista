using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextClicking : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private TMP_Text text;
    //public Camera m_Camera;
    public string correctWord;
    string correctColor = "#4cbb17";
    string wrongColor = "#e32636";
    public ControladorDePuntuació pointControl;
    //float m_MistakesMade = 0;
    //public float m_MaxMistakesMade = 3;
    public Noticies m_Noticia;
    bool m_CanClick = true;

    public List<AudioClip> m_WordAudios;
    public AudioClip m_NoticiaAudio;
    public AudioSource m_AudioSource;
    private float m_LastAudioIndex = -2;
    bool m_CanSayWords = false;

    float timer = 0;
    public float timeToEndTimer = 2f;
    bool timerRunning = false;

    private void Start()
    {
        //m_MistakesMade = 0;
        if (FindObjectOfType<GameController>().m_DaltonicOptionActive)
        {
            correctColor = "#4682B4";
            wrongColor = "#FFA500";
        }
        else
        {
            correctColor = "#4cbb17";
            wrongColor = "#e32636";
        }

    }

    private void Update()
    {
        if (FindObjectOfType<GameController>().m_AudioHelpOptionActive && SceneManager.GetActiveScene().name == "Level1")
        {
            int index = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);
            if (index > -1 && m_LastAudioIndex != index && m_CanSayWords)
            {
                m_AudioSource.clip = m_WordAudios[index];
                m_AudioSource.Play();
                m_LastAudioIndex = index;
            }
        }
        //Debug.Log(TMP_TextUtilities.IsIntersectingRectTransform(text.rectTransform, Input.mousePosition, m_Camera));
        if (Input.GetMouseButtonDown(0) && m_CanClick)
        {
            int index = TMP_TextUtilities.FindIntersectingWord(text, Input.mousePosition, null);
            if (index > -1)
            {
                string word = text.textInfo.wordInfo[index].GetWord();
                int l_StartCharacter = text.textInfo.wordInfo[index].firstCharacterIndex;
                int l_EndCharacter = text.textInfo.wordInfo[index].lastCharacterIndex;
                l_StartCharacter = text.textInfo.characterInfo[l_StartCharacter].index;
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
                    pointControl.CorrectAnswer();
                    m_CanClick = false;
                    timerRunning = true;
                }
                else
                {
                    //text.text = text.text.Replace(word, "<color=" + wrongColor + ">" + word + "</color>");
                    //text.text.Insert(text.textInfo.wordInfo[index].firstCharacterIndex, " <color=" + wrongColor + ">");
                    //text.text.Insert(text.textInfo.wordInfo[index].lastCharacterIndex, "</color>");
                    l_Text = l_Text.Insert(l_EndCharacter + 1, "</color>");
                    l_Text = l_Text.Insert(l_StartCharacter, "<color=" + wrongColor + ">");

                    pointControl.WrongAnswer();

                    //m_MistakesMade += 1;
                }
                text.text = l_Text;


                //if (m_MistakesMade >= m_MaxMistakesMade)
                //{
                //    LineLost();
                //}
                //Debug.Log(text.textInfo.wordInfo[index].GetWord());

                //Application.OpenURL(gameObject.GetComponent<TextMeshProUGUI>().textInfo.linkInfo[index].GetLinkID());
            }
        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {

            if (!m_AudioSource.isPlaying && !m_CanSayWords)
            {
                m_CanSayWords = true;
                m_CanClick = true;
            }
        }

        if (timerRunning)
        {
            timer += Time.deltaTime;
            if (timer > timeToEndTimer)
            {
                timerRunning = false;
                m_CanClick = true;
                LineWon();
            }
        }

    }

    //void LineLost()
    //{
    //    m_Noticia.GetComponent<Noticies>().DesactivateLine();
    //    gameObject.SetActive(false);
    //}


    void LineWon()
    {
        m_Noticia.GetComponent<Noticies>().ActivateLine();
        gameObject.SetActive(false);
    }

    public void SetNoticiaAudio()
    {
        m_AudioSource.clip = m_NoticiaAudio;
        m_AudioSource.Play();
        m_CanSayWords = false;
        m_CanClick = false;
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
}
