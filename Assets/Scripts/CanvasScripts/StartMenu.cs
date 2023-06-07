using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject LogPanel, RegPanel, PlayerPanel;

    public void LogPanelActive()
    {
        LogPanel.SetActive(true);
        RegPanel.SetActive(false);
    }

    public void RegPanelActive()
    {
        LogPanel.SetActive(false);
        RegPanel.SetActive(true);
    }

    public void PanelsOff()
    {
        LogPanel.SetActive(false);
        RegPanel.SetActive(false);
    }

    public void PlayerActive()
    {
        PlayerPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
