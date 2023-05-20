using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class MapController : MonoBehaviour
{
    //info for map
    [HideInInspector]
    public int a, b;

    public int cellSize;
    public Vector3 originPostion;
    public Vector3 offset;

    //img acting as button to show plot and available to click on them
    public GameObject img;
    //panel to show plot info
    public GameObject infoPanel;

    public TMP_Text coordinatesInfo;
    Vector3 coordinateTextinfodefaultPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        coordinateTextinfodefaultPos = coordinatesInfo.rectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //getting the mouse pointer position on image
        var pointerEventData = new PointerEventData(EventSystem.current) { pointerId = -1, position = Input.mousePosition };
        //getting the position with respect to world points 
        Vector2 pos = PointerDataToRelativePos(pointerEventData);
        //converting vectors into normalize int to represent as Coordinates
        GetXY(pos, out a, out b);
        //setting position of the button according to mouse
        img.GetComponent<RectTransform>().transform.localPosition = GetWorldPostion(a,b) + offset;
        coordinatesInfo.text = "(" + a + "," + b + ")";
    }

    private Vector2 PointerDataToRelativePos(PointerEventData eventData)
    {
        Vector2 result;
        Vector2 clickPosition = eventData.position;
        RectTransform thisRect = GetComponent<RectTransform>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(thisRect, clickPosition, null, out result);
        result += thisRect.sizeDelta / 2;
        

        return result;
    }

    //converts coordinates and denormalize into world space
    public Vector3 GetWorldPostion(int x, int y)
    {
        return new Vector3(x, y, 0) * cellSize  + originPostion ;
    }
    
    //convert vector3 to world coordinates 
    void GetXY(Vector3 worldpos, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldpos - originPostion).x / cellSize);
        z = Mathf.FloorToInt((worldpos - originPostion).y / cellSize); 
    }
    
    
    //Method to call upon button is clicked
    public void buttonTest()
    {
        Debug.Log("button is pressed at " + "(" + a +","+b + ")");

    }

}

