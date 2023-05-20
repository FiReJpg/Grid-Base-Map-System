using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public ScrollRect mapScrollView;
    public MapController mapController;
    public GameObject plotInfoPanel;

    public TMP_Text plotAddress;

    public void PlotInfoOpen()
    {
        plotInfoPanel.SetActive(true);
        Cursor.visible = true;
        mapScrollView.horizontal = false;
        mapScrollView.vertical = false;
        plotAddress.text = "(" + mapController.a + "," + mapController.b + ")";
        mapController.enabled = false;
    }

    public void PlotInfoClosed()
    {
        plotInfoPanel.SetActive(false);
        Cursor.visible = false;
        mapScrollView.horizontal = true;
        mapScrollView.vertical = true;

        mapController.enabled = true;
    }


}
