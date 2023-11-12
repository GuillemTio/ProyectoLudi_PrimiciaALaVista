using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Noticies> m_Noticies;
    public List<GameObject> m_NoticiaAugmentada;
    public GameObject m_ExitNoticiaButton;
    int m_Index = 0;

    private void Update()
    {
        foreach(Noticies _Noticia in m_Noticies)
        {
            if (_Noticia.GetComponent<Noticies>().WordCompleted())
            {
                m_Index = 0;
                _Noticia.GetComponent<Button>().enabled = false;
            }
            else if(!(m_Index > 0))
            {
                _Noticia.GetComponent<Button>().enabled = true;
            }
            else if(m_Noticies.IndexOf(_Noticia) == 2)
            {
                m_Index = 0;
            }
            
            if(_Noticia.GetComponent<Noticies>().m_Noticia.activeSelf == true)
            {
                m_Index += 1;
                foreach (Noticies _NoticiaButton in m_Noticies)
                {
                    _NoticiaButton.GetComponent<Button>().enabled = false;
                }
            }
        }

        foreach (GameObject _NoticiaAug in m_NoticiaAugmentada)
        {
            if(_NoticiaAug.activeSelf == true)
            {
                m_ExitNoticiaButton.SetActive(true);
            }
        }

    }

    public void ExitNoticia()
    {
        foreach (GameObject _NoticiaAug in m_NoticiaAugmentada)
        {
            m_ExitNoticiaButton.SetActive(false);
            _NoticiaAug.SetActive(false);
        }
    }
}
