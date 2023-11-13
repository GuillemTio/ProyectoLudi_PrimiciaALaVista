using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void FindGCChangeScene(string _sceneName)
    {
        FindObjectOfType<GameController>().ChangeScene(_sceneName);
    }

    public void FindAudioHelpOption(TMP_Text _ButtonText)
    {
        FindObjectOfType<GameController>().AudioHelpOption(_ButtonText);
    }

    public void FindDaltonicOption(TMP_Text _ButtonText)
    {
        FindObjectOfType<GameController>().DaltonicOption(_ButtonText);
    }
}
