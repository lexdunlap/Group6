using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCircularMenu : MonoBehaviour
{
    public List<MenuButton> buttons = new List<MenuButton>();
    private Vector2 Mouseposition;
    private Vector2 fromVector2m = new Vector2(.5f, 1.0f);
    private Vector2 centerCircle = new Vector2(.5f,.5f);
    private Vector2 toVector2M;

    public int menuItems;
    public int CurMenuItems;
    private int OldMenuItem;

    public BuildingSystem builsys;
	// Use this for initialization
	void Start ()
    {
        menuItems = buttons.Count;
        foreach(MenuButton button in buttons)
        {
            button.sceneImage.color = button.normalColor;
        }
        CurMenuItems = 0;
        OldMenuItem = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        getCurrentMenuItem();
	}
    public void getCurrentMenuItem()
    {
        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        toVector2M = new Vector2(Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);
        float angle = (Mathf.Atan2(fromVector2m.y - centerCircle.y, fromVector2m.x - centerCircle.x) - Mathf.Atan2(toVector2M.y - centerCircle.y, toVector2M.x - centerCircle.x))* Mathf.Rad2Deg;

        if (angle <0)
        {
            angle += 360;
        }
        CurMenuItems = (int)(angle / (360 / menuItems));
        if(CurMenuItems!=OldMenuItem)
        {
            buttons[OldMenuItem].sceneImage.color = buttons[OldMenuItem].normalColor;
            OldMenuItem = CurMenuItems;
            buttons[CurMenuItems].sceneImage.color = buttons[CurMenuItems].highlightedColor;
        }

    }
    public void buttonAction()
    {
        buttons[CurMenuItems].sceneImage.color = buttons[CurMenuItems].pressedColor;
        builsys.ChangeCurrentBuilding(CurMenuItems);

    }
}
[System.Serializable]
public class MenuButton
{
    public string name;
    public Image sceneImage;
    public Color normalColor = Color.white;
    public Color highlightedColor = Color.grey;
    public Color pressedColor = Color.gray;
}
