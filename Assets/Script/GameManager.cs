using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }
    [SerializeField] private GridManager gridManager;
    public bool isChanged;
    public int indexChosenFirst;
    public int indexChosenSecond;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        isChanged = false;
        indexChosenFirst = -1;
        indexChosenSecond = -1;
    }
    private void Update()
    {
        if (isChanged)
        {
            isChanged = false;
            gridManager.onChangeTwoSquare?.Invoke();
        }
    }
}
