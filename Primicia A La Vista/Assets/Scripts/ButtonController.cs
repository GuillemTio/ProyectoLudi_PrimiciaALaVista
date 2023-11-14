using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public AudioSource m_AudioSource;

    private void Start()
    {
        FindObjectOfType<GameController>().Start();
    }

    public void FindExitNoticia()
    {
        FindObjectOfType<GameController>().ExitNoticia();
    }

    public void FindGCChangeScene(string _sceneName)
    {
        FindObjectOfType<GameController>().ChangeScene(_sceneName);
    }

    public void ButtonAudio(AudioClip _AudioClip)
    {
        if (FindObjectOfType<GameController>().m_AudioHelpOptionActive)
        {
            m_AudioSource.clip = _AudioClip;
            m_AudioSource.Play();
        }
    }

    public void FindAudioHelpOption(TMP_Text _ButtonText)
    {
        FindObjectOfType<GameController>().AudioHelpOption(_ButtonText);
    }

    public void FindDaltonicOption(TMP_Text _ButtonText)
    {
        FindObjectOfType<GameController>().DaltonicOption(_ButtonText);
    }
    public void DaltonicOptionAudioDesactivat(AudioClip _AudioClip)
    {
        if (FindObjectOfType<GameController>().m_AudioHelpOptionActive)
        {
            if (!FindObjectOfType<GameController>().m_DaltonicOptionActive)
            {
                m_AudioSource.clip = _AudioClip;
                m_AudioSource.Play();
            }
        }
    }

    public void DaltonicOptionAudioActivat(AudioClip _AudioClip)
    {
        if (FindObjectOfType<GameController>().m_AudioHelpOptionActive)
        {
            if (FindObjectOfType<GameController>().m_DaltonicOptionActive)
            {
                m_AudioSource.clip = _AudioClip;
                m_AudioSource.Play();
            }
        }
    }
}
