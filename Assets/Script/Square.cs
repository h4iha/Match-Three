using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum ColorEnum
{
    Red , Green, Blue, Yellow,
}

public class Square : MonoBehaviour
{
    private GameManager gameManager;
    //
    [SerializeField] private ColorEnum colorThis;
    [SerializeField] private Image image;
    [SerializeField] private Button buttonChoose;
    [SerializeField] private Button buttonChange;
    private int indexSquare;
    public Image ImageSquare { get { return image; } }
    public int IndexSquare { get { return indexSquare; } set { indexSquare = value; } }
    //public 
    private void Start()
    {
        gameManager = GameManager.Instance;
        image.color = SetColor(colorThis);
    }
    public void ChangeColorImage(ColorEnum colorEnum)
    {
        image.color = SetColor(colorEnum);
    }
    private Color SetColor(ColorEnum colorEnum)
    {
        Color color;
        switch(colorEnum)
        {
            case ColorEnum.Red: color = Color.red;
                return color;
            case ColorEnum.Green: color = Color.green;
                return color;
            case ColorEnum.Blue: color = Color.blue;
                return color;
            case ColorEnum.Yellow: color = Color.yellow;
                return color;
        }
        return Color.black;
    }
    public void ChooseSquareNeedChange()
    {
        gameManager.indexChosenFirst = this.indexSquare;
        Debug.Log("ClickSquare");
        transform.localScale = new Vector3(0.5f, 0.5f);
    }
    public void DoChange()
    {
        gameManager.indexChosenSecond = this.indexSquare;
        gameManager.isChanged = true;
    }
}
