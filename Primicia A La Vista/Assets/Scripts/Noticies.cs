using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Noticies : MonoBehaviour
{
    public GameObject m_Noticia;
    TextClicking m_TextClick;
    public List<TMP_Text> m_Word;
    bool m_WordCompleted = false;
    public GameObject m_ExitNoticiaButton;

    private void Start()
    {
        m_TextClick = m_Noticia.GetComponent<TextClicking>();
    }
    //private void Start()
    //{
    //    GameObject[] l_GameController = GameObject.FindGameObjectsWithTag("GameController");
    //    foreach(GameObject _GameController in l_GameController)
    //    {
    //        if(_GameController != null)
    //        {
    //            _GameController.GetComponent<GameController>().AddNoticia(this.gameObject);
    //            _GameController.GetComponent<GameController>().AddNoticiaAug(m_Noticia);
    //        }
    //    }
    //}

    public void ActivateNoticia()
    {
        m_Noticia.SetActive(true);
        m_ExitNoticiaButton.SetActive(true);
        FindObjectOfType<GameController>().m_ExitNoticiaButton = m_ExitNoticiaButton;

        if (FindObjectOfType<GameController>().m_AudioHelpOptionActive && SceneManager.GetActiveScene().name == "Level1")
        {
            m_TextClick.SetNoticiaAudio();
        }
    }
    //public void DesactivateLine()
    //{
    //    foreach(TMP_Text _Letter in m_Word)
    //    {
    //        _Letter.gameObject.SetActive(true);
    //        //_Letter.color = Color.red;
    //    }
    //    m_WordCompleted = true;
    //
    //    //gameObject.GetComponent<Button>().enabled = false;
    //}

    public void ActivateLine()
    {
        foreach (TMP_Text _Letter in m_Word)
        {
            _Letter.gameObject.SetActive(true);
            //_Letter.color = Color.green;
        }
        m_WordCompleted = true;
        FindObjectOfType<GameController>().m_NoticiaCompleted++;

        m_ExitNoticiaButton.SetActive(false);

        //gameObject.GetComponent<Button>().enabled = false;
    }

    public bool WordCompleted()
    {
        return m_WordCompleted;
    }
}
