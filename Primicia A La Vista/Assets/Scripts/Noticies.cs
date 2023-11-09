using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Noticies : MonoBehaviour
{
    //public GameObject m_Noticia;
    //public TMP_Text m_TextNoticia;
    //public List<TMP_Text> Paraula;
   
    public void ActivarNoticia(GameObject _Noticia)
    {
        _Noticia.SetActive(true);
    }
}
