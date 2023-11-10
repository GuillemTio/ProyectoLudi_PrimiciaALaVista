using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Noticies> m_Noticies;
    public List<GameObject> m_NoticiaAugmentada;

    private void Update()
    {
        foreach(Noticies _Noticia in m_Noticies)
        {
            if (_Noticia.GetComponent<Noticies>().WordCompleted())
            {
                _Noticia.GetComponent<Button>().enabled = false;
            }

            if(_Noticia.GetComponent<Noticies>().m_Noticia.activeSelf == true)
            {
                foreach (Noticies _NoticiaButton in m_Noticies)
                {
                    _NoticiaButton.GetComponent<Button>().enabled = false;
                }
            }
        }

    }

    public void ExitNoticia()
    {
        foreach (GameObject _NoticiaAug in m_NoticiaAugmentada)
        {
            _NoticiaAug.SetActive(false);
        }
    }
}
