using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    private GameManager gameManager;
    //
    [SerializeField] private Transform parentTransform;
    [SerializeField] private Transform grid;
    [SerializeField] private ImageClone imageClonePrefab;
    private Square[] squares = new Square[64];
    public Action onChangeTwoSquare;

    void Start()
    {
        gameManager = GameManager.Instance;
        RefreshList();
        onChangeTwoSquare = HandleChangeTwoSquare;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RefreshList()
    {
        for (int i = 0; i < grid.childCount; i++)
        {
            squares[i] = grid.GetChild(i).GetComponent<Square>();
            squares[i].IndexSquare = i;
        }
    }
    private void HandleChangeTwoSquare()
    {
        int indexFirst = gameManager.indexChosenFirst;
        int indexSecond = gameManager.indexChosenSecond;
        squares[indexFirst].transform.localScale = new Vector3(1, 1, 1);
        Color tempColor = squares[indexFirst].ImageSquare.color;
        squares[indexFirst].ImageSquare.color = squares[indexSecond].ImageSquare.color;
        squares[indexSecond].ImageSquare.color = tempColor;
        CheckThree(indexSecond);
        RefreshList();
    }
    private void SpawnSquareAndMove(Color color, Vector3 spawnPoint, Vector3 destination)
    {
        ImageClone newImageClone = Instantiate(imageClonePrefab, spawnPoint, Quaternion.identity, parentTransform);
        newImageClone.GetComponent<Image>().color = color;
        newImageClone.destination = destination;
        newImageClone.isCanMove = true;
    }
    private void CheckThree(int indexSecond)
    {
        if ((squares[indexSecond].ImageSquare.color == squares[indexSecond + 1].ImageSquare.color && squares[indexSecond].ImageSquare.color == squares[indexSecond - 1].ImageSquare.color))
        {
            Debug.Log("add raw");
            
        }
        if ((squares[indexSecond].ImageSquare.color == squares[indexSecond + 8].ImageSquare.color && 
            squares[indexSecond].ImageSquare.color == squares[indexSecond - 8].ImageSquare.color))
        {
            Debug.Log("add col");
            for (int i = indexSecond; i < 8; i -= 8)
            {
                //squares[i].ImageSquare.color = RandomColor();
                squares[i].ImageSquare.color = Color.red;
            }
        }
    }
    private Color RandomColor()
    {
        int rd = UnityEngine.Random.Range(0, 4);
        switch (rd)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.green;
            case 2:
                return Color.blue;
            case 3:
                return Color.yellow;
        }
        return Color.black;
    }
}
