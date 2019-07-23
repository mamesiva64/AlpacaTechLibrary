using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour {

    public bool startPanelEnable = false;
    public int startPanelIndex;

    public List<GameObject> panels;


    void Start()
    {
        if (startPanelEnable)
        {
            Show(startPanelIndex);
        }
    }


    public void Show(int aItem)
    {
        for(int i=0;i<panels.Count;++i)
        {
            var panel = panels[i];
            if (panel)
            {
                if (i == aItem)
                {
                    panel.SetActive(true);
                }
                else
                {
                    panel.SetActive(false);
                }
            }
        }

    }


}
