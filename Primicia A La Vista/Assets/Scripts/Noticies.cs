using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Noticies : MonoBehaviour
{
    public GameObject m_Noticia;
    public List<TMP_Text> m_Word;
    bool m_WordCompleted = false;
    public GameObject m_ExitNoticiaButton;
    public int m_NoticiaCompleted = 0;

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

        m_ExitNoticiaButton.SetActive(false);

        //gameObject.GetComponent<Button>().enabled = false;
    }

    public bool WordCompleted()
    {
        m_NoticiaCompleted = 1;
        return m_WordCompleted;
    }
}
