using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    List<GameObject> m_Noticies;
    List<GameObject> m_NoticiaAugmentada;
    public GameObject m_ExitNoticiaButton;
    int m_Index = 0;
    int m_IndexNoticiesActives = 0;
    public bool m_DaltonicOptionActive;
    public bool m_AudioHelpOptionActive;
    bool m_AlreadyInitializated = false;

    private void Awake()
    {
        m_Noticies = new List<GameObject>();
        m_NoticiaAugmentada = new List<GameObject>();

        if (!m_AlreadyInitializated)
        {
            GameObject[] l_GameController = GameObject.FindGameObjectsWithTag("GameController");
            foreach (GameObject _GameController in l_GameController)
            {
                if (_GameController != null && _GameController != this.gameObject)
                {
                    GameObject.Destroy(gameObject);
                }
                else
                {
                    GameController.DontDestroyOnLoad(gameObject);
                }
            }
            m_AlreadyInitializated = true;
        }
    }

    public void Start()
    {
        LoadLevels();
    }

    //public void AddNoticia(GameObject _Noticia)
    //{
    //    m_Noticies.Add(_Noticia);
    //}
    //
    //public void AddNoticiaAug(GameObject _NoticiaAug)
    //{
    //    m_NoticiaAugmentada.Add(_NoticiaAug);
    //}

    private void Update()
    {
        //Debug.Log(m_DaltonicOptionActive);
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            foreach (GameObject _Noticia in m_Noticies)
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
                    m_IndexNoticiesActives = 0;
                    m_Index += 1;
                    foreach (GameObject _NoticiaButton in m_Noticies)
                    {
                        _NoticiaButton.GetComponent<Button>().enabled = false;
                    }
                }
                else
                    m_IndexNoticiesActives++;

                if(m_IndexNoticiesActives >= m_Noticies.Count)
                {
                    foreach (GameObject _NoticiaButton in m_Noticies)
                    {
                        if (!_Noticia.GetComponent<Noticies>().WordCompleted())
                            _NoticiaButton.GetComponent<Button>().enabled = true;
                    }
                    m_IndexNoticiesActives = 0;
                }
            }

            //foreach (GameObject _NoticiaAug in m_NoticiaAugmentada)
            //{
            //    if (_NoticiaAug.activeSelf == true)
            //    {
            //        //GameObject[] l_ButtonExitNoticia = GameObject.FindGameObjectsWithTag("ExitNoticia");
            //        //foreach (GameObject _ButtonExtiNoticia in l_ButtonExitNoticia)
            //        //{
            //        //    m_ExitNoticiaButton = _ButtonExtiNoticia;
            //        //}
            //    }
            //}
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

    public void AudioHelpOption(TMP_Text _ButtonText)
    {
        if (m_AudioHelpOptionActive == true)
        {
            m_AudioHelpOptionActive = false;
            _ButtonText.text = "No";
        }
        else
        {
            m_AudioHelpOptionActive = true;
            _ButtonText.text = "Si";
        }
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);

        m_Noticies.Clear();
        m_NoticiaAugmentada.Clear();
        LoadLevels();
    }

    void LoadLevels()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            GameObject[] l_Noticies = GameObject.FindGameObjectsWithTag("Noticia");
            foreach (GameObject _Noticia in l_Noticies)
            {
                m_Noticies.Add(_Noticia);
            }
        
            GameObject[] l_NoticiesAug = GameObject.FindGameObjectsWithTag("Noticia");
            foreach (GameObject _NoticiaAug in l_NoticiesAug)
            {
                m_NoticiaAugmentada.Add(_NoticiaAug.GetComponent<Noticies>().m_Noticia);
            }
        }
        
        if (SceneManager.GetActiveScene().name == "Options")
        {
            GameObject[] l_Button = GameObject.FindGameObjectsWithTag("OptionMenu");
            foreach (GameObject _Button in l_Button)
            {
                if (_Button.GetComponentInChildren<TMP_Text>().CompareTag("OptionMenuAudio"))
                {
                    Debug.Log(m_AudioHelpOptionActive);
                    if (m_AudioHelpOptionActive)
                        _Button.GetComponentInChildren<TMP_Text>().text = "Si";
                    else
                        _Button.GetComponentInChildren<TMP_Text>().text = "No";
                }
                if (_Button.GetComponentInChildren<TMP_Text>().CompareTag("OptionMenuDaltonic"))
                {
                    Debug.Log(m_AudioHelpOptionActive);
                    if (m_DaltonicOptionActive)
                        _Button.GetComponentInChildren<TMP_Text>().text = "Si";
                    else
                        _Button.GetComponentInChildren<TMP_Text>().text = "No";
                }
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
