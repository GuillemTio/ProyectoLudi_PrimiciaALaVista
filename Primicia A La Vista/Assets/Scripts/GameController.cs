using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Noticies> m_Noticies;
    public List<GameObject> m_NoticiaAugmentada;
    public GameObject m_ExitNoticiaButton;
    int m_Index = 0;
    bool m_DaltonicOptionActive;

    private void Awake()
    {
        GameController.DontDestroyOnLoad(gameObject);
        GameObject[] l_GameController = GameObject.FindGameObjectsWithTag("GameController");
        foreach (GameObject _GameController in l_GameController)
        {
            if (_GameController != null && _GameController != this.gameObject)
            {
                Destroy(_GameController);
            }
        }
    }

    private void Update()
    {
        Debug.Log(m_DaltonicOptionActive);
        if(SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            foreach (Noticies _Noticia in m_Noticies)
            {
                if (_Noticia.GetComponent<Noticies>().WordCompleted())
                {
                    m_Index = 0;
                    _Noticia.GetComponent<Button>().enabled = false;
                }
                else if (!(m_Index > 0))
                {
                    _Noticia.GetComponent<Button>().enabled = true;
                }
                else if (m_Noticies.IndexOf(_Noticia) == 4)
                {
                    m_Index = 0;
                }

                if (_Noticia.GetComponent<Noticies>().m_Noticia.activeSelf == true)
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
                if (_NoticiaAug.activeSelf == true)
                {
                    m_ExitNoticiaButton.SetActive(true);
                }
            }
        }

    }

    public void DaltonicOption(TMP_Text _ButtonText)
    {
        if (m_DaltonicOptionActive == true)
        {
            m_DaltonicOptionActive = false;
            _ButtonText.text = "No";
        }
        else
        {
            m_DaltonicOptionActive = true;
            _ButtonText.text = "Si";
        }
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
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
