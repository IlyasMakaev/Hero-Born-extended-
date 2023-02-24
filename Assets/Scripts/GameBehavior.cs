using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour, IManager
{
    public bool showWinScreen = false;
    public bool showLoseScreen = false;
    public delegate void DebugDeelgate(string newText);
    public DebugDeelgate debug = Print;

    public string labelText = "Collect 4 items and win your freedom!";
    public int maxItems = 1;
    public Stack<string> lootStack = new Stack<string>();
    
    private int _itemsCollected = 0;
    private string _state;


    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
    


    private void WinOrLoose(string labelText, bool showWinScreen, bool showLoseScreen)
    {
        this.labelText = labelText;
        this.showWinScreen = showWinScreen;
        this.showLoseScreen= showLoseScreen;
        Time.timeScale = 0f;
    }

    public int Items
    {
        get { return _itemsCollected; }

        set 
        { 
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
            if(_itemsCollected >= maxItems)
            {

                WinOrLoose("You found all items", true, false);
            }
            else
            {
                labelText = "Item found only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    
    public int HP
    {
        get { return _playerHP; }
        set 
        { 
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            if(_playerHP == 0)
            {
                WinOrLoose("You loose!", false, true);
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                
                Utilites.RestartLevel(0);
                
            }
        }

        if(showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You loose! Continue?"))
            {
                Utilites.RestartLevel();
                Utilites.RestartLevel(0);
                
            }
        }
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);
        debug(_state);

        lootStack.Push("Sword of Doom");
        lootStack.Push("HP+");
        lootStack.Push("Golden Key");
        lootStack.Push("Winged Boot");
        lootStack.Push("Mythril Bracers");

        //GameObject player = GameObject.Find("Player");

        //PlayerBehavior playerBehavior= player.GetComponent<PlayerBehavior>();

        //playerBehavior.playerJump += HandlePlayerJump;
    }

    public void HandlePlayerJump()
    {
        Debug.Log("Player Has Jumped");
    }

    public static void Print(string newText)
    {
        Debug.Log(newText);
    }

    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();
        Debug.LogFormat("There are {0}! You've got a good chance of finding a {1} next!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items wating for you!", lootStack.Count);
    }

    void Start()
    {
        Initialize();
    }
}
