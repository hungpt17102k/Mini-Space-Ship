using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject imageInstruction;

    public void PlayGameButton() {
        SceneManager.LoadScene(1);
    }

    public void ShowInstruction() {
        imageInstruction.SetActive(true);
    }
}
