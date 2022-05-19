using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public GameObject controlPanel;

    public void LoadControlPanel()
    {
        if (controlPanel != null)
        {
            controlPanel.SetActive(true);
        }
    }

    public void BackToMain()
    {
        controlPanel.SetActive(false);
    }
}
