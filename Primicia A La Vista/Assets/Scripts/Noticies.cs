using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Noticies : MonoBehaviour
{
    public GameObject m_Noticia;
    public TMP_Text m_TextNoticia;
    public List<TMP_Text> Paraula;

    void Update()
    {
        if(m_Noticia.activeSelf == true)
        {

        }
    }

    public void ActivarNoticia()
    {
        m_Noticia.SetActive(true);
    }
}
