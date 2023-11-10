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
    public void ActivateNoticia()
    {
        m_Noticia.SetActive(true);
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

        //gameObject.GetComponent<Button>().enabled = false;
    }

    public bool WordCompleted()
    {
        return m_WordCompleted;
    }
}
